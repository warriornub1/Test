// charCodeAt() Unicode values are integers representing characters in the Unicode standard.
/*
const str = "Hello";
console.log(str.charCodeAt(0)); // 72 ('H')
console.log(str.charCodeAt(1)); // 101 ('e')
console.log(str.charCodeAt(4)); // 111 ('o')
*/

function groupAnagrams(strs) {
  let hashmap = {};
  for (let word of strs) {
    let key = word.split("").sort().join("");
    if (!hashmap[key]) {
      hashmap[key] = [];
    }
    hashmap[key].push(word);
  }
  return Object.values(hashmap);
}

function groupAnagrams1(strs) {
  const map = {};
  for (let word of strs) {
    const key = new Array(26).fill(0);
    for (let s of word) {
      key[s.charCodeAt(0) - "a".charCodeAt(0)] += 1;
    }
    if (!map[key]) map[key] = [];
    map[key].push(word);
    return Object.values(map);
  }
}

let result = groupAnagrams(["act", "pots", "tops", "cat", "stop", "hat"]);
let result1 = groupAnagrams(["act", "pots", "tops", "cat", "stop", "hat"]);

result.forEach(print);
result1.forEach(print);

function print(element) {
  console.log(element);
}
