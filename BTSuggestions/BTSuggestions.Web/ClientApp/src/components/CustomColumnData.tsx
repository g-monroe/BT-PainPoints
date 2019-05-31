
import React from "react";
import "antd/dist/antd.css";
import { Button, Menu, List } from "antd";
import { SelectOptionWithEntity } from "../types/dropdownValues/ColumnNameTypes"



interface ICustomColumnDataProps{
  data: any[];
  length: number;
  columnHeader: SelectOptionWithEntity;  
}

interface ICustomColumnDataState{  
 
}

const truncateText = (text:string, length:number, ending?:string) =>
{
    if (!ending) {
      ending = '...';
    }
    console.log("Hi: " + text);
    if (!text){
      return text;
    }
    if (text.length > length) {
      return text.substring(0, length - ending.length) + ending;
    } else {
      return text;
    }
   
  };





export default class CustomColumnData extends React.Component<ICustomColumnDataProps,ICustomColumnDataState> {
  static defaultProps = {
        sortBy: 0
  };
  state: ICustomColumnDataState = {    
   
  };

  getMappedData = () => {
      const { data,length,columnHeader } = this.props;    
      
      const list = data.map((d,index)=><List.Item key={index} style={{textAlign: "center",}}>{truncateText(JSON.stringify(d[columnHeader.entityName]),length)}</List.Item>);
      return ( <List>{list}</List>)
  }

  render () {
    
    return (<>{this.getMappedData()}</>)
  }
}