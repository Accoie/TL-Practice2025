"use strict";

import { Diff } from "./Diff.js";

const elements = {
  form: document.querySelector('.form'),
  textareaOldValue: document.querySelector('.old-json'),
  textareaNewValue: document.querySelector('.new-json'),
  pre: document.querySelector('pre'),
  diffResult: document.querySelector('.diff-result'),
  loginLink: document.querySelector('.login-link'),
  logoutLink: document.querySelector('.logout-link'),
  loginForm: document.querySelector('.login'),
  promo: document.querySelector('.promo'),
  startButton: document.querySelector('.start-button'),
  greetWrapper: document.querySelector('.greet-wrapper'),
  formWrapper: document.querySelector('.form-wrapper'),
  greetMessage: document.querySelector('.greet-message'),
  usernameInput: document.getElementById('username'),
  submitBtn: document.getElementById('submitBtn'),
  errorMessages: document.querySelectorAll('.diff-error-message'),
  loginErrorMessage: document.querySelector('.login-error-message')
};

function setupEventListeners() {
  elements.form.addEventListener('submit', handleFormSubmit);
  elements.loginLink.addEventListener('click', handleLoginClick);
  elements.logoutLink.addEventListener('click', handleLogoutClick);
  elements.submitBtn.addEventListener('click', handleLoginSubmit);
  elements.startButton.addEventListener('click', handleStartButtonClick);
}

function handleFormSubmit(event) {
  event.preventDefault();
  
  try {
    validateJsonInputs();
    const { oldValue, newValue } = parseJsonInputs();
    const diff = calculateDiff(oldValue, newValue);
    displayDiffResult(diff);
    hideErrorMessages();
  } catch (error) {
    showErrorMessages();
    hideDiffResult();
  }
}

function validateJsonInputs() {
  if (!elements.textareaOldValue.value.trim() || !elements.textareaNewValue.value.trim()) {
    throw new Error('Оба JSON должны быть заполнены');
  }
}

function parseJsonInputs() {
  const oldValue = JSON.parse(elements.textareaOldValue.value);
  const newValue = JSON.parse(elements.textareaNewValue.value);
  
  if (typeof oldValue !== 'object' || typeof newValue !== 'object' || 
      oldValue === null || newValue === null) {
    throw new Error('Введите валидные JSON объекты');
  }
  
  return { oldValue, newValue };
}

function calculateDiff(oldValue, newValue) {
  const diff = Diff.calculate(oldValue, newValue);
  
  if (!diff) {
    throw new Error('Не удалось вычислить разницу');
  }
  
  return diff;
}

function displayDiffResult(diff) {
  elements.diffResult.innerHTML = diff;
  elements.diffResult.style.display = 'flex';
}

function hideDiffResult() {
  elements.diffResult.style.display = 'none';
}

function showErrorMessages() {
  elements.errorMessages.forEach(el => {
    el.style.display = 'block';
  });
}

function hideErrorMessages() {
  elements.errorMessages.forEach(el => {
    el.style.display = 'none';
  });
}

function handleLoginClick(event) {
  event.preventDefault();
  showLoginScreen();
}

function handleLogoutClick(event) {
  event.preventDefault();
  resetApplication();
}

function handleLoginSubmit(event) {
  event.preventDefault();
  
  const username = elements.usernameInput.value.trim();
  
  if (!username) {
    showLoginError();
    return;
  }
  
  saveUser(username);
  showWelcomeScreen(username);
}

function handleStartButtonClick(event) {
  event.preventDefault();
  showFormScreen();
}

function showLoginScreen() {
  elements.loginForm.style.display = "flex";
  elements.promo.style.display = "none";
  elements.loginLink.style.display = "none";
  elements.logoutLink.style.display = "block";
  elements.loginErrorMessage.style.display = "none";
  elements.usernameInput.style.marginBottom = "40px";
  elements.usernameInput.value = "";
}

function showWelcomeScreen(username) {
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

function showFormScreen() {
  elements.promo.style.display = "none";
  elements.loginForm.style.display = "none";
  elements.formWrapper.style.display = "flex";
}

function resetApplication() {
  elements.loginForm.style.display = "none";
  elements.promo.style.display = "flex";
  elements.loginLink.style.display = "block";
  elements.startButton.style.display = "none";
  elements.logoutLink.style.display = "none";
  elements.greetWrapper.style.display = "none";
  elements.formWrapper.style.display = "none";
  elements.loginErrorMessage.style.display = "none";
  elements.usernameInput.style.marginBottom = "40px";
  elements.textareaOldValue.value = '{ "text": 123,  "textw": 124,  "texts": 125  }';
  elements.textareaNewValue.value = '{ "text": 321, "textw":421,"texts":125 }';
  elements.diffResult.textContent = '';

  localStorage.clear();
}

function showLoginError() {
  elements.loginErrorMessage.style.display = "block";
  elements.usernameInput.style.margin = "0";
}

function saveUser(username) {
  localStorage.setItem('savedUsername', username);
}

function loadSavedUser() {
  return localStorage.getItem('savedUsername');
}

function initializeApplication() {
  setupEventListeners();
  resetApplication();
  elements.startButton.style.display = "none";
  elements.loginForm.style.display = "none";
  elements.formWrapper.style.display = "none";
  
  const savedUser = loadSavedUser();
  if (savedUser) {
    showWelcomeScreen(savedUser);
  }
}

document.addEventListener('DOMContentLoaded', initializeApplication);