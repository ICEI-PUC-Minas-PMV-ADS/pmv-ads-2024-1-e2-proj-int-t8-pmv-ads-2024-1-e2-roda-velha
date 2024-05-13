// ---- Seção de código do login ----

const slashEyeLoginIcon = document.getElementById("slash-eye");
const password = document.getElementById("password");
const eyeLoginIcon = document.getElementById("eye");

function showLoginPassword() {
  if (password.type === "password") {
    password.type = "text";
    slashEyeLoginIcon.style.visibility = "hidden";
    eyeLoginIcon.style.visibility = "visible";
  } else {
    password.type = "password";
    slashEyeLoginIcon.style.visibility = "visible";
    eyeLoginIcon.style.visibility = "hidden";
  }
}

eyeLoginIcon.addEventListener("click", showLoginPassword);
slashEyeLoginIcon.addEventListener("click", showLoginPassword);
