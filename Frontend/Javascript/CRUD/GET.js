// Traditional Method

const GETData = () => {
    fetch('https://reqres.in/api/users')
    .then(res => {
        if(!res.ok)
        {
            console.log('Problem')
            return
        }
        return res.json()
    })
    .then(data => {
        console.log(data);
    })
    .catch(error => {
        console.log(error);
    })
};

// Async
const GETDataAsync = async() => {
    try{

        const res = await fetch('https://reqres.in/api/users');
        const data = await res.json();

        if(!res.ok){
            console.log(data.description);
            return
        }

        console.log(data);
    } catch(error){
        console.log(error);
    }
}

GETData();
GETDataAsync();