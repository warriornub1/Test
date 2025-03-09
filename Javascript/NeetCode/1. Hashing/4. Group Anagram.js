function Hashmap(strs){

    let dic = {}
    for(let word of strs){
        

        // let key = new Array(26).fill(0)
        let key = Array.from( { length : 26 } , () => 0)
        for(let index in word){
            key[word.charCodeAt(index) - 'a'.charCodeAt(0)]++;
        
        }
        if(! (key in dic) )
            dic[key] = []
        dic[key].push(word)
    }
    return Object.values(dic);
}

let strs = ["act","pots","tops","cat","stop","hat"]
console.log(Hashmap(strs));
