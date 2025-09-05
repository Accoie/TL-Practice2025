import { useState } from "react";
import { useNavigate } from "react-router-dom";
import type { SelectChangeEvent } from "@mui/material";
import { useTestTranslationPage } from "../../hooks/useTestTranslationPage";
import type { TestResult } from "../../types/TestResult";

export const useTestTranslationState = () => {
  const navigate = useNavigate();
  const [currentIndex, setCurrentIndex] = useState(0);
  const [answers, setAnswers] = useState<TestResult[]>([]);
  const [completed, setCompleted] = useState(false);

  const { selectedWords, options, selectedOption, setSelectedOption } =
    useTestTranslationPage(currentIndex);

  const handleNext = () => {
    if (!selectedOption) return;

    const currentWord = selectedWords[currentIndex];
    const isCorrect = selectedOption === currentWord.english;

    const newAnswer = { word: currentWord, correct: isCorrect };

    setAnswers((prev) => [...prev, newAnswer]);
    if (currentIndex < selectedWords.length - 1) {
      setCurrentIndex((prev) => prev + 1);
    } else {
      navigate("/result", { state: { answers: [...answers, newAnswer] } });
      setCompleted(true);
    }
  };

  const handleOptionChange = (event: SelectChangeEvent) => {
    setSelectedOption(event.target.value);
  };

  const progress =
    selectedWords.length > 0 ? (currentIndex / selectedWords.length) * 100 : 0;

  return {
    selectedWords,
    currentIndex,
    options,
    selectedOption,
    answers,
    completed,
    progress,
    handleOptionChange,
    handleNext,
  };
};
