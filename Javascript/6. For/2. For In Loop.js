const colorObj = {
    color1: 'red',
    color2: 'blue',
    color3: 'orange',
    color4: 'green'
}

const colorArr = ['red', 'green', 'orange', 'blue']

/*
color1
color2
color3
color4
*/
for (const key in colorObj){
    console.log(key);
}

/*
0
1
2
3
*/
for(const color in colorArr)
    console.log(color);
    