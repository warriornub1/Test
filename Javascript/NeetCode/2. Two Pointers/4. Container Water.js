BruteForce = (nums) => {
    let maxWater = 0
    for(let l = 0; l < nums.length; l++){

        for(let r = nums.length - 1; r > l; r--){
            let area = (r - l) * Math.min(nums[r], nums[l])
            maxWater = Math.max(area, maxWater)
        }
    }
    console.log(maxWater);
    
    return maxWater
}

TwoPointers = (nums) => {
    let maxWater = 0
    let l = 0
    let r = nums.length - 1

    while(l < r){
        let area = (r - l) * Math.min(nums[r], nums[l])
        maxWater = Math.max(area, maxWater)
        if(nums[l] <= nums[r])
            l++
        else
            r--
    }
    console.log(maxWater);
    
}

TwoPointers([1,7,2,5,4,7,3,6])