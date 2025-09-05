import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useLocalStorageWords } from "./useLocalStorageWords";
import type { Word } from "../types/Word";

export const useTestTranslationPage = (currentIndex: number) => {
  const { words } = useLocalStorageWords();
  const navigate = useNavigate();

  const [selectedWords, setSelectedWords] = useState<Word[]>([]);
  const [options, setOptions] = useState<string[]>([]);
  const [selectedOption, setSelectedOption] = useState("");

  useEffect(() => {
    if (words.length < 5) {
      navigate("/", {
        state: { message: "Добавьте хотя бы 5 слов в словарь" }
      });
      return;
    }

    const shuffled = [...words].sort(() => 0.5 - Math.random());
    setSelectedWords(shuffled.slice(0, 5));
  }, [words, navigate]);

  useEffect(() => {
    if (selectedWords.length > 0 && currentIndex < selectedWords.length) {
      const currentWord = selectedWords[currentIndex];

      const otherWords = words
        .filter(word => word.id !== currentWord.id)
        .sort(() => 0.5 - Math.random())
        .slice(0, 4)
        .map(word => word.english);

      const allOptions = [...otherWords, currentWord.english].sort(
        () => 0.5 - Math.random()
      );

      setOptions(allOptions);
      setSelectedOption("");
    }
  }, [currentIndex, selectedWords, words]);

  return {
    words,
    selectedWords,
    options,
    selectedOption,
    setSelectedOption,
  };
};
