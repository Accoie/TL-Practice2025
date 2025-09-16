import styles from './CurrencyRow.module.css';
import { useFromCurrencyRowState } from './FromCurrencyRow.state.tsx';

export const FromCurrencyRow = () => {
  const {
    currency,
    amount,
    options,
    toCurrency,
    handleAmountChange,
    handleCurrencyChange
  } = useFromCurrencyRowState();

  if (!toCurrency || !currency) {
    return <></>;
  }

  return (
    <div className={styles.currencyRow}>
      <input
        type="number"
        value={amount}
        onChange={handleAmountChange}
        className={styles.currencyInput}
      />
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