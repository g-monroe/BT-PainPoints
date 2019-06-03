import React, { ChangeEvent } from 'react';
import { Button, Input, Col, Row, Icon } from 'antd';

interface ILoginState {
    username: string,
    password: string
}

interface ILoginProps {
    newUsername: (name: string) => void,
    username?: string,
    password?: string
}

export default class LoginPage extends React.Component<ILoginProps, ILoginState> {

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

    render() {
        return <div>
            <Row style={{ paddingTop: '100px' }}>
                <Col span={6}></Col>
                <Col span={12} >
                    <Input placeholder="Username" prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />} onChange={this.handleUsernameInput}></Input>
                    <div style={{ height: '25px' }}/>
                    <Input.Password placeholder="Password"></Input.Password>
                </Col>
                <Col span={6}></Col>
            </Row>
            <Row>
                <div style={{ height: '75px' }}></div>
                <Col span={5} offset={11}>
                    <Button type="primary" style={{ width: '150px' }}>Login</Button>
                    <div style={{ width: '20px', height: '25px' }}/>
                    <Button type="dashed" style={{ width: '150px' }}>Create Account</Button>
                </Col>
            </Row>
        </div>
    }
}