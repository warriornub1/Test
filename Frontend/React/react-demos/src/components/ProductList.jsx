const ProductList = () => {
  const products = [
    { id: 1, name: "Phone", price: "$699" },
    { id: 2, name: "Laptop", price: "$1200" },
  ];

  return (
    <div>
      {products.map((id, name, price) => (
        <ul key={id}>
          <li>{name}</li>
          <li>{price}</li>
        </ul>
      ))}
    </div>
  );
};

export default ProductList;
