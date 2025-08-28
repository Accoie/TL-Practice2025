"use strict";

import { elements } from './elements.js';
import { handleFormSubmit, handleLoginSubmit, handleStartButtonClick } from './eventHandlers.js';
import { handleLoginClick, handleLogoutClick } from './uiHandlers.js';

export function setupEventListeners() {
  elements.form.addEventListener('submit', handleFormSubmit);
  elements.loginLink.addEventListener('click', handleLoginClick);
  elements.logoutLink.addEventListener('click', handleLogoutClick);
  elements.submitBtn.addEventListener('click', handleLoginSubmit);
  elements.startButton.addEventListener('click', handleStartButtonClick);
}