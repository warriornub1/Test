import { useEffect, useState } from "react"

const Example2 = () =>{

    const [data, setData] = useState([])

    useEffect(() => {
        async function getData() {
            
            const response = await fetch("http://jsonplaceholder.typicode.com/posts")
            const data = await response.json()
            if (data && data.length)
                setData(data)
        }

        getData()

    }, [])

    return <div>
        <ul>
            {data.map((todo) => (
                <section key={todo.id}>
                    <li>{todo.title}</li>
                    <li>{todo.body}</li>
                </section>
            ))}
        </ul>
    </div>
}

export default Example2