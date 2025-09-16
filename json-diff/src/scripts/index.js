"use strict";

import { elements } from './elements.js';
import { setupEventListeners } from './eventListeners.js';
import { resetApplication, showWelcomeScreen } from './uiHandlers.js';
import { loadSavedUser } from './localStorage.js';

function initializeApplication() {
  setupEventListeners();
  
  const savedUser = loadSavedUser();
  if (savedUser) {
    showWelcomeScreen(savedUser);
  } else {
    resetApplication();
    elements.startButton.style.display = "none";
    elements.loginForm.style.display = "none";
    elements.formWrapper.style.display = "none";
  }
}

document.addEventListener('DOMContentLoaded', initializeApplication);