import React, { Component } from 'react';
import './App.css';
import "antd/dist/antd.css";
import { Link, BrowserRouter, Route, Redirect, RouteProps } from 'react-router-dom';
import CreateForm from '../src/components/CreateForm';
import DetailView from '../src/components/DetailView';
import AdminView from '../src/components/AdminView';
import PainPointView from '../src/components/PainPointView'
import LoginPage from '../src/components/LoginPage';
import PrivateRoute from '../src/components/PrivateRoute';
import CreateAccount from './components/CreateAccount';
import UserEntity from './entity/UserEntity';

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
                    {localStorage.getItem('Auth') === 'true' && <nav>
                        <Link to="/home" className="navLinks" style = {{padding:15,margin:15}}>View Issues</Link>
                        <Link to="/create" className="navLinks" style = {{padding:15,margin:15}}>Create New Issue</Link>
                        <Link to="/admin" className="navLinks" style = {{padding:15,margin:15}}>Manage Issues</Link>
                    </nav>}
                    <Route path="/login" exact render={(props) => <LoginPage newUsername={this.handleLoginRequest}/>} />
                    <Route path="/create-account" exact render={(props) => <CreateAccount newUser={this.handleNewUser} />}/>
                    <PrivateRoute auth={localStorage.getItem('Auth')} path="/home" exact component={PainPointView} />
                    <PrivateRoute auth={localStorage.getItem('Auth')} path="/create" exact component={CreateForm} />
                    <PrivateRoute auth={localStorage.getItem('Auth')} path="/home/:id" exact component={DetailView}/>
                    <PrivateRoute auth={localStorage.getItem('Auth')} path="/admin" exact component={AdminView} />
                </BrowserRouter> 
                
            </>
        );
    }
}