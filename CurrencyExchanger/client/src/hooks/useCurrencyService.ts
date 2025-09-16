import { useStore } from '../hooks/useStore';
import { currencyService } from '../services/CurrencyService';

export const useFromCurrency = () => {
  return useStore(currencyService.getStore(), (state) => state.fromCurrency);
};

export const useToCurrency = () => {
  return useStore(currencyService.getStore(), (state) => state.toCurrency);
};

export const useToCurrencyCode = () => {
  return useStore(currencyService.getStore(), (state) => state.toCurrency?.code);
};

export const useFromCurrencyCode = () => {
  return useStore(currencyService.getStore(), (state) => state.fromCurrency?.code);
};

export const useFromCurrencyAmount = () => {
  return useStore(currencyService.getStore(), (state) => state.fromAmount);
};

export const useToCurrencyAmount = () => {
  return useStore(currencyService.getStore(), (state) => state.toAmount);
};

export const useCurrencyStore = () => {
  return useStore(currencyService.getStore());
};

export const useCurrencies = () => {
  return useStore(currencyService.getStore(), (state) => state.currencies);
};

export const useExchangeRates = () => {
  return useStore(currencyService.getStore(), (state) => state.exchangeRates);
};

export const useLoading = () => {
  return useStore(currencyService.getStore(), (state) => state.loading);
};

export const useError = () => {
  return useStore(currencyService.getStore(), (state) => state.error);
};

export const useExchangeRate = (fromCurrency: string, toCurrency: string) => {
  const exchangeRates = useExchangeRates();
  return exchangeRates.find((rate) => rate.fromCurrency === fromCurrency && rate.toCurrency === toCurrency);
};

export const useCurrencyInfo = (code: string) => {
  const currencies = useCurrencies();
  return currencies.find((currency) => currency.code === code);
};

export const useIsAvailable = () => {
  const error = useError();
  const currencies = useCurrencies();
  return !error && currencies.length !== 0;
};