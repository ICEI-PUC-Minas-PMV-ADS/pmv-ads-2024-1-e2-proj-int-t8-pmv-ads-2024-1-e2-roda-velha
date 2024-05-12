window.addEventListener("popstate", function () {
  const url = new URL(window.location);
  const pathName = url.pathname; // Pega o caminho da URL
  console.log("Nova rota detectada:", pathName);

  // Execute ações com base no nome da rota
  if (pathName === "/home") {
    console.log("Você está na página inicial.");
  } else if (pathName === "/sobre") {
    console.log("Página sobre.");
  } else {
    console.log("Outra página visitada.");
  }
});

// ---- Seção de código do switch ----

const switchTextRegister = document.querySelector(".switch-text-register");
const switchTextLogin = document.querySelector(".switch-text-login");
const switchCheckbox = document.querySelector(".switch-checkbox");
const flipImage = document.querySelector(".flip-image-inner");
const flipCard = document.querySelector(".flip-card-inner");

function toggleCard() {
  if (flipCard.style.transform === "rotateY(180deg)") {
    switchTextLogin.style.opacity = "1";
    switchTextRegister.style.opacity = "0.5";
    flipCard.style.transform = "rotateY(0deg)";
    switchCheckbox.checked = false;
    switchCheckbox.focus = false;
    flipImage.style.transform = "rotateY(0deg)";
    return;
  }
  switchTextLogin.style.opacity = "0.5";
  switchTextRegister.style.opacity = "1";
  flipCard.style.transform = "rotateY(180deg)";
  switchCheckbox.checked = true;
  switchCheckbox.focus = true;
  flipImage.style.transform = "rotateY(180deg)";
}

switchTextRegister.addEventListener("click", toggleCard);
switchTextLogin.addEventListener("click", toggleCard);
switchCheckbox.addEventListener("click", toggleCard);

btnRegister.addEventListener("click", register);
