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

export function cleanupEventListeners() {
  elements.form.removeEventListener('submit', handleFormSubmit);
  elements.loginLink.removeEventListener('click', handleLoginClick);
  elements.logoutLink.removeEventListener('click', handleLogoutClick);
  elements.submitBtn.removeEventListener('click', handleLoginSubmit);
  elements.startButton.removeEventListener('click', handleStartButtonClick);
}