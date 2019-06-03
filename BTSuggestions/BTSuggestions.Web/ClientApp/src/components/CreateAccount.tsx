import React from 'react';
import { Input, Button } from 'antd';

interface ICreateAccountProps {
    newUser: (username: string) => void
}

interface ICreateAccountState {
    email: string,
    emailConfirm: string,
    firstName: string,
    lastName: string,
    username: string,
    password: string,
    passwordConfirm: string
}

export default class CreateAccount extends React.Component {
    
    handleEmailChange = (event: any) => {
        this.setState({
            email: event.target.value
        });
    }

    handleConfirmEmailChange = (event: any) => {
        this.setState({
            emailConfirm: event.target.value
        })
    }

    handleFirstNameChange = (event: any) => {
        this.setState({
            firstName: event.target.value
        });
    }

    handleLastNameChange = (event: any) => {
        this.setState({
            lastName: event.target.value
        });
    }

    handleUsernameChange = (event: any) => {
        this.setState({
            username: event.target.value
        });
    }

    handlePasswordChange = (event: any) => {
        this.setState({
            password: event.target.value
        });
    }

    handlePasswordConfirmChange = (event: any) => {
        this.setState({
            passwordConfirm: event.target.value
        });
    }
    
    render() {
        return <>
            <Input placeholder='Email' onChange={this.handleEmailChange} />
            <Input placeholder='Confirm Email' onChange={this.handleConfirmEmailChange} />
            <Input placeholder='First Name' onChange={this.handleFirstNameChange} />
            <Input placeholder='Last Name' onChange={this.handleLastNameChange} />
            <Input placeholder='Username' onChange={this.handleUsernameChange} />
            <Input placeholder='Password' onChange={this.handlePasswordChange} />
            <Input placeholder='Confirm Password' onChange={this.handlePasswordConfirmChange} />
            <Button type='primary'>Create Account</Button>
        </>
    }
}