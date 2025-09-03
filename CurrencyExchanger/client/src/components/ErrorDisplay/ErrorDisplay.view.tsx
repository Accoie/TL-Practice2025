import styles from './ErrorDisplay.module.css';
import { useErrorDisplayState } from './ErrorDisplay.state';

export const ErrorDisplay = () => {
  const { shouldDisplayError, handleRetry } = useErrorDisplayState();

  if (!shouldDisplayError) {
    return null;
  }

  return (
    <div className={styles.container}>
      <div className={styles.alert} role="alert">
        <div className={styles.alertContent}>
          <span className={styles.errorMessage}>
            {'Could not get data from server!'}
          </span>
          <button 
            className={styles.retryButton} 
            onClick={handleRetry}
          >
            Retry
          </button>
        </div>
      </div>
    </div>
  );
};