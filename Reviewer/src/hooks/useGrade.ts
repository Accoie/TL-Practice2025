import { useRef, useCallback } from 'react';

export const useGrade = (value: number, onValueChange: (newValue: number) => void) => {
  const sliderRef = useRef<HTMLInputElement>(null);

  const fillPercentage = ((value - 1) / 4) * 100;

  const getThumbPosition = useCallback((): string => {
    if (!sliderRef.current) return "0%";
    const thumbPosition = ((value - 1) / 4) * 100;
    return `calc(${thumbPosition}% - 15px)`;
  }, [value]);

  const handleGradeClick = useCallback((e: React.MouseEvent) => {
    if (!sliderRef.current) {
      return;
    }

    const rect = sliderRef.current.getBoundingClientRect();
    const clickX = e.clientX - rect.left;
    const width = rect.width;

    const segmentWidth = width / 5;
    let newValue = Math.floor(clickX / segmentWidth) + 1;
    newValue = Math.min(5, Math.max(1, newValue));

    onValueChange(newValue);
  }, [onValueChange]);

  const handleInputChange = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
    onValueChange(parseInt(e.target.value, 10));
  }, [onValueChange]);

  return {
    sliderRef,
    fillPercentage,
    getThumbPosition,
    handleGradeClick,
    handleInputChange
  };
};