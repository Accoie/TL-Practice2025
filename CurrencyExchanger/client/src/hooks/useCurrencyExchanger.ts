import { useEffect } from 'react';
import { currencyService } from '../services/CurrencyService';
import { useExchangeRates, useFromCurrency, useFromCurrencyAmount, useLoading, useToCurrency, useToCurrencyAmount } from '../hooks/useCurrencyService'

export const useCurrencyData = () => {
  const fromCurrency = useFromCurrency();
  const toCurrency = useToCurrency();
  const fromCurrencyAmount = useFromCurrencyAmount();
  const toCurrencyAmount = useToCurrencyAmount();
  const exchangeRates = useExchangeRates();
  const loading = useLoading();

  return {
    fromCurrency,
    toCurrency,
    fromCurrencyAmount,
    toCurrencyAmount,
    exchangeRates,
    loading
  };
};

export const useCurrencyEffects = () => {
  useEffect(() => {
    currencyService.loadCurrencies();
  }, []);

  const { fromCurrency, toCurrency } = useCurrencyData();

  useEffect(() => {
    if (fromCurrency && toCurrency) {
      currencyService.loadExchangeRates();
    }
  }, [fromCurrency, toCurrency]);
};

export const useExchangeRate = () => {
  const { fromCurrency, toCurrency, exchangeRates } = useCurrencyData();
  
  return fromCurrency && toCurrency
    ? exchangeRates.find((rate) => rate.fromCurrency === fromCurrency.code && rate.toCurrency === toCurrency.code)
    : undefined;
};