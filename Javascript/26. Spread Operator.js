/*
spread operator = ... allows an iterable such as an array or string to be exapnded
into seperate elements (unpacks the elements)
*/

let numbers = [1, 2, 3, 4, 5, 6]
let maximum = Math.max(...numbers)
let minimum = Math.min(...numbers)

let username = "Bro Code"
let letters = [...username].join("-")

let fruits = ["apple", "orange", "banana"];
let vegetables = ["carrots", "celery", "potatoes"];
let foods = [...fruits, ...vegetables, "eggs", "milk"];

console.log(maximum);
console.log(minimum);
console.log(letters);

