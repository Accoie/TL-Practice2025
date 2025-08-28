"use strict";

import { Diff } from "./Diff.js";

export function calculateDiff(oldValue, newValue) {
  const diff = Diff.calculate(oldValue, newValue);
  
  if (!diff) {
    throw new Error('Не удалось вычислить разницу');
  }
  
  return diff;
}