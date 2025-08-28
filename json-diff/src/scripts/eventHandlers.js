"use strict";

import { elements } from "./elements.js";
import { calculateDiff } from "./diffValidate.js";
import {
  displayDiffResult,
  hideErrorMessages,
  showWelcomeScreen,
  showFormScreen,
  showLoginError
} from "./uiHandlers.js";
import { saveUser } from "./localStorage.js";

export function handleFormSubmit(event) {
  event.preventDefault();

  const oldJson = elements.textareaOldValue.value.trim();
  const newJson = elements.textareaNewValue.value.trim();

  if (!oldJson) {
    showValidationError("inputErrorMessage1", "parseErrorMessage1");
    return;
  }

  if (!newJson) {
    hideValidationErrors();
    showValidationError("inputErrorMessage2", "parseErrorMessage2");
    return;
  }

  let oldValue, newValue;
  
  try {
    oldValue = JSON.parse(oldJson);
  } catch (error) {
    hideValidationErrors();
    showParseError("parseErrorMessage1");
    return;
  }

  try {
    newValue = JSON.parse(newJson);
  } catch (error) {
    hideValidationErrors();
    showParseError("parseErrorMessage2");
    return;
  }

  const diff = calculateDiff(oldValue, newValue);
  displayDiffResult(diff);
  hideErrorMessages();
}

export function handleLoginSubmit(event) {
  event.preventDefault();

  const username = elements.usernameInput.value.trim();

  if (!username) {
    showLoginError();
    return;
  }

  saveUser(username);
  showWelcomeScreen(username);
}

export function handleStartButtonClick(event) {
  event.preventDefault();
  showFormScreen();
}

function showValidationError(inputErrorId, parseErrorId) {
  elements.diffResult.style.display = "none";
  document.getElementById(inputErrorId).style.display = "block";
  document.getElementById(parseErrorId).style.display = "none";
}

function showParseError(parseErrorId) {
  elements.diffResult.style.display = "none";
  document.getElementById(parseErrorId).style.display = "block";
}

function hideValidationErrors() {
  const errorIds = [
    "inputErrorMessage1", "inputErrorMessage2",
    "parseErrorMessage1", "parseErrorMessage2"
  ];
  
  errorIds.forEach(id => {
    document.getElementById(id).style.display = "none";
  });
}