import React from 'react';
import { Input, Button, message } from 'antd';
import * as yup from 'yup';

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

//TODO: work on fixing this to make sure that it lines up with what we want.
const yupValidation = yup.object().shape<ICreateAccountState>({
    email: yup.string().required(),
    emailConfirm: yup.string().matches(this.state.email).required(),
    firstName: yup.string().required(),
    lastName: yup.string().required(),
    username: yup.string().max(30).required(),
    password: yup.string().min(10).required(),
    passwordConfirm: yup.string().min(10).required()
})

export default class CreateAccount extends React.Component {
    // Default state so that the verification fucntion will work correctly.
    state = {
        email: "",
        emailConfirm: "",
        firstName: "",
        lastName: "",
        username: "",
        password: "",
        passwordConfirm: ""
    }
    
    // Handlers for the state changes
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

    // Handler for the button clicks
    handleCreateAccountClick = () => {
        yupValidation.validate({
            email: this.state.email,
            emailConfirmation: this.state.emailConfirm,
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            username: this.state.username,
            password: this.state.password,
            passwordConfirm: this.state.passwordConfirm
        }).then((isValid) => {
            if (isValid){
                message.success('Created Account Successfully.', 7);
            }else {
                message.error('Account Creation Failed', 10);
            }
        })
    }

    handleCancleCreateClick = () => {
        // Go back to parent.
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
            <Button type='primary' onClick={this.handleCreateAccountClick}>Create Account</Button>
            <Button type='danger' onClick={this.handleCancleCreateClick}>Cancle Create</Button>
        </>
    }
}