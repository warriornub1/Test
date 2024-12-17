const newUser = {
    name: 'Maria',
    job: 'Teacher'
};

const PUTDataAsync = async () => { // Updated name for clarity
    try {
        const res = await fetch('https://reqres.in/api/users/2', { // Replace with appropriate URL
            method: 'PUT', // Change method to 'PUT'
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser) // Ensure newUser is defined
        });

        const data = await res.json();

        if (!res.ok) {
            console.log(data.description);
            return;
        }

        console.log('Success:', data);
    } catch (error) {
        console.log('Error:', error);
    }
};

PUTDataAsync();