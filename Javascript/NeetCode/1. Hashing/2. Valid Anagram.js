function sorted(s, t){
    return s.split("").sort().join() === t.split("").sort().join();
}

function hashmap(s, t){

    if(s.length !== t.length)
        return false;

    let hashS = {}
    let hashT = {}

    for(let i = 0; i < s.length; i++){
        hashS = (hashS[s[i]] || 0) + 1
        hashT = (hashT[t[i]] || 0) + 1
    }

    for(let key in hashS){
        if(! key in hashT)
            return false

        if(hashS[key] !== hashT[key])
            return false
    }
    return true

}

function arrayMap(s, t){
    if(s.length !== t.length)
        return false;

    const count = new Array(26).fill(0);
    for(let i = 0; i < s.length; i++){
        count[s.charCodeAt(i) - 'a'.charCodeAt(0)]++
        count[t.charCodeAt(i) - 'a'.charCodeAt(0)]--;
    }

    return count.every(val => val === 0);
}


let x = "racecar"
let y = "carrace"

// console.log(sorted(x, y));
console.log(hashmap(x, y));


