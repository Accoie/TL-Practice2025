import styles from './LoadingDisplay.module.css';
import { useLoadingDisplayState } from './LoadingDisplay.state';

export const LoadingDisplay = () => {
  const { isLoading } = useLoadingDisplayState();

  if (!isLoading) {
    return null;
  }

  return (
    <div className={styles.container}>
      <div className={styles.loader} role="status">
        <div className={styles.spinner}></div>
        <div className={styles.loadingText}>Loading currencies...</div>
      </div>
    </div>
  );
};