// .reduce() = reduce the elements 
//             to a single value

const prices = [5, 30, 10, 25, 15, 20];

const total = prices.reduce(sum);

console.log( `${total.toFixed(2)}` );

function Sum(accumulator, element){
    return accumulator + element;
}

function getMax(accumulator, element){
    return Math.max(accumulator, element);
}

function getMin(accumulator, element){
    return Math.min(accumulator, element);
}