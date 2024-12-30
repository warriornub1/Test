// Function with parameter types and return type
function addNumbers(a, b) {
  return a + b;
}
// Arrow function with parameter and return types
var multiplyNumbers = function (a, b) {
  return a * b;
};
// Function with default parameter
function greet(name) {
  if (name === void 0) {
    name = "Guest";
  }
  return "Hello, ".concat(name, "!");
}

// Optional Parameters: Use ? to make parameters optional.
function greet(name?: string): string {
  return name ? `Hello, ${name}!` : "Hello!";
}

// Void Functions: Functions that do not return a value use the void type.

function logMessage(message: string): void {
  console.log(message);
}
