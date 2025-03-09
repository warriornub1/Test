function BruteForce(nums, target){

    for(let i = 0; i < nums.length; i++){
        for(let j = i + 1; j < nums.length; j++){
            
            if(nums[i] + nums[j] == target)
                return [i, j]
        }
    }
}

function BinarySearch(nums, target){

    for(let index = 0; index < nums.length; index++){
        
        let diff = target - nums[index]
        let i = index + 1;
        let j = nums.length - 1;

        while(i < j){

            let mid = Math.floor( (j - i) / 2) 
            if(nums[mid] === diff)
                return[index, mid]

            else if(nums[mid] < diff)
                i = mid + 1
            else
                j = mid - 1;
        }

    }
}

function TowPointer(nums, target){

    let i = 0; let j = nums.length - 1;

    while( i < j ){

        let sum = nums[i] + nums[j]
        if(sum == target)
            return [i, j]

        else if(sum < target)
            i++;
        else
            j--;

    }

}

console.log( BruteForce([1, 2, 3, 4], 3) )
console.log( BinarySearch([1, 2, 3, 4], 3) )
console.log( TowPointer([1, 2, 3, 4], 3) )