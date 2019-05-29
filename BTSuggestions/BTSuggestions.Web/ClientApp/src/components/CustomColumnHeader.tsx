
import React from "react";
import ReactDOM from "react-dom";
import "antd/dist/antd.css";
import { SelectOption } from "../types/dropdownValues/SelectOption";
import { Button, Menu } from "antd";
import { ColumnNameList } from "../types/dropdownValues/ColumnNameTypes";
import SubMenu from "antd/lib/menu/SubMenu";


interface ICustomColumnHeaderProps{
  menuList: SelectOption[]
}

interface ICustomColumnHeaderState{  
  columnLabelArray: number[]
}



export default class CustomColumnHeader extends React.Component<ICustomColumnHeaderProps,ICustomColumnHeaderState> {
  static defaultProps = {
  };
  state: ICustomColumnHeaderState = {    
    columnLabelArray:[]
  };

  getColumns = () => {
    const { columnLabelArray } = this.state; 
    console.log("columns are generating...");
  const array = columnLabelArray.map((c,index) => (
    <SubMenu
          title={ 
            <span>              
              {this.props.menuList[columnLabelArray[index]]}
            </span>
          }
        >
          {this.getMenuList()}
          
        </SubMenu>
  ));  
  console.log(array)  
    return (
        <div>{array}</div>
    )
  };

  handleAddOnClick = () => {
    const {columnLabelArray} = this.state;    
    columnLabelArray.push(0);  
    this.setState({columnLabelArray});
}


getMenuList = () => {
  const { menuList } = this.props;
  return menuList.map((m,index) => <Menu.Item key={index}>{m.name}</Menu.Item>);       
}
  render () {
    //const columns = this.getColumns();
      return ( 
        <>
        <Menu mode="horizontal"> </Menu><Button onClick={this.handleAddOnClick}>+</Button>
        </>
      );
  };
};