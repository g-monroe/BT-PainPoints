import React from 'react';
import './App.css';
import "antd/dist/antd.css";
import { Link, BrowserRouter, Route } from 'react-router-dom';

export default class App extends React.Component {
    displayName = App.name

    render() {
        const css = "../src/App.css";
    return (
        <>
            <style>{css}</style>
            <BrowserRouter>
                <nav>
                    <Link to="/home" className="navLinks">View Issues</Link>
                    <Link to="/create" className="navLinks">Create New Issue</Link>
                    <Link to="/admin" className="navLinks">Manage Issues</Link>
                </nav>
                <Route path="/home"></Route>
                <Route path="/create"></Route>
                <Route path="/admin"></Route>
            </BrowserRouter>
        </>
    );
  }
}