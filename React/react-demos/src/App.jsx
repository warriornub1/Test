import React from "react";
import Header from "./components/Task 1/Header";
import Footer from "./components/Task 1/Footer";
import MainContent from "./components/Task 1/MainContent";
import Greetings from "./components/Task 2/Greeting";
import ProductInfo from "./components/Task 2/ProductInfo";
import UserList from "./components/3. Maps/UserList";
import ProductList from "./components/3. Maps/ProductList";
import User from "./components/4. Props/User";
import Person from "./components/4. Props/Person";
import Product from "./components/4. Props/Product";
import Card from "./components/5. Children/Card";
import Password from "./components/6. Conditional Rendering/Password";
import Weather from "./components/6. Conditional Rendering/Weather";
import Style from "./components/7. Style/Style";
import "./components/7. Style/index.css";

const App = () => {
  return (
    <section>
      <h1>Task 1</h1>
      <Header />
      <MainContent />
      <Footer />
      
      <h1>Task 2</h1>
      <Greetings />
      <ProductInfo />

      <h1>3. Maps</h1>
      <UserList />   
      <ProductList /> 

      <h1>4. Props</h1>
      <User name= "HuXn WebDev" 
            age={22} 
            isMarried={false} 
            hobbies={["Coding", "Reading", "Sleeping"]}
      />
        <Person Name= "Bubbles"
                age={1}
        />
        <Product name="Switch" price={500} />

        <h1>5. Card</h1>
        <Card>
          <h1>My Card</h1>
          <p>This is come content for card 1</p>
        </Card>

        <h1>6. Conditional Rendering</h1>
        <Password isValid={true} />
        <Weather temperature={15}/>

        <h1>7. Style</h1>
        <Style />
    </section>
  );
};

export default App;
