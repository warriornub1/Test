function encode(strs){

    let res = ""
    for(let str of strs){
        res += str.length + "#" + str
    }
    return res

}

function decode(strs){

    let res = []
    let i = 0;
    let j = strs.length - 1;
    while(i < j){
        let k = i;
        while(strs[k] !== '#'){
            k++
        }
        let length = parseInt(strs.substring(i, j));
        i = k + 1;
        res.push(strs.substring(i, i + length))
        i += length;
    }
    return res
}

let res = encode(["neet","code","love","you"])
let res1 = decode(res)
console.log(res1);

