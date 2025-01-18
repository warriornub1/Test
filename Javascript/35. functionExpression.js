// function expressions = a way to define function as 
//                        values or variables

const numbers = [1, 2, 3, 4, ,5, 6];

const squares = numbers.map(function(element){
    return Math.pow(element, 2);
});

const cubes = numbers.map(function(element){
    return Math.pow(element, 3);
})

const evenNums = numbers.filter(function(element){
    return element % 2 === 0;
})

setTimeout(function() {
    console.log("Goodbye"), 5000;
})