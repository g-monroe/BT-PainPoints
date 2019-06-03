import React from "react";
import "antd/dist/antd.css";
import { Button, Menu } from "antd";
import CustomColumns from "./CustomColumns"
import PainPointEntity from "../entity/PainPointEntity";



interface IPainPointPageProps{
  
}

interface IPainPointPageState{
  isFetching: boolean  
  customColumnIdArray : number[]
  data : PainPointEntity[]
}



export default class PainPointPage extends React.Component<IPainPointPageProps,IPainPointPageState> {
  static defaultProps = {

  };
  
  state: IPainPointPageState = {
    isFetching = false,
    customColumnIdArray: [],  
    data: []
  };

  componentDidMount {
    
  }

  getData = () => {
    this.setState({isFetching: true});
  }

  deleteColumn = (columnNumber: number) => {
    //TODO
  }

  addColumn = (columnHeaderId: number) => {
    //TODO
  }

  changeColumn = (columnNumber: number, columnHeaderId: number) => {
    //TODO
  }


  render () {

    return (<></>)
  }
}