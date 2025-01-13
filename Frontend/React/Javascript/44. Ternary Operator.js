let password = 8;

function passwordChecker(ps) {
  // if (ps === 8) return `Strong Password`;
  // else return `Password should be 8 characters.`;
  return ps === 8 ? `Strong Password` : `Password should be 8 characters.`;
}

const res = passwordChecker(password);

// Practice
const money = true;
let msg = money === true ? "Buy Products" : "They should bring money";
console.log(msg);
