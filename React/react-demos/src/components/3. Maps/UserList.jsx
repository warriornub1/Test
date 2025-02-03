import React from "react";

const users = [
    { id : 1, name: "Alice", age : 25 },
    { id : 2, name: "Bob", age : 30},
    { id : 3, name: "Charlie", age : 22 },
]

const UserList = () => {
    return (
        <div>
            {users.map(({id, name, age}) => (
                <ul key={id}>
                    <li>name : {name} age : {age} </li>
                </ul>
            ))}
        </div>
    );
};

export default UserList;