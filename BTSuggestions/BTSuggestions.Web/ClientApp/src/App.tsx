import React from 'react';
import './App.css';
import "antd/dist/antd.css";
import { Link, BrowserRouter, Route } from 'react-router-dom';
import DetailView from '../src/components/DetailView';
import AdminView from '../src/components/AdminView';
import tableData from '../src/types/tableTest.api.json';
import CustomColumns from '../src/components/CustomColumns'
import {IPainPointHandler, PainPointHandler } from '../src/utilities/PainPointHandler';
import PainPointEntity from './entity/PainPointEntity';
interface IAppProps{
    painPointHandler?: IPainPointHandler;
}
export default class App extends React.Component<IAppProps> {
    displayName = App.name
    static defaultProps = {
        painPointHandler: new PainPointHandler()
    }
    handleSave = async (entity: PainPointEntity): Promise<void> => {
         await this.props.painPointHandler!.createHero(entity)
      }
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
                    <Route path="/home" exact render={(props) => <CustomColumns/>}/>
                    {/* <Route path="/create" exact render={(props) => <CreateForm handleSave={this.handleSave} painPointHandler={this.props.painPointHandler} data={blankTemplate} />}/> */}
                    <Route path="/home/:id" exact render={(props) => <DetailView id={props.match.params.id} />}/>
                    <Route path="/admin" exact render={(props) => <AdminView data={tableData}/>}/>
                </BrowserRouter>
                
            </>
        );
    }
}