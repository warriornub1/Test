let speech = new SpeechSynthesisUtterance();
let voices = [];
let voiceSelect = document.querySelector("select");
let textarea = document.querySelector("textarea");
let textContainer = document.getElementById("text-container");
let button = document.querySelector("button");

let isPaused = false; // Track whether the speech is paused
let isPlaying = false; // Track whether the speech is currently playing

function loadVoices() {
  voices = window.speechSynthesis.getVoices();
  if (voices.length) {
    speech.voice = voices[0];
    voiceSelect.innerHTML = ""; // Clear existing options
    voices.forEach((voice, i) => {
      voiceSelect.options[i] = new Option(voice.name, i);
    });
  } else {
    // If voices are not available yet, retry after a short delay
    setTimeout(loadVoices, 100);
  }
}

// Call loadVoices to initialize the voice list
loadVoices();

voiceSelect.addEventListener("change", () => {
  speech.voice = voices[voiceSelect.value];
});

button.addEventListener("click", () => {
  // Pause the speech
  if (isPlaying && !isPaused) {
    window.speechSynthesis.pause();
    isPaused = true;
    button.textContent = "Play";
  } else if (isPaused) {
    // Resume the speech
    window.speechSynthesis.resume();
    isPaused = false;
    button.textContent = "Pause";
  } else {
    // Start speaking
    textarea.style.display = "none";
    textContainer.textContent = textarea.value;
    textContainer.style.display = "block";

    speech.text = textarea.value;
    window.speechSynthesis.speak(speech);
    isPlaying = true;
    button.textContent = "Pause";
  }
});

speech.addEventListener("end", () => {
  let isPaused = false;
  let isPlaying = false;
  button.textContent = "Play";
  textarea.style.display = "block";
  textContainer.style.display = "none";
});

window.addEventListener("beforeunload", () => {
  window.speechSynthesis.cancel();
});

// Highlight text as it is spoken
speech.onboundary = (event) => {
  const text = speech.text;
  const boundaryIndex = event.charIndex;
  const before = text.slice(0, boundaryIndex);
  const currentWord = text.slice(boundaryIndex).split(" ")[0];
  const after = text.slice(boundaryIndex + currentWord.length);

  // Highlight the current word
  textarea.innerHTML = `${before}<mark>${currentWord}</mark>${after}`;
};

// Restore original text after speech ends
speech.onend = () => {
  textarea.innerHTML = speech.text;
};
