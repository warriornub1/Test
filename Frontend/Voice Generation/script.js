let speech = new SpeechSynthesisUtterance();
let voices = [];
let voiceSelect = document.querySelector("select");
let textarea = document.querySelector("textarea");
let textContainer = document.getElementById("text-container");
let play_button = document.querySelector("#play");
let clear_button = document.querySelector("#clear");

let isPaused = false; // Track whether the speech is paused
let isPlaying = false; // Track whether the speech is currently playing
let language = {};
let allowedLanguageCode = [];

const apiUrl = "http://localhost:5087/Language/";

// // Send GET request
// function getAllowedLanguagesCodes(callback) {
//   fetch(apiUrl + "GetAllLanguages")
//     .then((response) => {
//       if (!response.ok)
//         throw new Error(`HTTP error! Status: ${response.status}`);
//       return response.json();
//     })
//     .then((data) => {
//       allowedLanguageCode = data.map((item) => item.language_Code);
//       console.log("Allowed Language Codes:", allowedLanguageCode);
//       callback();
//     });
// }

// getAllowedLanguagesCodes(() => {
//   // Now you can access allowedLanguageCode outside of fetch
//   console.log("Using allowedLanguageCode outside fetch:", allowedLanguageCode);
// });

const fetchLanguages = async () => {
  const data1 = await fetch(apiUrl + "GetAllLanguages");
  const response1 = await data1.json();
  allowedLanguageCode = response1.map((item) => item.language_Code);
};
fetchLanguages();

function loadVoices() {
  voices = window.speechSynthesis.getVoices();
  voices = voices.filter((voice) =>
    allowedLanguageCode.some((lang) => voice.lang.startsWith(lang))
  );

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

loadVoices();

voiceSelect.addEventListener("change", () => {
  speech.voice = voices[voiceSelect.value];
});

play_button.addEventListener("click", () => {
  // Pause the speech
  if (isPlaying && !isPaused) {
    window.speechSynthesis.pause();
    isPaused = true;
    play_button.textContent = "Play";
  } else if (isPaused) {
    // Resume the speech
    window.speechSynthesis.resume();
    isPaused = false;
    play_button.textContent = "Pause";
  } else {
    // Start speaking
    textarea.style.display = "none";
    textContainer.textContent = textarea.value;
    textContainer.style.display = "block";

    speech.text = textarea.value;
    window.speechSynthesis.speak(speech);
    isPlaying = true;
    play_button.textContent = "Pause";
  }
});

clear_button.addEventListener("click", () => {
  isPaused = false;
  isPlaying = false;
  play_button.textContent = "Play";

  textarea.value = "";
  textarea.style.display = "block";
  textarea.focus();

  textContainer.style.display = "none";
  textContainer.textContent = "";
  window.speechSynthesis.cancel();
});

speech.addEventListener("end", () => {
  isPaused = false;
  isPlaying = false;
  play_button.textContent = "Play";
  textarea.style.display = "block";
  textContainer.style.display = "none";
});

window.addEventListener("beforeunload", () => {
  window.speechSynthesis.cancel();
});

speech.onboundary = (event) => {
  console.log("Boundary triggered:");
  const text = speech.text;
  const boundaryIndex = event.charIndex;

  // Use the correct language for segmentation
  const segmenter = new Intl.Segmenter("zh-Hans", { granularity: "word" });
  const segments = segmenter.segment(text);

  let currentWord = "";
  let before = "";
  let after = "";

  for (const segment of segments) {
    const start = segment.index;
    const end = start + segment.segment.length;

    if (start <= boundaryIndex && boundaryIndex < end) {
      currentWord = segment.segment;
      before = text.slice(0, start);
      after = text.slice(end);
      break;
    }
  }

  // Highlight the current word
  textContainer.innerHTML = `${before}<mark>${currentWord}</mark>${after}`;
};

// Restore original text after speech ends
speech.onend = () => {
  textarea.innerHTML = speech.text;
};
