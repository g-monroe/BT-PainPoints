import React from 'react';
import { Input, Button, message, Layout } from 'antd';
import * as yup from 'yup';
import FormItem from 'antd/lib/form/FormItem';
import { withFormik, InjectedFormikProps, Form } from 'formik';
import UserEntity from '../entity/UserEntity';
import { IUserHandler, UserHandler } from '../utilities/UserHandler';
import { Link } from 'react-router-dom';

interface ICreateAccountProps {
    newUser: (username: string) => void,
    userHandler?: IUserHandler
}

interface ICreateAccountState {
    email: string,
    firstName: string,
    lastName: string,
    username: string,
    password: string,
    validCreate?: boolean
}

//TODO: work on fixing this to make sure that it lines up with what we want.
const yupValidation = yup.object().shape<ICreateAccountState>({
    email: yup.string().required().label('Email'),
    firstName: yup.string().required().label("First Name"),
    lastName: yup.string().required().label('Last Name'),
    username: yup.string().max(30).required().label('Username'),
    password: yup.string().min(10).required().label('Password')
})

class CreateAccount extends React.Component<InjectedFormikProps<ICreateAccountProps, ICreateAccountState>> {
    static defaultProps = {
        userHandler: new UserHandler()
    }

    state = {
        email: '',
        firstName: '',
        lastName: '',
        username: '',
        password: '',
        validCreate: false
    }

    validateEmailChange = (event: any) => {

    }
    
    // Handlers for the state changes
    handleEmailChange = (event: any) => {
        this.setState({
            email: event.target.value
        });
    }

    handleFirstNameChange = (event: any) => {
        this.setState({
            firstName: event.target.value
        });
    }

    handleLastNameChange = (event: any) => {
        console.log(event.target.value);
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


    // Handler for the button clicks
    handleCreateAccountClick = () => {
        let data: UserEntity;
        yupValidation.validate({
            email: this.state.email,
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            username: this.state.username,
            password: this.state.password
        }).then(async(isValid) => {
            if (isValid){
                const userHandler = new UserHandler();
                if (userHandler){
                    try{
                        const newUser = new UserEntity(this.state)
                        data = (await userHandler.createUser(newUser));

                        message.success("Account Successfully Created!", 2);
                        localStorage.setItem('Auth', 'false');

                        window.location.href = '/login';

                    }catch(error){
                        message.error('Account Creation Failed', 5);
                    }
                }else {
                    message.error('Account Creation Failed', 5);
                }
            }
        })
    }

    handleCancleCreateClick = () => {
        // Go back to parent.
       // window.location.href = '/login';
    }

    getValidationStatus = (error: any) => {
        return !!error ? 'error' : 'success';
    };
    
    render() {
        const { values, handleSubmit, errors } = this.props;
        const { Content, Header } = Layout;
        return <>
            <Layout>
                <Header style={{textAlign: 'center', color: 'white'}}>Create Account</Header>
                <Content>
                    <Form onSubmitCapture={handleSubmit} style={{width: '50%', margin: 'auto'}}>
                        <FormItem label='Email' required validateStatus={this.getValidationStatus(errors.email)}>
                            <Input id='Email' placeholder='Email' onChange={this.handleEmailChange} value={this.state.email}  />
                        </FormItem>
                        <FormItem label='First Name' required validateStatus={this.getValidationStatus(errors.firstName)}>
                            <Input id='firstName' placeholder='First Name' onChange={this.handleFirstNameChange} value={this.state.firstName} />
                        </FormItem>
                        <FormItem id='lastName' label='Last Name' required validateStatus={this.getValidationStatus(errors.lastName)}>
                            <Input placeholder='Last Name' onChange={this.handleLastNameChange} value={this.state.lastName} />
                        </FormItem>
                        <FormItem id='username' label='Username' required validateStatus={this.getValidationStatus(errors.username)}>
                            <Input placeholder='Username' onChange={this.handleUsernameChange} value={this.state.username} />
                        </FormItem>
                        <FormItem id='password' label='Password' required validateStatus={this.getValidationStatus(errors.password)}>
                            <Input placeholder='Password' onChange={this.handlePasswordChange} value={this.state.password} />
                        </FormItem>
                        <Button id='createButton' htmlType='submit' type='primary' onClick={this.handleCreateAccountClick} style={{marginLeft: '32%'}}>Create Account</Button>
                        <Button id='cancelButton' type='danger' onClick={this.handleCancleCreateClick} style={{marginLeft: '20px'}}>
                            <Link to='/login'>Cancel Creation</Link>
                        </Button>
                    </Form>
                </Content>
            </Layout>
        </>
    }
};

export default withFormik<ICreateAccountProps, ICreateAccountState>({
    mapPropsToValues: props => ({
        email: '',
        firstName: '',
        lastName:'',
        username: '',
        password: '',
    }),
    validationSchema: yupValidation,
    handleSubmit: (values) => {
       
    },
    displayName: 'Create Account'
})(CreateAccount);