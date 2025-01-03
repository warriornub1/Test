/*
rest parameters = represents an indefinite number
                  of paraters
                  (packs arguments into an array)
*/

let a = 1;
let b = 2;
let c = 3;
let d = 4;
let e = 5;

console.log(sum(a, b, c, d, e));

function sum(...numbers) {
  let total = 0;
  for (let number of numbers) {
    total += number;
  }
  return total;
}

function sum1(x, y, ...numbers) {
  let total = 0;
  for (let number of numbers) {
    total += number;
  }
  return total;
}

// Create a Function to Find the Largest Number
function findLargest(...number) {
  let max = 0;
  for (let number of numbers) if (number > max) max = number;
  return max;
}

// Combine and Sort Names
function combineNames(greetings, ...names) {
  const sortedNames = names.sort();
  return `${greetings} ${sortedNames.join(",")}`;
}
