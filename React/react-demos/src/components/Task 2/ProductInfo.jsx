import React from "react";

const ProductInfo = () => {
    const product = {
        name : "Laptop",
        price: 1200,
        availability : "In stock",
    };

    return(
        <div>
            <p>name : {product.name}</p>
            <p>price : {product.price}</p>
            <p>availability : {product.availability}</p>
        </div>
    )
}

export default ProductInfo