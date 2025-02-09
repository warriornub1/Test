function encode(strs){
    let res = ""
    for(let s of strs){
        res += s.length + "#" + s;
    }
    return res;
}

function decode(strs){
    let res = []
    let i = 0
    while(i < strs.length){
        let j = i
        while(str[j] !== '#')
            j++
        let length = parseInt(str.substring(i, j))
        i = j + 1
        j = i + length
        res.push(str.substring(i, j))
        i = j
    }
    return res;
}