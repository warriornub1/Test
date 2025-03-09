function Subsets(numbers){

    let res = []
    let temp = []

    function dfs(index){

        if(index >= numbers.length){
            res.push([...temp])
            return
        }

        temp.push(numbers[index])
        dfs(index + 1)
        temp.pop()
        dfs(index + 1)
    }
    dfs(0)
    return res
}

function Subsets1(nums) {
    
    let res = [[]]

    for(let num of nums){
        let size = res.length
        for(let i = 0; i < size; i++){
            let subset = res[i].slice();
            subset.push(num)
            res.push(subset);
        }
    }

    return res
}

console.log(Subsets1([1,2,3]));