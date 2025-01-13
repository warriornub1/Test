const ProductInfo = () => {
  const product = {
    name: "Laptop",
    price: "$1200",
    availability: "In stock",
  };
  return (
    <div>
      <h1>Name: {product.name}</h1>
    </div>
  );
};

export default ProductInfo;
