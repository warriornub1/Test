const fruits = ['apple', 'pear', 'orange']
const berries = ['strawberry', 'blueberry', 'rasberry'];

const allFruits = [fruits, berries] // 2D array

x = fruits.concat(berries)
console.log(x);


x = [...fruits, ...berries]
console.log(x);

// Flatten Arrays
const arr = [1, 2, [3, 4], 5, [6, 7], 8]
x = arr.flat() // [ 1, 2, 3, 4, 5, 6, 7, 8 ]

x = Array.isArray(fruits) // true
x = Array.isArray('Hello') // false

x = Array.from('12345');

const a = 1;
const b = 2;
const c = 3;

x = Array.of(a, b, c);

console.log(x); [1, 2, 3]
