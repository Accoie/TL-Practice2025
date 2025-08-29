import { SmileIcon } from "../EmojiIcon";
import styles from "./Grade.module.css";
import { useGrade } from "../../hooks/useGrade";
import { getColor } from "../../functions/getColor";
import { useMemo } from "react";
import { getTickColor } from "../../functions/getTickColor";

type GradeProps = {
  name: string;
  value: number;
  onValueChange: (newValue: number) => void;
};

export const Grade = ({ name, value, onValueChange }: GradeProps) => {
  const {
    sliderRef,
    fillPercentage,
    getThumbPosition,
    handleGradeClick,
    handleInputChange
  } = useGrade(value, onValueChange);

  const inputStyle = useMemo(() => ({
    background: `linear-gradient(to right, ${getColor(value)} 0%, ${getColor(value)} ${fillPercentage}%, #ffffffff ${fillPercentage}%, #ffffffff 100%)`,
  }), [value, fillPercentage]);

  const thumbPosition = getThumbPosition();

  const ticks = useMemo(() => {
    return [1, 2, 3, 4, 5].map((tick) => {
      const isActive = value >= tick;
      const tickColor = getTickColor(tick, value);
      const tickPosition = `${(tick - 1) * 25}%`;
      
      return {
        id: tick,
        isActive,
        style: {
          left: tickPosition,
          backgroundColor: tickColor,
        },
      };
    });
  }, [value]);

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
          onClick={handleGradeClick}
          onChange={handleInputChange}
          style={inputStyle}
        />

        <div
          className={styles.customThumb}
          style={{ left: thumbPosition }}
        >
          <SmileIcon value={value} />
        </div>

        <div className={styles.ticks}>
          {ticks.map((tick) => (
            <span
              key={tick.id}
              className={styles.tick}
              style={tick.style}
            />
          ))}
        </div>
      </div>
      <p className={styles.gradeTitle}>{name}</p>
    </div>
  );
};