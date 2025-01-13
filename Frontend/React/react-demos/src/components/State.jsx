import { useState } from "react";

const State = () => {
  const [count, setCount] = useState(0);

  const increment = () => setCount(count + 1);
  const decrement = () => setCount(count - 1);

  const [friends, setFriends] = useState(["Alex", "John"]);

  const addOneFriend = () => setFriends([...friends, "HuXn WebDev"]);
  const removeFriend = () => setFriends(friends.filter((f) => f != "John"));
  const updateOneFriend = () => {
    setFriends(friends.map((f) => (f === "Alex" ? "Allex Smith" : f)));
  };

  return (
    <section style={{ color: "red", backgroundColor: "Pink" }}>
      <h1>{count}</h1>
      <button onClick={increment}>+</button>
      <button onClick={decrement}>-</button>
      <br />
      <h1>Friends</h1>
      {friends.map((f) => (
        <li key={Math.random()}>{f}</li>
      ))}

      <button onClick={addOneFriend}>Add New Friend</button>
      <button onClick={removeFriend}>Remove One Friend</button>
      <button onClick={updateOneFriend}>Update One Friend</button>
    </section>
  );
};

export default State;
