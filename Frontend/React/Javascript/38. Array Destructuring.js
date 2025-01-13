function person(firstName, lastName, ...hobbies) {
  console.log("First Name ", firstName);
  console.log("Last Name", lastName);
  console.log("Hobbies", hobbies);
}

person("HuXn", "WebDev", "programming", "football", "singing");

// Practice
function varadic(...params) {
  console.log(params);
}
console.log("HuXn", "WebDev", 19, 29, ["One"]);
