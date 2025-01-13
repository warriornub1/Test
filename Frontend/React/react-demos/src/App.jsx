import UserList from "./components/UserList";
import Props from "./components/Props";
import Children from "./components/Children";
import Condition from "./components/Condition";
import Style from "./components/Style";
import State from "./components/State";

function App() {
  return (
    <div>
      <UserList />
      <Props
        img=""
        name="HuXn WebDev"
        age={18}
        isMarried={false}
        hobbies={["Coding", "Reading", "Sleeping"]}
      />
      <Children>
        <h1>My Card</h1>
        <p>This is some content for card</p>
      </Children>

      <Condition isValid={true} />
      <Style />
      <State />
    </div>
  );
}

export default App;
