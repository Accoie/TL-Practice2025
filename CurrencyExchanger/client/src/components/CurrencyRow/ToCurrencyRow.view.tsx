import styles from './CurrencyRow.module.css';
import { formatAmount } from '../../functions/formatAmount';
import { useToCurrencyRowState } from './ToCurrencyRow.state';

export const ToCurrencyRow = () => {
  const {
    fromCurrency,
    currency,
    amount,
    options,
    handleCurrencyChange
  } = useToCurrencyRowState();

  if (!fromCurrency || !currency) {
    return <></>;
  }

  return (
    <div className={styles.currencyRow}>
      <div className={styles.currencyAmount}>{formatAmount(amount)}</div>
      <div className={styles.strip}></div>
      <div className={styles.currencySelectContainer}>
        <select 
          value={currency.name} 
          onChange={handleCurrencyChange}
          className={styles.currencySelect}
        >
          {options.map((option) => (
            <option key={option} value={option}>
              {option}
            </option>
          ))}
        </select>
        <span className={styles.selectArrow}>▼</span>
      </div>
    </div>
  );
};