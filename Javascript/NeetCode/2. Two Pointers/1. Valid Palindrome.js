function IsAlpha(character){
    return (character >= 'a' && character <= 'z') ||  
            (character >= 'A' && character <= 'Z') ||
            (character >= '0' && character <= '9')
}

function BruteForce(word){
    let res = ""
    for(let s of word){
        if(IsAlpha(s))
           res += s.toLowerCase()
    }
    
    return res === res.split('').reverse().join('')
}

function TwoPointer(word){
    let l = 0; let r = word.length - 1;
    while( l < r ){
        while(!IsAlpha(word[l]))
            l++

        while(!IsAlpha(word[r]))
            r--
        
        if(word[l].toLowerCase() !== word[r].toLowerCase())
            return false

        l++;
        r--;
    }
    return true
}

console.log( TwoPointer("Was it a car or a cat I saw?") )