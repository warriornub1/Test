const newUser = {
    name: 'Maria',
    job: 'Teacher'
};

const POSTData = () => {
    fetch('https://reqres.in/api/users', {
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(newUser)
    })
    .then(res => {
        if(!res.ok){
            console.log('Problem');
            return;
        }

        return res.json();
    })
    .then(data => {
        console.log(data);
    })
    .catch(error => {
        console.log(error);
    })
}

const POSTDataAsync = async () => { // Add 'async' here
    try {
        const res = await fetch('https://reqres.in/api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser) // Make sure 'newUser' is defined before this function
        });

        const data = await res.json();

        if (!res.ok) {
            console.log('Problem');
            return;
        }

        console.log(data);
    } catch (error) {
        console.log(error);
    }
};

POSTData()
POSTDataAsync();