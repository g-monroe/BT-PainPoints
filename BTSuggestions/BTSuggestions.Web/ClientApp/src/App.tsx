import React, { Component } from 'react';
import './App.css';
import "antd/dist/antd.css";
import { Link, BrowserRouter, Route, Redirect, RouteProps } from 'react-router-dom';
import CreateForm from '../src/components/CreateForm';
import DetailView from '../src/components/DetailView';
import AdminView from '../src/components/AdminView';
import CustomColumns from '../src/components/CustomColumns'
import LoginPage from '../src/components/LoginPage';
import PrivateRoute from '../src/components/PrivateRoute';

interface IPainPointState {
    username: string
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
    }

    render() {
        const css = "../src/App.css";
        return (
            <>
            
                <style>{css}</style>
                <BrowserRouter>
                    {userAuth.isAuthenticated && <nav>
                        <Link to="/home" className="navLinks" style = {{padding:15,margin:15}}>View Issues</Link>
                        <Link to="/create" className="navLinks" style = {{padding:15,margin:15}}>Create New Issue</Link>
                        <Link to="/admin" className="navLinks" style = {{padding:15,margin:15}}>Manage Issues</Link>
                    </nav>}
                    <Route path="/login" exact render={(props) => <LoginPage newUsername={this.handleLoginRequest}/>} />
                    <PrivateRoute path="/home" exact component={CustomColumns} />
                    <PrivateRoute path="/create" exact component={CreateForm} />
                    <PrivateRoute path="/home/:id" exact component={DetailView}/>
                    <PrivateRoute path="/admin" exact component={AdminView} />
                </BrowserRouter> 
                
            </>
        );
    }
}