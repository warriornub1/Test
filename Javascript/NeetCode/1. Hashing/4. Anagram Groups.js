function Sorting(strs){
    const res = {};
    for(let s of strs){
        const sortedS = s.split('').sort().join('');
        if(!res[sortedS])
            res[sortedS] = [];
        res[sortedS].push(s);
    }
    return Object.values(res);
}


function HashTable(strs){
    const res = {};
    for(let s of strs){
        const count = new Array(25).fill(0);
        for(let c of s){
            count[c.charCodeAt(0) - 'a'.charCodeAt(0)] += 1;
        }
        const key = count.join(',');
        if(!res[key])
            res[key] = [];
        res[key].push(s)
    }
    return Object.values(res);
}


let strs = ["act","pots","tops","cat","stop","hat"]
console.log(Sorting(strs));
console.log(HashTable(strs));