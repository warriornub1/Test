function permute1(nums) {

    let res = []

    function dfs(curr){
        if(curr.length === nums.length){
            res.push([...curr])
            return
        }

        for(let i = 0; i < nums.length; i++){
            if(!curr.includes(nums[i])){
                curr.push(nums[i])
                dfs(curr)
                curr.pop()
            }    
        }
    }

    dfs([])
    console.log(res);
    return res
}

function permute2(nums){

    if(nums.length === 0)
        return [[]]

    let res = []

    let perms = permute2(nums.slice(1))
    for(let perm of perms){
        for(let i = 0; i <= perm.length; i++ ){
            let p_copy = perm.slice()
            p_copy.splice(i, 0, nums[0])
            res.push(p_copy)
        }
    }

    return res    
}

permute2([1, 2, 3])

