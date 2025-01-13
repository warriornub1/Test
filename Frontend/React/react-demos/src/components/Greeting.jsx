const message = "Hello World";

const Greeting = () => {
  return (
    <div>
      <h1>{message}</h1>
      <p>{new Date().getDate()}</p>
    </div>
  );
};

export default Greeting;
