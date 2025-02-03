import React from "react";

const name = "John";

const Greetings = () => {
    return (
        <div>
            <h1>Welcome</h1>
            <p>{new Date().getDate()}</p>
            <p>{name}</p>
        </div>
    );
};

export default Greetings;