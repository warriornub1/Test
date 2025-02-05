const DisplayMorning = () => <h3>Good morning !</h3>

const DisplayAfternoon = () => <h3>Good afternoon !</h3>

const Greeting = ( {timeOfDay} ) => {
    if(timeOfDay === "morning")
        return <DisplayMorning />
    if(timeOfDay === "afternoon")
        return <DisplayAfternoon />
}

export default Greeting;