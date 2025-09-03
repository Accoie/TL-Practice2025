import styles from './CurrencyInfo.module.css';
import { CurrencyInfoItem } from '../CurrencyItem/CurrencyInfoItem.view.tsx';
import { currencyService } from '../../services/CurrencyService';

type CurrencyInfoProps = {
  isVisible: boolean;
};

export const CurrencyInfo = ({ isVisible }: CurrencyInfoProps) => {
  const toCurrency = currencyService.getToCurrency();
  const fromCurrency = currencyService.getFromCurrency();

  if (!toCurrency || !fromCurrency) {
    return null;
  }

  return (
    <>
      {isVisible && (
        <div className={styles.currencyInfo}>
          <CurrencyInfoItem
            name={fromCurrency.name}
            codes={`- ${fromCurrency.code} - ${fromCurrency.symbol}`}
            description={fromCurrency.description}
          />
          <CurrencyInfoItem
            name={toCurrency.name}
            codes={`- ${toCurrency.code} - ${toCurrency.symbol}`}
            description={toCurrency.description}
          />
        </div>
      )}
    </>
  );
};
