import { useContext } from 'react';
import { LocalStorageContext } from '../contexts/LocalStorageContext/LocalStorageContext';

export const useLocalStorageWords = () => {
  const context = useContext(LocalStorageContext);
  
  if (context === undefined) {
    throw new Error('useLocalStorageWords must be used within a LocalStorageProvider');
  }
  
  return context;
};