import { getColor } from "./getColor";

export const getTickColor = (tick: number, value: number): string | undefined => {
    const initialValueConst = 6;

    if (value === initialValueConst) {
      return getColor(tick);
    }
    if (tick > value) {
      return getColor(initialValueConst);
    }
    if (tick < value) {
      return getColor(value);
    }
}