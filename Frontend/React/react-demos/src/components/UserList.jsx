const UserList = () => {
  const users = [
    { id: 1, name: "Alice", age: 25 },
    { id: 2, name: "Bob", age: 30 },
  ];

  return (
    <div>
      {users.map((user) => (
        <ul key={user.id}>
          <li>{user.name}</li>
          <li>{user.age}</li>
        </ul>
      ))}
    </div>
  );
};

export default UserList;
