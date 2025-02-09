let x

const todo = new Object()

todo.id = 1
todo.name = 'Buy Milk'
todo.completed = false

x = todo

console.log(x);

const obj1 = {a : 1, b : 2}
const obj2 = {c : 3, d : 4}
const obj3 = {...obj1, ...obj2}
const obj4 = Object.assign({}, obj1, obj2)
console.log(obj4);

x = Object.keys(todo)
x = Object.keys(todo).length
x = Object.values(todo)
x = Object.entries(todo)
x = todo.hasOwnProperty('age') // false
console.log(x);


