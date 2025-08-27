import { useState } from "react";
import type { GradeItem } from "../types/GradeItem";

export const useGradesState = (initialGrades: GradeItem[]) => {
  const [grades, setGrades] = useState<GradeItem[]>(initialGrades);

  const updateGrade = (index: number, newValue: number) => {
    setGrades(prevGrades =>
      prevGrades.map((grade, i) =>
        i === index ? { ...grade, value: newValue } : grade
      )
    );
  };

  return {
    grades,
    updateGrade,
  };
};