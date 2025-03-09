function BruteForce(nums){
    let res = new Array(nums.length).fill(1)

    for(let i = 0; i < nums.length; i++){
        for(let j = 0; j < nums.length; j++){
            
            if(i != j)
                res[i] *= nums[j]

        }
    }
    return res    
}

function productExceptSelf(nums){

    const n = nums.length
    const res = new Array(n).fill(1)

    for(let i = 1; i < n; i++){
        res[i] = res[i - 1] * nums[i - 1]
    }

    let temp = 1
    for(let i = n - 1; i >= 0; i--){
        res[i] *= temp
        temp *= nums[i]
    }

    return res;

}

console.log( productExceptSelf([1, 2, 4, 6]) )