import React, { ChangeEvent } from 'react';
import { Button, Input, Col, Row, Icon, message } from 'antd';
import * as yup from 'yup';
import { async } from 'q';

interface ILoginState {
    username: string,
    password: string
}

interface ILoginProps {
    newUsername: (name: string) => void,
    username?: string,
    password?: string
}

const yupValidation = yup.object().shape<ILoginState>({
    username: yup.string().required().max(30),
    password: yup.string().min(10).required()
})

export default class LoginPage extends React.Component<ILoginProps, ILoginState> {
    state: ILoginState = {
        username: "",
        password: ""
    }
    defaultProps = {
        username: "",
        password: ""
    }

    handleUsernameInput = (user: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            username: user.currentTarget.value
        });
    }

    handlePasswordInput = (password: ChangeEvent<HTMLInputElement>) => {
        this.setState({
            password: password.currentTarget.value
        });
    }

    handleLoginClick = () => {
        yupValidation.isValid({username: this.state.username, password: this.state.password})
            .then((isValid) => {
                if (isValid){
                    message.success('Login successful',3);
                }else{
                    message.error('Login failed',5);
                }
            });
    }

    handleCreateAccountClick = () => {
        console.log('cacc');
    }

    render() {
        return <div>
            <Row style={{ paddingTop: '100px' }}>
                <Col span={6}></Col>
                <Col span={12} >
                    <Input placeholder="Username" 
                        prefix={<Icon type="user" 
                        style={{ color: 'rgba(0,0,0,.25)' }} />} 
                        onChange={this.handleUsernameInput} />

                    <div style={{ height: '25px' }}/>
                    <Input.Password placeholder="Password" onChange={this.handlePasswordInput}></Input.Password>
                </Col>
                <Col span={6}></Col>
            </Row>
            <Row>
                <div style={{ height: '75px' }}></div>
                <Col span={5} offset={11}>
                    <Button type="primary" style={{ width: '150px' }} onClick={this.handleLoginClick}>Login</Button>
                    <div style={{ width: '20px', height: '25px' }}/>
                    <Button type="dashed" style={{ width: '150px' }} onClick={this.handleCreateAccountClick} >Create Account</Button>
                </Col>
            </Row>
        </div>
    }
}