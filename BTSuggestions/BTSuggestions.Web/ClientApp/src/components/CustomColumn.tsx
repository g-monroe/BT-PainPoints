import React from "react";
import "antd/dist/antd.css";
import { SelectOptionWithEntityAndWidth } from "../types/dropdownValues/columnNameTypes";
import { Button, Menu, Dropdown, Icon } from "antd";
import { ClickParam } from "antd/lib/menu";
import CustomColumnData from "./CustomColumnData";

export interface ICustomColumnProps {
  menuList: SelectOptionWithEntityAndWidth[];
  data: any[];
  columnNumber: number;  
  columnLabel: SelectOptionWithEntityAndWidth;
  changeColumn: (columnNumber: number, columnHeaderId: number) => void;
  deleteColumn: (event:any,columnNumber: number) => void;
}

interface ICustomColumnState {  
  
}

const getDropDown = (props: ICustomColumnProps, handleMenuOnChange: (e: ClickParam, id: number) => void) => { 
  const { menuList,columnNumber,deleteColumn } = props;
  let dropDownMenu = (menuList.map((d, index) => (
    <Menu.Item key={index} onClick={e => handleMenuOnChange(e, index)}>
      {d.name}
    </Menu.Item>
  )));
  dropDownMenu.push(<Menu.Item key={dropDownMenu.length} onClick={e=>deleteColumn(e,columnNumber)}>
  <b style={{color:'red'}}>Delete</b>
</Menu.Item>)
  return (<Menu>{dropDownMenu}</Menu>);
};

export default class CustomColumn extends React.Component<ICustomColumnProps, ICustomColumnState> {
  static defaultProps = {

  };
  state: ICustomColumnState = {
    
    
  };

  handleMenuOnChange = (e: ClickParam, id: number) => {      
    const { columnLabel,columnNumber, changeColumn} = this.props;
    changeColumn(columnNumber,id);
  };

  render() {
    const dropDown = getDropDown(this.props, this.handleMenuOnChange);    
    const { data, columnLabel } = this.props;
    const {  } = this.state;
    return (
      <>
        <Dropdown overlay={dropDown} trigger={['click']}>
          
           <span>{columnLabel.name} </span> 
         
        </Dropdown>
        
      </>
    );
  };
};





