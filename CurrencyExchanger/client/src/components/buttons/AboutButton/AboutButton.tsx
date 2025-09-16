import styles from './AboutButton.module.css';

type AboutButtonProps = {
  pairCode: string;
  isVisible: boolean;
  onToggle: () => void;
}

const displayTrendArrow = (isVisible: boolean) => {
  return (
    <span className={styles.trendArrow}>
      { isVisible ?
        '↑' : '↓'

      }
    </span> 
  )
}

export const AboutButton = ({ pairCode, isVisible, onToggle }: AboutButtonProps) => {
  return (
    <div className={styles.pairInfo}>
      <div className={styles.strip}></div>
      <button 
        className={styles.aboutButton}
        onClick={onToggle}
      >
        <span className={styles.pairCode}>{pairCode}:</span>
        <span className={styles.aboutText}>about</span>

        {displayTrendArrow(isVisible)}
        
      </button>
    </div>
  );
};