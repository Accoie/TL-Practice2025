import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.tsx";
import { BrowserRouter } from "react-router-dom";
import { LocalStorageProvider } from "./contexts/LocalStorageContext/LocalStorageProvider.tsx";


createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <BrowserRouter>
      <LocalStorageProvider>
          <App />
      </LocalStorageProvider>
    </BrowserRouter>
  </StrictMode>
);
