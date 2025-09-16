/* eslint-disable @typescript-eslint/no-explicit-any */
import { useSyncExternalStore } from 'react';
import type { Store } from '../store/Store';

const identity = <TValue>(value: TValue) => value;

export const useStore = <TValue, TResult>(
  store: Store<TValue>,
  select: (state: TValue) => TResult = identity as any
) => useSyncExternalStore(store.subscribe, () => select(store.getSnapshot()));