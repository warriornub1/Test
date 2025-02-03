import { FaCartArrowDown } from "react-icons/fa"

const Style = () => {

    const styles = { color: "white", backgroundColor: "teal", padding: "2rem" };

    return(
        <section>
            <h1 style={{color: "red", backgroundColor: 'teal', padding: "2rem"}}>
                Inline Style
            </h1>
            <h2 style={styles}>
                Inline Style
            </h2>
            <FaCartArrowDown />
        </section>
    )
}

export default Style;