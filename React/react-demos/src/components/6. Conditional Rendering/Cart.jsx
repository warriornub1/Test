const Cart = () => {
    const items = ["SSD", "GPU", "RAM"];

    return (
        <div>
            <h1>Cart</h1>
            {items.length > 0 && <h2>You have {items.length} items in your cart</h2>}
        </div>
    );
};