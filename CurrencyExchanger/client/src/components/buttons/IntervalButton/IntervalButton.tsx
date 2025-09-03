import { TimeInterval } from '../../../types/TimeInterval';
import styles from './IntervalButton.module.css';

type IntervalButtonProps = {
  interval: TimeInterval;
  isActive: boolean;
  onClick: (interval: TimeInterval) => void;
}

export const IntervalButton = ({ interval, isActive, onClick }: IntervalButtonProps) => {
  return (
    <button
      onClick={() => onClick(interval)}
      disabled={isActive}
      className={`${styles.intervalButton} ${isActive ? styles.active : ''}`}
    >
      {interval}
    </button>
  );
};