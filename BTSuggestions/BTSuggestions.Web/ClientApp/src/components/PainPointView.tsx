import React from "react";
import "antd/dist/antd.css";
import PainPointTable from './PainPointTable'
import {Collapse } from "antd";

interface IPainPointViewProps{
  
}

interface IPainPointViewState{  
 
}

const Panel = Collapse.Panel;

export default class PainPointView extends React.Component<IPainPointViewProps,IPainPointViewState> {
  static defaultProps = {

  };
  state: IPainPointViewState = {    
   
  };

  render () {

    return ( <><Collapse style={{marginLeft:'10%', marginRight:'10%', marginBottom: 16, marginTop: 16}} defaultActiveKey={['1']} >
    <Panel header="To Do" key="1">
      <PainPointTable/>
    </Panel>      
  </Collapse>
  <Collapse style={{margin:15}} defaultActiveKey={['2']} >
    <Panel header="Open Pain Points" key="2">
      <PainPointTable/>
    </Panel>      
  </Collapse>
  </>
    
    )
  }
}