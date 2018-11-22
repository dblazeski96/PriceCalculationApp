import { IValidationResult } from "../models/Values/IValidationResult";

export const validateEmail = (email: string): IValidationResult => {
  switch (true) {
    case email === "":
      return {
        isValid: false,
        errorMsg: "Required *"
      };

    case !email.includes("@"):
      return {
        isValid: false,
        errorMsg: "Please enter a valid email address"
      };

    default:
      return {
        isValid: true,
        errorMsg: null
      };
  }
};

export const validatePassword = (password: string): IValidationResult => {
  switch (true) {
    case password === "":
      return {
        isValid: false,
        errorMsg: "Required *"
      };

    case password.length < 8:
      return {
        isValid: false,
        errorMsg: "Password must be at least 8 characters long"
      };

    default:
      return {
        isValid: true,
        errorMsg: null
      };
  }
};
