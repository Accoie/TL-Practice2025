import type { ExchangeRate } from './types/ExchangeRate';
import type { Currency } from './types/Currency';
import type { ExchangeRateResponse } from './types/ApiResponse';

const API_BASE_URL = 'https://localhost:7145/';

export class ClientApi {
  public static async fetchCurrencies(): Promise<Currency[]> {
    try {
      const response = await fetch(`${API_BASE_URL}Currency`);
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Failed to fetch currencies: ${response.status} ${response.statusText} - ${errorText}`);
      }

      return await response.json();
    } catch (error) {
      throw new Error(error instanceof Error ? error.message : 'Currency fetch error');
    }
  }

  public static async fetchCurrencyByCode(code: string): Promise<Currency> {
    try {
      const response = await fetch(`${API_BASE_URL}Currency/${code}`);
      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Failed to fetch currency ${code}: ${response.status} ${response.statusText} - ${errorText}`);
      }

      return await response.json();
    } catch (error) {
      throw new Error(error instanceof Error ? error.message : 'Currency fetch error');
    }
  }

  public static async fetchExchangeRates(
    paymentCurrency: string,
    purchasedCurrency: string,
    fromDateTime: Date = new Date(Date.now() - 24 * 60 * 60 * 1000)
  ): Promise<ExchangeRate[]> {
    try {
      const url = `${API_BASE_URL}prices/?PaymentCurrency=${paymentCurrency}&PurchasedCurrency=${purchasedCurrency}&FromDateTime=${encodeURIComponent(fromDateTime.toISOString())}`;

      const response = await fetch(url);

      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Failed to fetch exchange rates: ${response.status} ${response.statusText} - ${errorText}`);
      }

      const data: ExchangeRateResponse[] = await response.json();
      
      const exchangeRates: ExchangeRate[] = data.map((item: ExchangeRateResponse) => ({
        fromCurrency: item.paymentCurrencyCode,
        toCurrency: item.purchasedCurrencyCode, 
        rate: item.price, 
        datetime: item.dateTime
      }));

      return exchangeRates;
    } catch (error) {
      throw new Error(error instanceof Error ? error.message : 'Exchange rates fetch error');
    }
  }
}