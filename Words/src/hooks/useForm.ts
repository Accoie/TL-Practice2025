import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useLocalStorageWords } from "./useLocalStorageWords";

type FormProps = {
  mode: 'create' | 'edit';
  initialRussian?: string;
  initialEnglish?: string;
  wordId?: string;
};

export const useForm = ({ mode, initialRussian = "", initialEnglish = "", wordId }: FormProps) => {
  const [russian, setRussian] = useState(initialRussian);
  const [english, setEnglish] = useState(initialEnglish);
  const { addWord, editWord } = useLocalStorageWords();
  const navigate = useNavigate();

  const isValid = Boolean(russian.trim() && english.trim());

  useEffect(() => {
    setRussian(initialRussian);
    setEnglish(initialEnglish);
  }, [initialRussian, initialEnglish]);

  const handleSave = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isValid) return;

    if (mode === 'create') {
      addWord({
        russian: russian.trim(),
        english: english.trim()
      });
    } else if (mode === 'edit' && wordId) {
      editWord(wordId, {
        russian: russian.trim(),
        english: english.trim()
      });
    }
    
    navigate('/dictionary');
  };

  const handleCancel = () => {
    navigate('/dictionary');
  };

  return {
    russian,
    english,
    isValid,
    setRussian,
    setEnglish,
    handleSave,
    handleCancel
  };
};