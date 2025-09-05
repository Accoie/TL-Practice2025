import React, { useState, useEffect } from "react";
import { LocalStorageContext } from "./LocalStorageContext.ts";
import type { Word } from "../../types/Word";
import type { LocalStorageContextType } from "../../types/LocalStorageContextType";

type LocalStorageProviderProps = {
  children: React.ReactNode;
};

export const LocalStorageProvider: React.FC<LocalStorageProviderProps> = ({
  children,
}) => {
  const [words, setWords] = useState<Word[]>([]);

  useEffect(() => {
    const savedWords = localStorage.getItem("dictionaryWords");
    if (savedWords) {
      setWords(JSON.parse(savedWords));
    }
  }, []);

  useEffect(() => {
    if (words.length === 0) {
      return;
    }
    localStorage.setItem("dictionaryWords", JSON.stringify(words));
  }, [words]);

  const getWordById = (id: string): Word | undefined => {
    return words.find((word) => word.id === id);
  };

  const addWord = (word: Omit<Word, "id">) => {
    const newWord: Word = {
      ...word,
      id: Date.now().toString(),
    };
    setWords((prev) => [...prev, newWord]);
  };

  const editWord = (id: string, updatedWord: Omit<Word, "id">) => {
    setWords((prev) =>
      prev.map((word) => (word.id === id ? { ...updatedWord, id } : word))
    );
  };

  const deleteWord = (id: string) => {
    setWords((prev) => prev.filter((word) => word.id !== id));
  };

  const value: LocalStorageContextType = {
    words,
    getWordById,
    addWord,
    editWord,
    deleteWord,
  };

  return (
    <LocalStorageContext.Provider value={value}>
      {children}
    </LocalStorageContext.Provider>
  );
};
