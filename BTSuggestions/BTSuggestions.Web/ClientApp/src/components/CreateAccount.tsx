import React from 'react';
import { Input, Button } from 'antd';

interface ICreateAccountProps {
    newUser: (username: string) => void
}

interface ICreateAccountState {
    email: string,
    firstName: string,
    lastName: string,
    username: string,
    password: string
}

export default class CreateAccount extends React.Component {
    
    
    render() {
        return <>
            <Input placeholder='Email'/>
            <Input placeholder='First Name'/>
            <Input placeholder='Last Name'/>
            <Input placeholder='Username'/>
            <Input placeholder='Password'/>
            <Input placeholder='Confirm Password' />
            <Button type='primary'>Create Account</Button>
        </>
    }
}