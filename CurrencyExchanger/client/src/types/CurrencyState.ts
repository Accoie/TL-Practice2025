import type { Currency } from "./Currency";
import type { ExchangeRate } from "./ExchangeRate";

export type CurrencyState = {
  currencies: Currency[];
  exchangeRates: ExchangeRate[];
  fromCurrency?: Currency;
  toCurrency?: Currency;
  loading: boolean;
  error?: string;
  fromAmount: number;
  toAmount: number;
}