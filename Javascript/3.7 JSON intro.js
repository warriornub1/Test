const post = {
    id: 1,
    title: 'Post One',
    body: 'This is the body'
}

const str = JSON.stringify(post);
console.log(str);

// Parse JSON
const obj = JSON.parse(str);
console.log(obj);

