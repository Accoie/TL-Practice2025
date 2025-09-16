import styles from './CurrencyExchanger.module.css';
import { ConversionHeader } from '../ConversionHeader/ConversionHeader';
import { FromCurrencyRow } from '../CurrencyRow/FromCurrencyRow.view';
import { ToCurrencyRow } from '../CurrencyRow/ToCurrencyRow.view';
import { AboutButton } from '../buttons/AboutButton/AboutButton';
import { CurrencyInfo } from '../CurrencyInfo/CurrencyInfo';
import { CurrencyChart } from '../CurrencyChart/CurrencyChart.view';
import { formatAmount } from '../../functions/formatAmount';
import { useCurrencyExchangerState } from './CurrencyExchanger.state.ts';

export const CurrencyExchanger = () => {
  const {
    isInfoVisible,
    isLoading,
    isAvailable,
    fromCurrency,
    toCurrency,
    fromCurrencyAmount,
    toCurrencyAmount,
    exchangeRate,
    toggleInfoVisibility
  } = useCurrencyExchangerState();

  if (isLoading || !isAvailable) {
    return <></>;
  }
  
  return (
    <div className={styles.currencyExchanger}>
      <div className={styles.conversionCard}>
        <ConversionHeader
          rateMain={`${formatAmount(fromCurrencyAmount)} ${fromCurrency!.name} is`}
          rateValue={`${formatAmount(toCurrencyAmount)} ${toCurrency!.name}`}
          conversionDate={exchangeRate!.datetime.toString()}
        />
        <div className={styles.currencyWrapper}>
          <div className={styles.currencyPairBlock}>
            <FromCurrencyRow />
            <ToCurrencyRow />
          </div>
          <CurrencyChart />
        </div>

        <AboutButton
          pairCode={`${fromCurrency!.code}/${toCurrency!.code}`}
          isVisible={isInfoVisible}
          onToggle={toggleInfoVisibility}
        />
        
        <CurrencyInfo isVisible={isInfoVisible} />
      </div>
    </div>
  );
};