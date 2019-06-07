import React, { ChangeEvent } from 'react';
import { Button, Input, Col, Row, Icon, message } from 'antd';
import * as yup from 'yup';
import { Link } from 'react-router-dom';
import { IUserHandler, UserHandler } from '../utilities/UserHandler';
import UserEntity from '../entity/UserEntity';
import { isNull } from 'util';

interface ILoginState {
    username: string,
    password: string,
    data?: UserEntity
}

interface ILoginProps {
    newUsername: (name: string) => void,
    username?: string,
    password?: string,
    userHandler?: IUserHandler;
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
    static defaultProps = {
        username: "",
        password: "",
        userHandler: new UserHandler()
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
        let data: UserEntity;
        yupValidation.isValid({username: this.state.username, password: this.state.password})
            .then(async (isValid) => {
                if (isValid){
                    const {userHandler} = this.props;
                    if (userHandler){         
                        try{
                            data = (await userHandler.getByUsername(this.state.username));
                            console.log(data);
                            if (data.password.toString() === this.state.password){
                                message.success('Login Successful');
                                localStorage.setItem('Auth', 'true');
                                localStorage.setItem('userId', data.userId.toString());
                                
                                window.location.href = '/home';
                            }
                            else{
                                message.error('Incorrect Password', 5);
                            }
                        }catch(error){
                            message.error('Login Failed', 5);
                            localStorage.setItem('Auth', 'false');
                            console.log('error');
                        }
                    }
                }else{
                    message.error('Login Failed',5);
                    localStorage.setItem('Auth', 'false');
                }
            });
    }

    handleCreateAccountClick = () => {
        console.log('cacc');
    }

    render() {
        return <div>
            <img src='https://constructech.com/wp-content/uploads/2019/01/CT_TP19_buildertrend-logo_01-300x150.jpg' style={{marginLeft: '40%'}}></img>
            <Row style={{ paddingTop: '100px' }}>
                <Col span={6}></Col>
                <Col span={12} >
                    <Input placeholder="Username" 
                        prefix={<Icon type="user" 
                        style={{ color: 'rgba(0,0,0,.25)' }} />} 
                        onChange={this.handleUsernameInput} />

                    <div style={{ height: '25px' }}/>
                    <Input.Password placeholder="Password"
                        prefix={<Icon type="lock" 
                        style={{ color: 'rgba(0,0,0,.25)' }} />}
                        onChange={this.handlePasswordInput}> 
                    </Input.Password>
                </Col>
                <Col span={6}></Col>
            </Row>
            <Row style={{margin: 'auto'}}>
                <div style={{ height: '75px' }}></div>
                <Col style={{margin: 'auto'}}>
                    <Button type='link' style={{ width: '150px', marginLeft: '39.5%'}} onClick={this.handleLoginClick}>
                        Login
                    </Button>
                    <Button type="link" style={{ width: '150px' }}>
                        <Link to="/create-account">Create Account</Link>
                    </Button>
                </Col>
            </Row>
        </div>
    }
}