function BruteForce(nums){

    const res = new Set()
    nums.sort((a, b) => a - b)  

    for(let i = 0; i < nums.length; i++ ){
        for(let j = i + 1; j < nums.length; j++ ){
            for(let g = j + 1; g < nums.length; g++ ){
                if(nums[i] + nums[j] + nums[g] === 0)
                    res.add(JSON.stringify([nums[i], nums[j], nums[g]]));
            }
        }
    }

    return Array.from(res).map(item => JSON.parse(item));
}

function TwoPointers(nums){

    nums.sort((a, b) => a - b )
    const res = []

    for(let i = 0; i < nums.length; i++ ){
        if (nums[i] > 0) break;
        if (i > 0 && nums[i] === nums[i - 1]) continue;

        let j = i + 1;
        let g = nums.length - 1;

        while(j < g){
            let sum = nums[i] + nums[j] + nums[g]
            if(sum == 0){
                res.push([nums[i], nums[j], nums[g]])
                j++
                g--
                while(j < g && nums[j] === nums[j - 1])
                    j++
            }
            else if(sum < 0)
                j++
            else
                g--

        }

    }
    return res

}

console.log( BruteForce([-1,0,1,2,-1,-4]) );


