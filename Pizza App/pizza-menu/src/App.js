import React from "react";

function App() {
  return (
    <div>
      <Header />
      <Menu />
      <Footer />
    </div>
  );
}

function Header(){
  return <h1>Fast React Pizza Co.</h1>
}

function Menu(){
  return (
    <div>
      <h2>Our menu</h2>
      <Pizza />
      <Pizza />
      <Pizza />
      <Pizza />
    </div>
  );
}

function Pizza(){
  return(
    <div>
      <img src="pizzas/spinaci.jpg" alt="Pizza spinaci"/>
      <h2>Pizza Spinaci</h2>
      <p>Tomato, mozarella, spinmach, and ricotta cheese</p>
    </div>
  )
}

function Footer(){
  return React.createElement("footer", null, "We're currently open!");
}

export default App;
