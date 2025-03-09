function Sorting(num, k){
    const count = {}
    for(const num of nums){
        count[num] = (count[num] || 0) + 1
    }

    const arr = Object.entries(count).map(([num, freq]) => [freq, parseInt(num)]);
    arr.sort((a, b) => b[0] - a[0]);

    return arr.slice(0, k).map(pair => pair[1]);
}

function Heap(num, k){
    const count = {}
    for(const num of nums){
        count[num] = (count[num] || 0) + 1
    }

    const heap = new MinPriorityQueue(x => x[1]);
    for(const [num, cnt] of Object.entries(count)){
        heap.enqueue([num, cnt]);
        if (heap.size() > k) heap.dequeue();
    }

    const res = [];
    for(let i = 0; i < k; i++) {
        const [num, cnt] = heap.dequeue();
        res.push(num)
    }
    return res; 

}

function bucketSort(nums, k){

    const keys = Array.from( {length :  nums.length + 1 }, ()=> [] )
    const hashmap = {}

    for(let num of nums){
        hashmap[num] = ( hashmap[num] || 0 ) + 1;
    }

    for(var key in hashmap){
        keys[ hashmap[key] ].push(key)
    }

    let res = []
    for(let i = keys.length - 1; i > 0; i-- ){
        if(keys[i].length > 0){
            
            for(let j = 0; j < keys[i].length; j++){
                res.push(keys[i][j])
                if(res.length == k)
                    return res
            }
        }
    }

}

console.log(bucketSort(nums = [4,5,5,5,6,6], k = 2));