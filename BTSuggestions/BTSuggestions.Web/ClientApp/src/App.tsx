import React from 'react';
import './App.css';
import "antd/dist/antd.css";
import { Link, BrowserRouter, Route } from 'react-router-dom';
import CreateForm from '../src/components/CreateForm';
import blankTemplate from '../src/types/blankTemplate.api.json';
import CustomColumnHeader from './components/CustomColumnHeader';
import {ColumnNameList} from '../src/types/dropdownValues/ColumnNameTypes'

export default class App extends React.Component {
    displayName = App.name

    render() {
        const css = "../src/App.css";
        return (
            <>
                <style>{css}</style>
                <BrowserRouter>
                    <nav>
                        <Link to="/home" className="navLinks" style = {{padding:15,margin:15}}>View Issues</Link>
                        <Link to="/create" className="navLinks" style = {{padding:15,margin:15}}>Create New Issue</Link>
                        <Link to="/admin" className="navLinks" style = {{padding:15,margin:15}}>Manage Issues</Link>
                    </nav>
                    <Route path="/home" exact render={(props) => <CustomColumnHeader menuList={ColumnNameList}/>}></Route>
                    <Route path="/create" exact render={(props) => <CreateForm data={blankTemplate}/>}></Route>
                    <Route path="/admin"></Route>
                </BrowserRouter>
            </>
        );
    }
}