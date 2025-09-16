export const formatAmount = (num: number) => {
  if (num >= 1000) {
    return num.toFixed(2); 
  } else {
    return num.toPrecision(4);
  }
};