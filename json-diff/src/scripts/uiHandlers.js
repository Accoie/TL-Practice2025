"use strict";

import { elements } from './elements.js';

export function displayDiffResult(diff) {
  elements.diffResult.innerHTML = diff;
  elements.diffResult.style.display = 'flex';
}

export function hideErrorMessages() {
  elements.errorMessages.forEach(el => {
    el.style.display = 'none';
  });
}

export function handleLoginClick(event) {
  event.preventDefault();
  showLoginScreen();
}

export function handleLogoutClick(event) {
  event.preventDefault();
  resetApplication();
}

export function showLoginScreen() {
  elements.loginForm.style.display = "flex";
  elements.promo.style.display = "none";
  elements.loginLink.style.display = "none";
  elements.logoutLink.style.display = "block";
  elements.loginErrorMessage.style.display = "none";
  elements.usernameInput.style.marginBottom = "40px";
  elements.usernameInput.value = "";
}

export function showWelcomeScreen(username) {
  hideErrorMessages();
  elements.startButton.style.display = "block";
  elements.greetWrapper.style.display = "block";
  elements.greetMessage.textContent = `Hello, ${username}!`;
  elements.loginLink.style.display = "none";
  elements.logoutLink.style.display = "block";
  elements.promo.style.display = "flex";
  elements.loginForm.style.display = "none";
  elements.formWrapper.style.display = "none";
}

export function showFormScreen() {
  elements.promo.style.display = "none";
  elements.loginForm.style.display = "none";
  elements.formWrapper.style.display = "flex";
}

export function resetApplication() {
  elements.loginForm.style.display = "none";
  elements.promo.style.display = "flex";
  elements.loginLink.style.display = "block";
  elements.startButton.style.display = "none";
  elements.logoutLink.style.display = "none";
  elements.greetWrapper.style.display = "none";
  elements.formWrapper.style.display = "none";
  elements.loginErrorMessage.style.display = "none";
  elements.usernameInput.style.marginBottom = "40px";
  elements.textareaOldValue.value = '{ "example1": 123,  "example2": 124,  "example3": 125  }';
  elements.textareaNewValue.value = '{ "example1": 321, "example2":421,"example3":125 }';
  elements.diffResult.textContent = '';

  localStorage.clear();
}

export function showLoginError() {
  elements.loginErrorMessage.style.display = "block";
  elements.usernameInput.style.margin = "0";
}