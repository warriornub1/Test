const newUser = {
    name: 'Maria',
    job: 'Teacher'
};

const DELETEDataAsync = async () => { // Updated name for clarity
    try {
        const res = await fetch('https://reqres.in/api/users/2', {
            method: 'DELETE'
        });

        if (!res.ok) {
            console.log(`Error: ${res.status} ${res.statusText}`);
            return;
        }

        const data = res.headers.get('Content-Length') > 0 ? await res.json() : null;

        console.log('Success:', data);
    } catch (error) {
        console.log('Error:', error);
    }
};

DELETEDataAsync();