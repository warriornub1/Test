async function fetchData()
{
    try
    {
        const response = await fetch('https://jsonplaceholder.typicode.com/posts/1');
        if(!response.ok)
            throw new Error('Network response was not ok');

        const data = await response.json();
        const contentDiv = document.getElementById('content')
        contentDiv.innerHTML = `<h2>${data.title}</h2>
                                <p>${data.body}</p>`
                                
    }
    catch(error)
    {
        console.error('Error fetching data: ', error)
    }
}

window.onload = fetchData;

document.getElementById("postForm").addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission

    const name = document.getElementById("name").value;
    const age = document.getElementById("age").value;

    fetch("https://example.com/api", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ name: name, age: age })
    })
    .then(response => response.json())
    .then(data => console.log("Success:", data))
    .catch(error => console.error("Error:", error));
});