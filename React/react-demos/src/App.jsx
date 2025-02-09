import React from "react";
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
import UserStatus from "./components/6. Conditional Rendering/UserStatus";
import Greeting from "./components/6. Conditional Rendering/Greeting";
import State from "./components/8. StateHook/State";
import StyledCard from "./components/7. Style/StyledCard";
import ProfileCard from "./components/7. Style/ProfileCard";
import CopyInput from "./components/9. React Portal/CopyInput";
import Example1 from "./components/10  .useEffect/Example1";
import Example2 from "./components/10  .useEffect/Example2";

const App = () => {
  return (
    <section>

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
        <UserStatus loggedIn = {true} isAdmin={true} />
        <Greeting timeOfDay={"morning"}/>

        <h1>7. Style</h1>
        <Style />
        <StyledCard />
        <ProfileCard />

        <h1>8. State</h1>
        <State />

        <h1>9. React Portal</h1>
        <CopyInput />

        <h1>10. useEffect</h1>
        <Example1 />
        <Example2 />

    </section>
  );
};

export default App;
