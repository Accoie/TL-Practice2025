import styles from "./Grade.module.css";
import { useRef } from "react";

type GradeProps = {
  name: string;
  value: number;
  onValueChange: (newValue: number) => void;
};

export const Grade = ({ name, value, onValueChange }: GradeProps) => {
  const sliderRef = useRef<HTMLInputElement>(null);

  const getSmiley = (val: number) => {
    switch (val) {
      case 1:
        return <img src="src/assets/icons/twemoji_angry-face.svg"></img>;
      case 2:
        return <img src="src/assets/icons/twemoji_slightly-frowning-face.svg"></img>;

      case 3:
        return <img src="src/assets/icons/twemoji_neutral-face.svg"></img>;
      case 4:
        return <img src="src/assets/icons/twemoji_slightly-smiling-face.svg"></img>;

      case 5:
        return <img src="src/assets/icons/twemoji_grinning-face-with-big-eyes.svg"></img>;

      default:
        return null;
    }
  };

  const getColor = (val: number) => {
    switch (val) {
      case 1:
        return "#ff4d4d";
      case 2:
        return "#ffa64d";
      case 3:
        return "#ffa64d";
      case 4:
        return "#ffe600ff";
      case 5:
        return "#ffe600ff";
      default:
        return "#ffffff";
    }
  };

  const fillPercentage = ((value - 1) / 4) * 100;

  const getThumbPosition = () => {
    if (!sliderRef.current) return "0%";
    const thumbPosition = ((value - 1) / 4) * 100;
    return `calc(${thumbPosition}% - 15px)`;
  };

  const getTickColor = (tick: number) => {
    const initialValue = 6;
    if (value === initialValue) {
      return getColor(tick);
    }
    if (tick > value) {
      return getColor(initialValue);
    }
    if (tick < value) {
      return getColor(value);
    }
  };

  const handleGradeClick = (e: React.MouseEvent) => {
    if (!sliderRef || !sliderRef.current){
      return;
    }
    
    const rect = sliderRef.current.getBoundingClientRect();
    const clickX = e.clientX - rect.left;
    const width = rect.width;
    
    const segmentWidth = width / 5;
    let newValue = Math.floor(clickX / segmentWidth) + 1;
    newValue = Math.min(5, Math.max(1, newValue));
    
    onValueChange(newValue);
  }
  return (
    <div className={styles.gradeWrapper}>
      <div className={styles.inputContainer}>
        <input
          ref={sliderRef}
          className={styles.gradeInput}
          type="range"
          min="1"
          max="5"
          step="1"
          value={value}
          onClick={ handleGradeClick }
          onChange={(e) => onValueChange(parseInt(e.target.value, 10))}
          style={{
            background: `linear-gradient(to right, ${getColor(
              value
            )} 0%, ${getColor(
              value
            )} ${fillPercentage}%, #ffffffff ${fillPercentage}%, #ffffffff 100%)`,
          }}
        />

        <div
          className={styles.customThumb}
          style={{ left: getThumbPosition() }}
        >
          {getSmiley(value)}
        </div>

        <div className={styles.ticks}>
          {[1, 2, 3, 4, 5].map((tick) => (
            <span
              key={tick}
              className={`${styles.tick} ${value >= tick ? styles.active : ""}`}
              style={{
                left: `${(tick - 1) * 25}%`,
                backgroundColor: `${getTickColor(tick)}`,
              }}
            />
          ))}
        </div>
      </div>
      <p className={styles.gradeTitle}>{name}</p>
    </div>
  );
};