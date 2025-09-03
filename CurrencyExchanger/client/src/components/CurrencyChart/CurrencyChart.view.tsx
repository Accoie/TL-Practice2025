import { Line } from 'react-chartjs-2';
import {
  Chart as ChartJS,
  LineElement,
  PointElement,
  LinearScale,
  CategoryScale,
  Title,
  Tooltip,
  Legend
} from 'chart.js';
import styles from './CurrencyChart.module.css';
import { useCurrencyChartState } from './CurrencyChart.state';
import { IntervalButton } from '../buttons/IntervalButton/IntervalButton';

ChartJS.register(LineElement, PointElement, LinearScale, CategoryScale, Title, Tooltip, Legend);

export const CurrencyChart = () => {
  const {
    timeInterval,
    setTimeInterval,
    chartData,
    options,
    timeIntervals,
  } = useCurrencyChartState();

  return (
    <div className={styles.chartContainer}>
      <div className={styles.controls}>
        {timeIntervals.map((interval) => (
          <IntervalButton
            key={interval}
            interval={interval}
            isActive={timeInterval === interval}
            onClick={() => setTimeInterval(interval)}
          />
        ))}
      </div>

      <div className={styles.chartWrapper}>
        <Line data={chartData} options={options} />
      </div>
    </div>
  );
};