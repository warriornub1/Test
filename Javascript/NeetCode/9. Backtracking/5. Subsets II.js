function BruteForce(nums, target){
    
    let res = new Set()
    nums.sort((a, b) => a - b)

    function dfs(i, curr){
        if(i >= nums.length){
            res.add(JSON.stringify(curr))
            return
        }

        curr.push(nums[i])
        dfs(i + 1, curr)
        curr.pop()
        dfs(i + 1, curr)

    }
    dfs(0, [])
    console.log(res);
    return Array.from(res, num => JSON.parse(num))
}

function combinationSum(nums, target){
    let res = []
    nums.sort((a, b) => a - b)

    function dfs(index, curr){
        if(index >= nums.length){
            res.push([...curr])
            return
        }

        curr.push(nums[index])
        dfs(index + 1, curr)
        curr.pop()
        while(nums[index] == nums[index + 1] && index < nums.length)
            index++

        dfs(index + 1, curr)
        
    }
    dfs(0, [])
    console.log(res)
    return res
}

BruteForce([1,2,1])