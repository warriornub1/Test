
function BruteForce(nums){
    for(let i = 0; i < nums.length; i++){
        for(let j = i + 1; j < nums.length; j++){
            if(nums[i] === nums[j])
                return true;
        }
    }
    return false;
}

function Sorting(nums){
    nums.sort((a, b)  => (a - b));
    for(let i = 1; i < nums.length i++){
        if(nums[i] === nums[i - 1])
        return true;
    }
    return false;
}

function HashSet(nums){
    const seen = new Set();
    for(const num of nums){
        if(seen.has(nums)){
            return true;
        }
        seen.add(num);
    }
    return false;
}

function HashSetLength(nums){
    return new Set(nums).size < nums.length;
}