import { TooltipItem } from 'chart.js';
import { TimeInterval } from '../../types/TimeInterval';
import { useCurrencyData, useTimeInterval } from '../../hooks/useCurrencyChart';
import { formatDateTimeToGMT } from '../../functions/formatDateTimeToGMT';
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
  Filler
} from 'chart.js';

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
  Filler
);

export const TIME_INTERVALS: TimeInterval[] = ['5 MIN', '4 MIN', '3 MIN', '2 MIN', '1 MIN'];

export const useCurrencyChartState = () => {
  const { timeInterval, setTimeInterval } = useTimeInterval();
  const { data, isLoading, error, paymentCurrency, purchaseCurrency, refetch } = useCurrencyData(timeInterval);

  const chartData = {
    labels: data.map(() => ''),
    datasets: [
      {
        label: `${paymentCurrency}/${purchaseCurrency}`,
        data: data.map((item) => item.rate),
        pointBackgroundColor: '#17a217',
        pointBorderColor: '#17a217',  
        pointBorderWidth: 0,
        borderColor: '#17a2177e',   
        fill: {
          target: 'origin',
          above: '#22d40e2a',
        },
        backgroundColor: 'rgba(23, 162, 23, 0.1)',
        pointRadius: 3,
        tension: 0.2,
        borderWidth: 2,
        datetimes: data.map((item) => formatDateTimeToGMT(item.datetime))
      }
    ]
  };

  const options = {
    animation: { duration: 0 },
    responsive: true,
    maintainAspectRatio: false,
    scales: {
      x: { grid: { display: false }, ticks: { display: false } },
      y: { grid: { color: 'rgba(0,0,0,0.1)' }, ticks: { color: '#666', font: { size: 12 } } }
    },
    plugins: {
      legend: {
        display: false,
        position: 'top' as const,
        labels: { color: '#202124', font: { size: 14, weight: 'bold' as const } }
      },
      title: {
        display: true,
        text: `${paymentCurrency} to ${purchaseCurrency} Exchange Rate`,
        color: '#202124',
        font: { size: 16, weight: 'bold' as const }
      },
      tooltip: {
        callbacks: {
          title: (tooltipItems: TooltipItem<'line'>[]) => {
            const index = tooltipItems[0].dataIndex;
            return formatDateTimeToGMT(data[index]?.datetime) || '';
          },
          label: (tooltipItem: TooltipItem<'line'>) => {
            return `Rate: ${tooltipItem.raw}`;
          }
        },
        backgroundColor: 'rgba(0,0,0,0.8)',
        titleColor: '#fff',
        bodyColor: '#fff',
        titleFont: { size: 14, weight: 'normal' as const },
        bodyFont: { size: 13, weight: 'normal' as const }
      }
    }
  };

  return {
    timeInterval,
    setTimeInterval,
    chartData,
    options,
    isLoading,
    error,
    paymentCurrency,
    purchaseCurrency,
    timeIntervals: TIME_INTERVALS,
    refetch
  };
};