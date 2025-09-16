"use strict";

export const elements = {
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