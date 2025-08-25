import { Grade } from "../Grade/Grade.tsx";
import styles from "./GradesList.module.css";
import { useState } from "react";

type GradeItem = {
  name: string;
  value: number;
};

type GradesListProps = {
  onAverageChange: (average: number) => void;
};

export const GradesList = (gradesListProps: GradesListProps) => {
  const [grades, setGrades] = useState<GradeItem[]>([
    { name: "Чистенько", value: 6 },
    { name: "Сервис", value: 6 },
    { name: "Скорость", value: 6 },
    { name: "Место", value: 6 },
    { name: "Культура речи", value: 6 },
  ]);

  const handleGradeChange = (index: number, newValue: number) => {
    setGrades((prevGrades) =>
      prevGrades.map((grade, i) =>
        i === index ? { ...grade, value: newValue } : grade
      )
    );

    const ratedGrades = grades.filter((grade) => grade.value !== 6);
    if (ratedGrades.length === 0) {
      return 0;
    }

    const sum = ratedGrades.reduce((total, grade) => total + grade.value, 0);
    const result = sum / ratedGrades.length;

    gradesListProps.onAverageChange(result);
  };

  return (
    <div className={styles.gradesList}>
      {grades.map((grade, index) => (
        <Grade
          key={grade.name}
          name={grade.name}
          value={grade.value}
          onValueChange={(newValue) => handleGradeChange(index, newValue)}
        />
      ))}
    </div>
  );
};
