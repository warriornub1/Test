function combinationSum(nums, target){
    let res = []
    let subset = []
    function dfs(i, total){
        if(total == target){
            res.push([...subset])
            return
        }

        if(i >= nums.length || total > target )
            return

        subset.push(nums[i])
        dfs(i, total + nums[i] )
        subset.pop()
        dfs(i + 1, total)
    }

    dfs(0, 0)
    return res;
}


let nums = [2, 5, 6, 9]
let target = 9
console.log( combinationSum(nums, target) )