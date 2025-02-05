import { useState } from "react";

const Friend = () => {

    const[friends, setFriends] = useState(["Alex", "John"]);

    const addOneFriend = () => setFriends([...friends, "Bubbles"]);
    const removeFriend = () => setFriends(friends.filter(f => f !== "John"));

    return(
        <section>
            {
                friends.map((f) => (
                    <li key={Math.random()}>{f}</li>
                ))
            }
        </section>
    )
}

export default Friend