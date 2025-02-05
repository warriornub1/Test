const WelcomeAdmin = () => <h3>Welcome Admin!</h3>

const WelcomeUser = () => <h3>Welcome User</h3>

const UserStatus = ({loggedIn, isAdmin}) => {
    if (loggedIn && isAdmin)
        return <WelcomeAdmin/>
    if(loggedIn && !isAdmin)
        return <WelcomeUser />

}

export default UserStatus;