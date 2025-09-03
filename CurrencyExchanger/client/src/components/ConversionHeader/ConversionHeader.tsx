import styles from './ConversionHeader.module.css';
import { formatDateTimeToUTC } from '../../functions/formatDateTimeToUTC';

type ConversionHeaderProps = {
  rateMain: string;
  rateValue: string;
  conversionDate: string;
}

export const ConversionHeader = ({ rateMain, rateValue, conversionDate }: ConversionHeaderProps) => {
  const formattedDate = formatDateTimeToUTC(conversionDate);

  return (
    <div className={styles.conversionHeader}>
      <div className={styles.conversionRate}>
        <div className={styles.rateMain}>{rateMain}</div>
        <div className={styles.rateValue}>{rateValue}</div>
      </div>
      <div className={styles.conversionDate}>
        {formattedDate}
      </div>
    </div>
  );
};