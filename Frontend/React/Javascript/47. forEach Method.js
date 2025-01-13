const colors = ["tea", "blue", "red", "green"];
colors.forEach((color) => console.log(color));

const capWords = colors.forEach((word, index, arr) => {
  arr[index] = word[0].toUpperCase() + word.substring(1);
});

// Practice
let numbers = [1, 2, 3, 4, 5];
let sum = 0;
numbers.forEach((number) => {
  sum += number;
});
console.log(sum);
