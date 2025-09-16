"use strict";

export function saveUser(username) {
  localStorage.setItem('savedUsername', username);
}

export function loadSavedUser() {
  return localStorage.getItem('savedUsername');
}