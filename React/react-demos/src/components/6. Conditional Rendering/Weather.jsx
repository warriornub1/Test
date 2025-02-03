const Cold = () => <h1>It's cold outside!</h1>

const Nice = () => <h1>It's nice outside!</h1>

const Hot = () => <h1>It's hot outside!</h1>

const Weather = (props) => {
    if(props.temperature < 15)
        return <Cold />
    else if(props.temperature >= 15 && props.temperature <= 25)
        return <Nice />
    else
        return <Hot />
}

export default Weather;