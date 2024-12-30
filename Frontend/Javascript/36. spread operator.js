// a. Combine Arrays
const arr1 = [1, 2, 3];
const arr2 = [4, 5, 6];
const combined = [...arr1, ...arr2];
console.log(combined); // Output: [1, 2, 3, 4, 5, 6]

// b. Clone Arrays
const original = [1, 2, 3];
const clone = [...original];
console.log(clone); // Output: [1, 2, 3]
console.log(clone === original); // Output: false (different memory references)

// c. Expand Arrays into Function Arguments
const numbers = [1, 2, 3];
console.log(Math.max(...numbers)); // Output: 3

// d. Clone Objects
const original1 = { a: 1, b: 2 };
const clone1 = { ...original };
console.log(clone1); // Output: { a: 1, b: 2 }
console.log(clone1 === original1); // Output: false (different memory references)

// e. Merge Objects
const obj1 = { a: 1, b: 2 };
const obj2 = { b: 3, c: 4 };
const merged = { ...obj1, ...obj2 };
console.log(merged); // Output: { a: 1, b: 3, c: 4 }

// f. Spread Operator in Function Calls
function sum(x, y, z) {
  return x + y + z;
}
const numbers1 = [1, 2, 3];
console.log(sum(...numbers1)); // Output: 6

// Immutable Updates: Updating arrays or objects immutably
const state = { name: "Alice", age: 25 };
const updatedState = { ...state, age: 26 };
console.log(updatedState); // Output: { name: 'Alice', age: 26 }

// Array Flattening
const nested = [1, [2, 3], [4, 5]];
const flat = [...nested[0], ...nested[1], ...nested[2]];
console.log(flat); // Output: [1, 2, 3, 4, 5]

// Practice
const nestedArray = [[1, 2], [3, 4], [5]];
console.log(...nestedArray[0], ...nestedArray[1], ...nestedArray[2]);
