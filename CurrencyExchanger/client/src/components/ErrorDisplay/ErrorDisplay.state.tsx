import { useError, useLoading } from '../../hooks/useCurrencyService';

export const useErrorDisplayState = () => {
  const isError = useError();
  const isLoading = useLoading();

  const handleRetry = () => {
    window.location.reload();
  };

  return {
    isError,
    isLoading,
    handleRetry,
    shouldDisplayError: isError && !isLoading
  };
};