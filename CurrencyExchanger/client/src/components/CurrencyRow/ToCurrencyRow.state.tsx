import { useCurrencies, useFromCurrency, useToCurrency, useToCurrencyAmount } from '../../hooks/useCurrencyService';
import { currencyService } from '../../services/CurrencyService';

const handleCurrencyChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
  const selectedCurrencyName = e.target.value;
  currencyService.setToCurrencyByName(selectedCurrencyName);
};

export const useToCurrencyRowState = () => {
  const fromCurrency = useFromCurrency();
  const currency = useToCurrency();
  const amount = useToCurrencyAmount();
  
  const options = useCurrencies()
    .map((c) => c.name)
    .filter((c) => c !== fromCurrency?.name);

  return {
    fromCurrency,
    currency,
    amount,
    options,
    handleCurrencyChange
  };
};