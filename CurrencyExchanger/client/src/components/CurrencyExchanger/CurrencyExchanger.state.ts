import { useState } from 'react';
import { useCurrencyData, useCurrencyEffects, useExchangeRate } from '../../hooks/useCurrencyExchanger';
import { currencyService } from '../../services/CurrencyService';

export const useCurrencyExchangerState = () => {
  const [isInfoVisible, setIsInfoVisible] = useState(false);
  const { loading, fromCurrency, toCurrency, fromCurrencyAmount, toCurrencyAmount } = useCurrencyData();
  const exchangeRate = useExchangeRate();

  useCurrencyEffects();

  const toggleInfoVisibility = () => {
    setIsInfoVisible(!isInfoVisible);
  };

  const isLoading = loading || !fromCurrency || !toCurrency || !exchangeRate;
  const isAvailable = currencyService.isAvailable();

  return {
    isInfoVisible,
    isLoading,
    isAvailable,
    fromCurrency,
    toCurrency,
    fromCurrencyAmount,
    toCurrencyAmount,
    exchangeRate,
    toggleInfoVisibility
  };
};