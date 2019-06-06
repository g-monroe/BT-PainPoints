import React from "react";
import "antd/dist/antd.css";
import CustomColumn from "./CustomColumn"
import { SelectOptionWithEntityAndWidth } from '../types/dropdownValues/columnNameTypes';
import {Table, Button } from "antd";
import PainPointEntity from '../entity/PainPointEntity';
import "../styles/CustomColumns.css"
import { ColumnProps } from "antd/lib/table/interface";

interface ICustomColumnsProps {
  data: PainPointEntity[];
  menuList: SelectOptionWithEntityAndWidth[];
  customColumnIdArray: number[];
  changeColumn: (columnNumber: number, columnHeaderId: number) => void;
  addColumn: (e: any) => void;
  deleteColumn: (event:any,columnNumber: number) => void;
}

interface ICustomColumnsState {  
  
}

export default class CustomColumns extends React.Component<ICustomColumnsProps, ICustomColumnsState> {
  static defaultProps = {
    data: [],
    menuList: []
  };

  state: ICustomColumnsState = {   
    
  };

  getColumns = () => {
    
    const { customColumnIdArray, menuList, data, changeColumn,addColumn,deleteColumn } = this.props;
    console.log(JSON.stringify(menuList));
    let columns:ColumnProps<PainPointEntity>[];
    columns = [];
    customColumnIdArray.forEach((id,index)=>{
      columns.push({
        key: index,
        filterDropdownVisible: true,
        width: menuList[id].width,
        title : <CustomColumn menuList={menuList} 
        data = {data}
        columnNumber = {index}  
        columnLabel={menuList[id]}
        changeColumn={changeColumn}
        deleteColumn={deleteColumn}/>,
        dataIndex: menuList[id].entityName
      })
    });
    columns.push({
      key: columns.length,
      width: 50,
      title : <span style={{cursor:"crosshair"}}><AddNewButton addColumn={addColumn}/></span>,
      
    })
    return columns;
     
  }

  render() {  
    
    const { data } = this.props;
    const columns = this.getColumns();   
    return (
      <>
          <Table showHeader={true} pagination={false} 
          columns={columns} dataSource={data} 
          scroll={{ x: 1300 }}
           />
      </>
    )
  }
}

const AddNewButton = (props:any) => {
  return ( <div onClick={props.addColumn}>+</div> );
   
};