const items = ['book', 'table', 'chair', 'kite']
const users = [{name: 'Brad'}, {name: 'Kate'}, {name: 'Steve'}]

const map = new Map()
map.set('name', 'John')
map.set('age', 30)


/*
{ name: 'Brad' }
{ name: 'Kate' }
{ name: 'Steve' }
 */

for(const user of users)
    console.log(user);

/*
book
table
chair
kite
*/
for(const item of items)
    console.log(item);

for(const [key, value] of map){
    console.log(key, value);
    
}    