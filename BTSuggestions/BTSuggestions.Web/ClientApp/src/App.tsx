import React from 'react';
import './App.css';
import "antd/dist/antd.css";
import { Link, BrowserRouter, Route } from 'react-router-dom';
import CreateForm from '../src/components/CreateForm';
import DetailView from '../src/components/DetailView';
import AdminView from '../src/components/AdminView';
import blankTemplate from '../src/types/blankTemplate.api.json';
import testData from '../src/types/testData.api.json';
import tableData from '../src/types/tableTest.api.json';

import PainPointView from './components/PainPointView';
import { Menu } from 'antd';




export default class App extends React.Component {
    displayName = App.name

    render() {
        const css = "../src/App.css";        
        return (
            <>
            
                <style>{css}</style>
                <BrowserRouter>
                    <nav>
                        <Menu mode="horizontal">
                            <Menu.Item><Link to="/home" className="navLinks">View Issues</Link></Menu.Item>
                            <Menu.Item><Link to="/create" className="navLinks">Create New Issue</Link></Menu.Item>
                            <Menu.Item><Link to="/admin" className="navLinks">Manage Issues</Link></Menu.Item>
                        </Menu>
                    </nav>
                    <Route path="/home" exact render={(props) => <PainPointView/>}/>
                    <Route path="/create" exact render={(props) => <CreateForm data={blankTemplate} />}/>
                    <Route path="/home/:id" exact render={(props) => <DetailView data={testData}/>}/>
                    <Route path="/admin" exact render={(props) => <AdminView data={tableData}/>}/>
                </BrowserRouter>
                
            </>
        );
    }
}