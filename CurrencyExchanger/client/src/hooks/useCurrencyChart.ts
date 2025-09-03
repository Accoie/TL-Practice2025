import { useCallback, useEffect, useState } from 'react';
import { currencyService } from '../services/CurrencyService';
import { ExchangeRate } from '../types/ExchangeRate';
import { TimeInterval } from '../types/TimeInterval';
import { getMilliseconds } from '../functions/getMilliseconds';
import { useFromCurrency, useToCurrency } from './useCurrencyService';

export const useCurrencyData = (timeInterval: TimeInterval) => {
  const [data, setData] = useState<ExchangeRate[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const paymentCurrency = useToCurrency()?.code;
  const purchaseCurrency = useFromCurrency()?.code;

  const fetchData = useCallback(async () => {
    if (!paymentCurrency || !purchaseCurrency) return;

    setIsLoading(true);
    setError(null);

    try {
      const fromDate = new Date(Date.now() - getMilliseconds(timeInterval));
      const fetchedData = await currencyService.fetchExchangeRates(fromDate);
      setData(fetchedData);
    } catch (err) {
      console.error('Error fetching data:', err);
      setError('Failed to fetch exchange rates');
      setData([]);
    } finally {
      setIsLoading(false);
    }
  }, [paymentCurrency, purchaseCurrency, timeInterval]);

  useEffect(() => {
    fetchData();
  }, [fetchData]);

  return {
    data,
    isLoading,
    error,
    paymentCurrency,
    purchaseCurrency,
    refetch: fetchData
  };
};

export const useTimeInterval = (initialInterval: TimeInterval = '5 MIN') => {
  const [timeInterval, setTimeInterval] = useState<TimeInterval>(initialInterval);

  return {
    timeInterval,
    setTimeInterval
  };
};