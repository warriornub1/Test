// Brute Force
function twoSum(nums, target) {
  for (let i = 0; i < nums.length; i++) {
    for (let j = i + 1; j < nums.length; j++) {
      if (nums[i] + nums[j] == target) return [i, j];
    }
  }
  return [];
}

//HashMap one pass
function twoSum2(nums, target) {
  const map = new Map();
  for (let i = 0; i < nums.length; i++) {
    const diff = target - nums[i];
    if (map.has(diff)) return [i, map.get(diff)];
    else map.set(nums[i], i);
  }
  return [];
}

console.log(twoSum((nums = [3, 4, 5, 6]), (target = 7)));
console.log(twoSum2((nums = [3, 4, 5, 6]), (target = 7)));
