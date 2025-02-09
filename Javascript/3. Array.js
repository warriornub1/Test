// Array Literal
const numberss = [12, 45, 33, 29, 39];
const mixed = [12, 'Hello', true, null];

// Array Constructor
const fruitss = new Array('apple', 'grape', 'orange');

// Basic Array Methods
const arr = [34, 55, 95, 20, 15]

arr.push(100) // [ 34, 55, 95, 20, 15, 100 ]

arr.pop() // [ 34, 55, 95, 20, 15 ]

arr.unshift(99) // [ 99, 34, 55, 95, 20, 15 ]

arr.shift() // [ 34, 55, 95, 20, 15 ]

arr.reverse() // [15, 20, 95, 55, 34 ]

x = arr.includes(20) // false

x = arr.indexOf(34) // if found return pos else -1