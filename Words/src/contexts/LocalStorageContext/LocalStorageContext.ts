import { createContext } from 'react';
import type { LocalStorageContextType } from '../../types/LocalStorageContextType';

export const LocalStorageContext = createContext<LocalStorageContextType | undefined>(undefined);