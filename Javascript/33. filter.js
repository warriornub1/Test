/*
.filter() = creates a new array by filtering out elements
*/

let numbers = [1, 2, 3, 4, 5, 6, 7];

let evenNums = numbers.filter(isEven);
let oddNums = numbers.filter(isOdd);

console.log(evenNums);

function isEven(element){
    return element % 2 === 0;
}

function isOdd(element){
    return element % 2 !== 0;
}

//////////////////////////////////////////////

const words = ["apple", "orange", "banana", "kiwi", "coconut"];
const shortWords = words.filter(getShortWords);

console.log(shortWords);

function getShortWords(element){
    return element.length <= 6;
}

