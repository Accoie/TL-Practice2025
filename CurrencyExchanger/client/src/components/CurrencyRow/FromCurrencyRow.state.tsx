import { useCurrencies, useFromCurrency, useFromCurrencyAmount, useToCurrency } from '../../hooks/useCurrencyService';
import { currencyService } from '../../services/CurrencyService';

const handleAmountChange = (e: React.ChangeEvent<HTMLInputElement>) => {
  const value = e.target.value;
  const numericValue = parseFloat(value);
  if (!isNaN(numericValue)) {
    currencyService.setFromAmount(numericValue);
  }
};

const handleCurrencyChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
  const selectedCurrencyName = e.target.value;
  currencyService.setFromCurrencyByName(selectedCurrencyName);
};

export const useFromCurrencyRowState = () => {
  const currency = useFromCurrency();
  const amount = useFromCurrencyAmount();
  const toCurrency = useToCurrency();
  
  const options = useCurrencies()
    .map((c) => c.name)
    .filter((c) => c !== toCurrency?.name);

  return {
    currency,
    amount,
    options,
    toCurrency,
    handleAmountChange,
    handleCurrencyChange
  };
};