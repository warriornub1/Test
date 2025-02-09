function isAlphanumeric(char){
    return (char >= 'a' && char <= 'z') ||
           (char >= 'A' && char <= 'Z' ) ||
           (char >= '0' && char <= '9');
}

function Reverse(s){
    let newStr = '';
    for (let c of s){
        if(isAlphanumeric(c))
            newStr += c.toLowercase();
    }
    return newStr === newStr.split('').reverse().join('');
}

function twoPointers(s){
    let l = 0, r = s.length - 1;

    while(l < r){
        while(l < r && !isAlphanumeric(s[l]))
            l++
        while(r > l && !isAlphanumeric[s[r]])
            r--

        if(s[l].toLowercase() !== s[r].toLowercase())
            return false;
        l++; r--;
    }
    return true;
}