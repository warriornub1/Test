const ValidPassword = () => <h1>Valid Password</h1>;

const InvalidPassword = () => <h1>InValid Password</h1>;

const items = ["Wireless Earbuds", "Power Bank", "New SSD", "Hoddie"];

const Condition = ({ isValid }) => {
  return (
    <div>
      {items.length > 0 && <h2>You have {items.length} items in your Cart</h2>}
      <ul>
        <h4>Products</h4>
        {items.map((item) => (
          <li key={Math.random()}>{item}</li>
        ))}
      </ul>
      {isValid ? <ValidPassword /> : <InvalidPassword />}
    </div>
  );
};

export default Condition;
