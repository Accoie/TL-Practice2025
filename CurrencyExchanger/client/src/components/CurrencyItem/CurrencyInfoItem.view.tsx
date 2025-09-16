import styles from './CurrencyInfoItem.module.css'

type CurrencyInfoItemProps = {
  name: string;
  codes: string;
  description: string;
  borderColor?: string;
}

export const CurrencyInfoItem = ({ name, codes, description, borderColor }: CurrencyInfoItemProps) => {
  return (
    <div className={styles.currencyItem} style={{ borderLeftColor: borderColor }}>
      <div className={styles.currencyTitle}>
        <span className={styles.currencyName}>{name}</span>
        <span className={styles.currencyCodes}>{codes}</span>
      </div>
      <p className={styles.currencyDescription}>
        {description}
      </p>
    </div>
  );
};