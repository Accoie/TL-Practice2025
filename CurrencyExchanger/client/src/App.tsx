import './App.css';
import { CurrencyExchanger } from './components/CurrencyExchanger/CurrencyExchanger';
import { ErrorDisplay } from './components/ErrorDisplay/ErrorDisplay.view.tsx';
import { LoadingDisplay } from './components/LoadingDisplay/LoadingDisplay.view.tsx';

function App() {
  return (
    <>
      <ErrorDisplay></ErrorDisplay>
      <LoadingDisplay></LoadingDisplay>
      <CurrencyExchanger></CurrencyExchanger>
    </>
  );
}

export default App;
