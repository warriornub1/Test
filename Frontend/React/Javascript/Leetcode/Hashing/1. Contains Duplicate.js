const BruteForce = (nums) => {
  for (let i = 0; i < nums.length; i++) {
    for (let j = i + 1; j < nums.length; j++) {
      if (nums[i] == nums[j]) return true;
    }
  }
  return false;
};

const Sorting = (nums) => {
  nums.sort((a, b) => a - b);
  for (let i = 1; i < nums.length; i++) {
    if (nums[i] == nums[i - 1]) return true;
  }
  return false;
};

const Hashset = (nums) => {
  const seen = new Set();
  for (const num of nums) {
    if (seen.has(num)) return true;
    seen.add(num);
  }
  return false;
};

const HashsetLength = (nums) => {
  return new Set(nums).size < nums.length;
};

nums = [1, 2, 3, 3]; // true
num1s = [1, 2, 3, 4]; // false

console.log(BruteForce(nums));
console.log(BruteForce(num1s));
