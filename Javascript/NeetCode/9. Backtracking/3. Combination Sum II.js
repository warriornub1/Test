function bruteForce(nums, target){
    let res = new Set()
    let curr = []
    nums.sort((a, b) => a - b)
    function dfs( index, total ){

        if(total === target){
            res.add( JSON.stringify( [...curr] ) )
            return
        }
        if(total > target || index >= nums.length)
            return
        curr.push(nums[index])
        dfs(index + 1, total + nums[index])
        curr.pop()
        dfs(index + 1, total)
    }

    dfs(0, 0)
    console.log( Array.from( res,  value => JSON.parse(value)) );
    
}

function combinationSum(nums, target){

    let res =[]
    let curr = []
    nums.sort((a, b) => a- b)

    function dfs( index, total ){

        if(total === target){
            res.push([...curr])
            return
        }
        if(total > target || index >= nums.length)
            return
        
        curr.push(nums[index])
        dfs(index + 1, total + nums[index])
        curr.pop()
        while(nums[index] === nums[index + 1] && index < nums.length)
            index++;
        dfs(index + 1, total)

    }

    dfs( 0, 0 )
    console.log(res);
    
    return res

}

bruteForce([9,2,2,4,6,1,5], 8)