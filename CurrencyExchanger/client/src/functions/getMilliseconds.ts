import { TimeInterval } from "../types/TimeInterval";

export const getMilliseconds = (interval: TimeInterval) => {
  switch (interval) {
    case '1 MIN':
      return 1 * 60 * 1000;
    case '2 MIN':
      return 2 * 60 * 1000;
    case '3 MIN':
      return 3 * 60 * 1000;
    case '4 MIN':
      return 4 * 60 * 1000;
    case '5 MIN':
      return 5 * 60 * 1000;
    default:
      return 5 * 60 * 1000;
  }
};