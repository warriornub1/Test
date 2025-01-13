// for (variable in iterable) {...}

let person = {
  name: "HuXn",
  age: 19,
  gender: "male",
};

for (let keys in person) {
  console.log(keys, person[keys]);
}

let list = ["one", "two", "three", "four"];

for (let index in list) {
  console.log(`${index}: ${list[index]}`);
}

// Iterae over object & log the property and the value of that object using for in loop.
const object = { a: 1, b: 2, c: 3 };
for (let key in object) {
  console.log(`${key}: ${object[key]}`);
}
