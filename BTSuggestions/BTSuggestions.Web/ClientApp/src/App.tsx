import React from 'react';
import '../src/styles/App.css';
import "antd/dist/antd.css";
import { Link, BrowserRouter, Route} from 'react-router-dom';
import CreateForm from '../src/components/CreateForm';
import DetailView from '../src/components/DetailView';
import AdminView from '../src/components/AdminView';
import PainPointView from '../src/components/PainPointView'
import LoginPage from '../src/components/LoginPage';
import PrivateRoute from '../src/components/PrivateRoute';
import CreateAccount from './components/CreateAccount';
import { Menu } from 'antd';
import tableData from '../src/types/tableTest.api.json';

interface IPainPointState {
    username: string,
    auth: boolean
}

const userAuth = {
    isAuthenticated: false,
    authenticate(cb: any) {
        this.isAuthenticated = true
        setTimeout(cb, 100)
    },
    signout(cb: any) {
        this.isAuthenticated = false
        setTimeout(cb, 100)
    }
}

export default class App extends React.Component {
    displayName = App.name

    handleLoginRequest = (name: string) => {
        this.setState({
            username: name
        });
        localStorage.setItem('username', name);
    }

    handleAuthChange = (authUpdate: boolean) => {
        this.setState({
            auth: authUpdate
        });
    }

    handleNewUser = (user: string) => {
        localStorage.setItem('username', user);
    }

    render() {
        const css = "../src/App.css";
        return (
            <>
            
                <style>{css}</style>
                <BrowserRouter>
                    {localStorage.getItem('Auth') === 'true' && <Menu style={{boxShadow:"2px 2px" }} mode="horizontal">
                            <Menu.Item><Link to="/home" className="navLinks">View Issues</Link></Menu.Item>
                            <Menu.Item><Link to="/create" className="navLinks">Create New Issue</Link></Menu.Item>
                            <Menu.Item><Link to="/admin" className="navLinks">Manage Issues</Link></Menu.Item>
                        </Menu>}
                    <Route path="/login" exact render={(props) => <LoginPage newUsername={this.handleLoginRequest}/>} />
                    <Route path="/create-account" exact render={(props) => <CreateAccount newUser={this.handleNewUser} />}/>
                    <PrivateRoute auth={localStorage.getItem('Auth')} path="/home" exact component={PainPointView} />
                    <PrivateRoute auth={localStorage.getItem('Auth')} path="/create" exact component={CreateForm} />
                    <PrivateRoute auth={localStorage.getItem('Auth')} path="/home/:id" exact component={DetailView}/>
                    <PrivateRoute auth={localStorage.getItem('Auth')} path="/admin" exact component={() => <AdminView data={tableData}/>}/>
                </BrowserRouter> 
            </>
        );
    }
}