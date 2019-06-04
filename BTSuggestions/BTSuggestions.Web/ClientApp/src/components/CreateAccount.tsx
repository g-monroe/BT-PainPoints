import React from 'react';
import { Input, Button, message } from 'antd';
import * as yup from 'yup';
import FormItem from 'antd/lib/form/FormItem';
import { withFormik, InjectedFormikProps, Form } from 'formik';
import UserEntity from '../entity/UserEntity';

interface ICreateAccountProps {
    newUser: (username: string) => void
    data: UserEntity,
    emailConfirmProp: string,
    passwordConfirmProp: string;
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
    email: yup.string().required().label('Email'),
    emailConfirm: yup.string().required().label('Email Confirm'),
    firstName: yup.string().required().label("First Name"),
    lastName: yup.string().required().label('Last Name'),
    username: yup.string().max(30).required().label('Username'),
    password: yup.string().min(10).required().label('Password'),
    passwordConfirm: yup.string().min(10).required().label('Password Confirm')
})

class CreateAccount extends React.Component<InjectedFormikProps<ICreateAccountProps, ICreateAccountState>> {
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

    static defaultProps = {
        emailConfirmProp: "",
        passowrdConfirmProp: ""
    };

    validateEmailChange = (event: any) => {

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
        const { values, handleSubmit } = this.props;
        return <>
            <Form onSubmitCapture={handleSubmit}>
                <FormItem label='Email' required >
                    <Input id='Email' placeholder='Email' onChange={this.handleEmailChange} value={values.email} />
                </FormItem>
                <FormItem label='Confirm Email' required>
                    <Input id='EmailConfirm' placeholder='Confirm Email' onChange={this.handleConfirmEmailChange} value={values.emailConfirmProp} />
                </FormItem>
                <FormItem label='First Name' required>
                    <Input id='firstName' placeholder='First Name' onChange={this.handleFirstNameChange} value={values.firstName}/>
                </FormItem>
                <FormItem id='lastName' label='Last Name' required>
                    <Input placeholder='Last Name' onChange={this.handleLastNameChange} value={values.lastName} />
                </FormItem>
                <FormItem id='username' label='Username' required>
                    <Input placeholder='Username' onChange={this.handleUsernameChange} value={values.username}/>
                </FormItem>
                <FormItem id='password' label='Password' required>
                    <Input placeholder='Password' onChange={this.handlePasswordChange} value={values.password}/>
                </FormItem>
                <FormItem id='passwordConfirm' label='Confirm Password' required>
                    <Input placeholder='Confirm Password' onChange={this.handlePasswordConfirmChange} value={values.passowrdConfirmProp}/>
                </FormItem>
                <Button id='createButton' htmlType='submit' type='primary' onClick={this.handleCreateAccountClick}>Create Account</Button>
                <Button id='cancleButton' type='danger' onClick={this.handleCancleCreateClick}>Cancle Create</Button>
            </Form>
        </>
    }
};

export default withFormik<ICreateAccountProps, ICreateAccountState>({
    mapPropsToValues: props => ({
        email: props.data.email,
        emailConfirm: (props.emailConfirmProp) ? props.emailConfirmProp: " ",
        firstName: props.data.firstName,
        lastName: props.data.lastName,
        username: props.data.username,
        password: props.data.username,
        passwordConfirm: (props.passwordConfirmProp) ? props.passwordConfirmProp: " "
    }),
    validationSchema: yupValidation,
    handleSubmit: (values) => {
        console.log(values + 'User created');
    },
    displayName: 'Create Account'
})(CreateAccount);