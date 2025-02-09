const firstName = 'John'
const lastName = 'Doe'
const age = 30

const person = {
    firstName,
    lastName,
    age,
    user: {
        name: 'John'
    }
}

const {firstName, lastname, user : {name}} = person

// Destructure arrays
const numbers = [23, 67, 33, 49]

const [first, second, ...rest] = numbers

console.log(first, second);
