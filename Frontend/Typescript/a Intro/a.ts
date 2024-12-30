// Declare a variable with a type
let myVariable: number = 10; // TypeScript ensures this is always a number
const myConstant: number = 20; // TypeScript ensures this is always a number

// Static typing prevents errors
let myDynamicVariable: string = "Hello";
// myDynamicVariable = 42; // Error: Type 'number' is not assignable to type 'string'
let age: number = 24;
const pi: number = 3.142;
let variable: number | string;

variable = "Hello, TypeScript!";
console.log(`Variable as a string: ${variable}`);

variable = 42;
console.log(`Variable as a number: ${variable}`);
