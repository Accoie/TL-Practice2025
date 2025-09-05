import { useState, useEffect } from 'react';
import { useNavigate, useLocation } from "react-router-dom";
import type { ResultPageState } from '../../types/ResultPageState';
import type { TestResult } from '../../types/TestResult';

export const useResultPageState = () => {
  const navigate = useNavigate();
  const location = useLocation();
  
  const [resultAnswers, setResultAnswers] = useState<TestResult[]>([]);
  const [correctCount, setCorrectCount] = useState(0);
  const [totalCount, setTotalCount] = useState(0);

  useEffect(() => {
    const answers = (location.state as ResultPageState)?.answers || [];
    setResultAnswers(answers);
    setCorrectCount(answers.filter((a) => a.correct).length);
    setTotalCount(answers.length);
  }, [location.state]);

  const handleRetry = () => {
    navigate("/test", { replace: true, state: { forceReset: true } });
  };

  const goToHome = () => {
    navigate("/");
  };

  return {
    resultAnswers,
    correctCount,
    totalCount,
    handleRetry,
    goToHome
  };
};