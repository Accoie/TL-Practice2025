import type { Word } from "./Word";

export type LocalStorageContextType = {
  words: Word[];
  getWordById: (id: string) => Word | undefined;
  addWord: (word: Omit<Word, 'id'>) => void;
  editWord: (id: string, updatedWord: Omit<Word, 'id'>) => void;
  deleteWord: (id: string) => void;
}