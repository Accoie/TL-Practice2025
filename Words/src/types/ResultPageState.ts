import type { Word } from "./Word";

export type ResultPageState = {
  answers: { word: Word; correct: boolean }[];
}