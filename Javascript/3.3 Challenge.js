// CHALLENGE 1
const arr = [1, 2, 3, 4, 5]
x = arr.reverse()
x.push(0)
x.unshift(6)
console.log(x);

// CHALLENGE 2
const arr1 = [1, 2, 3, 4, 5]
const arr2 = [5, 6, 7, 8, 9, 10]
console.log(arr1.slice(0, 4).concat(arr2));

let arr3 = [...arr1, ...arr2]
arr3.splice(4, 1)
console.log(arr3);
