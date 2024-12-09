/*
function expresion = function without a name (anonymous function)
avoid poplluting the gobal scope with a name
write it, then forget about i
*/

let count = 0;
document.getElementById("increaseButton").onClick = function () {
  count += 1;
};
