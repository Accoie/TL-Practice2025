import { useState, useEffect } from 'react';
import { currencyService } from '../../services/CurrencyService';

export const useLoadingDisplayState = () => {
  const [isLoading, setIsLoading] = useState(currencyService.getLoading());

  useEffect(() => {
    const unsubscribe = currencyService.subscribe(() => {
      setIsLoading(currencyService.getLoading());
    });

    return unsubscribe;
  }, []);

  return {
    isLoading
  };
};