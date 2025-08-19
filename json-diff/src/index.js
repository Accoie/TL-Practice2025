"use strict";

import { Diff } from "./Diff.js";

const form = document.querySelector(`.form`);
const textareaOldValue = document.querySelector('.old-json');
const textareaNewValue = document.querySelector('.new-json');
const pre = document.querySelector('pre');

form.addEventListener('submit', (event) => {
  event.preventDefault();
  
  try {
    if (!textareaOldValue.value.trim() || !textareaNewValue.value.trim()) {
      throw new Error('Оба JSON должны быть заполнены');
    }

    const oldValue = JSON.parse(textareaOldValue.value);
    const newValue = JSON.parse(textareaNewValue.value);
    
    if (typeof oldValue !== 'object' || typeof newValue !== 'object' || oldValue === null || newValue === null) {
      throw new Error('Введите валидные JSON объекты');
    }

    const diff = Diff.calculate(oldValue, newValue);
    

    if (!diff) {
      throw new Error('Не удалось вычислить разницу');
    }

    document.querySelector('.diff-result').innerHTML = diff;
    document.querySelector('.diff-result').style.display = 'flex';
    document.querySelectorAll('.diff-error-message').forEach(el => {
  el.style.display = 'none';
});
  } catch (error) {
    document.querySelectorAll('.diff-error-message').forEach(el => {
  el.style.display = 'block';
});

    document.querySelector('.diff-result').style.display = 'none';
    console.error('Ошибка при сравнении JSON:', error);
  }
});

document.querySelector(".login__link").addEventListener("click", (e) => {
  e.preventDefault();
  document.querySelector(".login").style.display = "flex";
  document.querySelector(".promo").style.display = "none";
  document.querySelector(".login__link").style.display = "none";
  document.querySelector(".logout__link").style.display = "block";
  document.querySelector('.login-error-message').style.display = "none";
  document.getElementById('username').style.marginBottom = "40px";
});

document.querySelector(".logout__link").addEventListener("click", (e) => {
  e.preventDefault();
  document.querySelector(".login").style.display = "none";
  document.querySelector(".start-button").style.display = "none";
  document.querySelector(".promo").style.display = "flex";
  document.querySelector(".login__link").style.display = "block";
  document.querySelector(".logout__link").style.display = "none";
  document.querySelector('.login-error-message').style.display = "none";
  document.getElementById('username').style.marginBottom = "40px";
});

document.querySelector(".logged__link").addEventListener("click", (e) => {
  e.preventDefault();
  document.querySelector(".login").style.display = "none";
  document.querySelector(".promo").style.display = "flex";
  document.querySelector(".login__link").style.display = "block";
  document.querySelector(".logout__link").style.display = "none";
  document.querySelector(".start-button").style.display = "none";
  document.querySelector(".logged__link").style.display = "none";
  document.querySelector(".greet__wrapper").style.display = "none";
  document.querySelector(".form-wrapper").style.display = "none";
  document.querySelector('.login-error-message').style.display = "none";
  document.getElementById('username').style.marginBottom = "40px";

  localStorage.clear();
});

document.addEventListener('DOMContentLoaded', function() {
  const savedUser = localStorage.getItem('savedUsername');
  document.querySelector(".start-button").style.display = "none";
  document.querySelector(".login").style.display = "none";
  document.querySelector(".form-wrapper").style.display = "none";
  if (savedUser) {
    showWelcomeScreen(savedUser);
  }
});

document.getElementById('submitBtn').addEventListener('click', function(event) {
  event.preventDefault();
  
  const username = document.getElementById('username').value.trim();
 
  if(!username)
  {
    document.querySelector('.login-error-message').style.display = "block";
    document.getElementById('username').style.margin = "0";
    return;
  }
  localStorage.setItem('savedUsername', username);
  
  showWelcomeScreen(username);
});

document.querySelector('.start-button').addEventListener('click', function(event){
  event.preventDefault();
  document.querySelector(".promo").style.display = "none";
  document.querySelector(".login").style.display = "none";
  document.querySelector(".form-wrapper").style.display = "flex";
})

function showWelcomeScreen(username) {
  document.querySelectorAll('.diff-error-message').forEach(el => {
  el.style.display = 'none';
});
  document.querySelector(".start-button").style.display = "block";
  document.querySelector(".greet__wrapper").style.display = "block";
  document.querySelector(".greet-message").textContent = `Hello, ${username}!`;
  document.querySelector(".login__link").style.display = "none";
  document.querySelector(".logout__link").style.display = "none";
  document.querySelector(".logged__link").style.display = "block";
  document.querySelector(".promo").style.display = "flex";
  document.querySelector(".login").style.display = "none";
  document.querySelector(".form-wrapper").style.display = "none";
}


