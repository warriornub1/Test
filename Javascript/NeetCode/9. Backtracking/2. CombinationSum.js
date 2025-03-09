function combinationSum(nums, target){

    let res =[]
    let curr = []

    function dfs( index, total ){

        if(total === target){
            res.push([...curr])
            return
        }
        if(total > target || index >= nums.length)
            return
        
        curr.push(nums[index])
        dfs(index, total + nums[index])
        curr.pop()
        dfs(index + 1, total)

    }

    dfs( 0, 0 )
    return res

}

function combinationSumFor(nums, target){

    let res = []

    function dfs(index, total, curr){
        
        if(total === target){
            res.push([...curr])
            return
        }
        if(index >= nums.length || total > target)
            return

        for(let i = index; i < nums.length; i++){
            curr.push(nums[i])
            dfs(i, total + nums[i], curr)
            curr.pop()
        }

    }
    dfs(0, 0, [])
    return res

}


let nums = [2, 5, 6, 9]
let target = 9
console.log( combinationSumFor(nums, target) )