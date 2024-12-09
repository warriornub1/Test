/*
array.map() = executes a provided call backfunction
once for each array element
AND creates a new array
*/

let numbers = [1, 2, 3, 4, 5];
let squares = numbers.map(square);

function square(element) {
  return Math.pow(element, 2);
}

function cube(element) {
  return Math.pow(element, 3);
}
