// Declare a variable with a type
var myVariable = 10; // TypeScript ensures this is always a number
var myConstant = 20; // TypeScript ensures this is always a number
// Static typing prevents errors
var myDynamicVariable = "Hello";
// myDynamicVariable = 42; // Error: Type 'number' is not assignable to type 'string'
var age = 24;
var pi = 3.142;
var variable;
variable = "Hello, TypeScript!";
console.log("Variable as a string: ".concat(variable));
variable = 42;
console.log("Variable as a number: ".concat(variable));
