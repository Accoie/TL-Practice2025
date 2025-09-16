import { Store } from '../store/Store';
import type { Currency } from '../types/Currency';
import type { ExchangeRate } from '../types/ExchangeRate';
import type { CurrencyState } from '../types/CurrencyState';
import { ClientApi } from '../ClientApi';

export class CurrencyService {
  private static instance: CurrencyService;
  private store = Store.create<CurrencyState>({
    currencies: [],
    exchangeRates: [],
    loading: false,
    error: undefined,
    fromCurrency: undefined,
    toCurrency: undefined,
    fromAmount: 1,
    toAmount: 10
  });

  private constructor() {}

  public setFromCurrencyByName(name: string) {
    const currency = this.store.getSnapshot().currencies.find((c) => c.name === name);
    if (!currency) {
      return;
    }

    this.setFromCurrency(currency);
  }

  public setToCurrencyByName(name: string) {
    const currency = this.store.getSnapshot().currencies.find((c) => c.name === name);

    if (!currency) {
      return;
    }

    this.setToCurrency(currency);
  }

  public isAvailable() {
    return !this.getError() && this.getCurrencies().length !== 0;
  }

  public static getInstance(): CurrencyService {
    if (!CurrencyService.instance) {
      CurrencyService.instance = new CurrencyService();
    }
    return CurrencyService.instance;
  }

  public subscribe = this.store.subscribe;
  public getSnapshot = this.store.getSnapshot;

  public getStore = () => this.store;

  public getCurrencies = (): Currency[] => this.store.getSnapshot().currencies;
  public getExchangeRates = (): ExchangeRate[] => this.store.getSnapshot().exchangeRates;
  public getLoading = (): boolean => this.store.getSnapshot().loading;
  public getError = (): string | undefined => this.store.getSnapshot().error;
  public getLastExchangeRate = (): ExchangeRate | undefined => {
    return this.store.getSnapshot().exchangeRates.slice(-1)[0];
  };

  public getFromCurrency = (): Currency | undefined => this.store.getSnapshot().fromCurrency;
  public getToCurrency = (): Currency | undefined => this.store.getSnapshot().toCurrency;
  public getFromCurrencyAmount = (): number => this.store.getSnapshot().fromAmount;
  public getToCurrencyAmount = (): number => this.store.getSnapshot().toAmount;

  public getCurrencyInfo = (code: string): Currency | undefined => {
    return this.store.getSnapshot().currencies.find((currency) => currency.code === code);
  };

  private setState = (newState: Partial<CurrencyState>) => {
    this.store.set({ ...this.store.getSnapshot(), ...newState });
  };
  private setFromCurrency = (fromCurrency: Currency) => this.setState({ fromCurrency });
  private setToCurrency = (toCurrency: Currency) => this.setState({ toCurrency });

  private setLoading = (loading: boolean) => this.setState({ loading });
  private setError = (error: string | undefined) => this.setState({ error });
  private setCurrencies = (currencies: Currency[]) => this.setState({ currencies });
  private setExchangeRates = (exchangeRates: ExchangeRate[]) => this.setState({ exchangeRates });
  public setFromAmount = (fromAmount: number) => {
    this.setState({ fromAmount });
    const exchange = this.getLastExchangeRate();

    if (!exchange) {
      return;
    }

    this.setToAmount(fromAmount * exchange.rate);
  };

  public setToAmount = (toAmount: number) => this.setState({ toAmount });

  public async loadCurrencies(): Promise<void> {
    try {
      this.setLoading(true);
      this.setError(undefined);

      const currencies = await ClientApi.fetchCurrencies();
      if (currencies) {
        this.setCurrencies(currencies);

        let fromCurrency = this.getFromCurrency();
        let toCurrency = this.getToCurrency();

        if (!fromCurrency) {
          this.setFromCurrency(currencies[0]);
          fromCurrency = currencies[0];
        }

        if (!this.getToCurrency()) {
          this.setToCurrency(currencies[1]);
          toCurrency = currencies[1];
        }
        if (fromCurrency && toCurrency) {
          await this.loadExchangeRates();
          console.log(this.getExchangeRates());
        }
      }
    } catch (error) {
      this.setError(error instanceof Error ? error.message : 'Failed to load currencies');
    } finally {
      this.setLoading(false);
    }
  }

  public async loadCurrencyByCode(code: string): Promise<void> {
    try {
      this.setLoading(true);
      this.setError(undefined);

      const currency = await ClientApi.fetchCurrencyByCode(code);

      const currentCurrencies = this.getCurrencies();
      const updatedCurrencies = currentCurrencies.some((c) => c.code === code)
        ? currentCurrencies.map((c) => (c.code === code ? currency : c))
        : [...currentCurrencies, currency];

      this.setCurrencies(updatedCurrencies);
    } catch (error) {
      this.setError(error instanceof Error ? error.message : 'Failed to load currency');
    } finally {
      this.setLoading(false);
    }
  }

  public async fetchExchangeRates(fromDateTime: Date = new Date(Date.now() - 1 * 60 * 1000)): Promise<ExchangeRate[]> {
    const paymentCurrency = this.getFromCurrency();
    const purchasedCurrency = this.getToCurrency();

    if (!paymentCurrency || !purchasedCurrency) {
      throw new Error('Currencies not selected');
    }

    try {
      const exchangeRates: ExchangeRate[] = await ClientApi.fetchExchangeRates(
        paymentCurrency.code,
        purchasedCurrency.code,
        fromDateTime
      );
      
      return exchangeRates;
    } catch (error) {
      this.setError(error instanceof Error ? error.message : 'Failed to fetch exchange rates');
      throw error;
    }
  }

  public async loadExchangeRates(fromDateTime: Date = new Date(Date.now() - 1 * 60 * 1000)): Promise<void> {
    try {
      const paymentCurrency = this.getFromCurrency();
      const purchasedCurrency = this.getToCurrency();

      if (paymentCurrency && purchasedCurrency) {
        this.setLoading(true);
        this.setError(undefined);

        const exchangeRates: ExchangeRate[] = await ClientApi.fetchExchangeRates(
          paymentCurrency.code,
          purchasedCurrency.code,
          fromDateTime
        );

        this.setToAmount(this.store.getSnapshot().fromAmount * exchangeRates[0].rate);

        this.setExchangeRates(exchangeRates);
      }
    } catch (error) {
      this.setLoading(false);
      this.setError(error instanceof Error ? error.message : 'Failed to load exchange rates');
    } finally {
      this.setLoading(false);
    }
  }

  public clearError(): void {
    this.setError(undefined);
  }
}

export const currencyService = CurrencyService.getInstance();