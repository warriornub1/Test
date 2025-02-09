let fruits = ["apple", "banana", "cherry", "date"];
let slicedFruits = fruits.slice(1, 3); // ["banana", "cherry"]

let numbers = [1, 2, 3, 4, 5];
let removed = numbers.splice(2, 2);

// You can replace elements in an array by specifying the index, the number of elements to remove, and the new elements to insert.

console.log(removed);  // [3, 4] (removed elements)
console.log(numbers);  // [1, 2, 5] (modified original array)

let colors = ["red", "blue", "green"];
colors.splice(1, 0, "yellow", "purple"); // ["red", "yellow", "purple", "blue", "green"]

let items = ["a", "b", "c", "d"];
items.splice(1, 2, "x", "y"); // [ 'a', 'x', 'y', 'd' ]