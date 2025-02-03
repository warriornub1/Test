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