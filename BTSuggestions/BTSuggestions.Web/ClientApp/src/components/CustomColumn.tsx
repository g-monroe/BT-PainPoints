import React from "react";
import "antd/dist/antd.css";
import { SelectOptionWithEntityAndSpan } from "../types/dropdownValues/columnNameTypes";
import { Button, Menu, Dropdown, Icon } from "antd";
import { ClickParam } from "antd/lib/menu";
import CustomColumnData from "./CustomColumnData";

export interface ICustomColumnProps {
  menuList: SelectOptionWithEntityAndSpan[]
  data: any[]
  columnNumber: number
  changeSpan: (props:ICustomColumnProps, id: number) => void;
  columnLabel: SelectOptionWithEntityAndSpan
}

interface ICustomColumnState {  
  
}

const getDropDown = (props: ICustomColumnProps, handleMenuOnChange: (e: ClickParam, id: number) => void) => {
  console.log(props);
  const { menuList } = props;
  const dropDownMenu = (menuList.map((d, index) => (
    <Menu.Item key={index} onClick={e => handleMenuOnChange(e, index)}>
      {d.name}
    </Menu.Item>
  )));
  return (<Menu>{dropDownMenu}</Menu>);
};

// const getDropDownSortBy = (props: ICustomColumnProps, handleOnClick: (e: ClickParam) => void) =>{
//   const dropDownMenu = 
//     <Menu.Item key={"sortBy"} onClick={e => handleOnClick(e)}>
//       <b>Sort By</b>
//     </Menu.Item>
//   )));
// }




export default class CustomColumn extends React.Component<ICustomColumnProps, ICustomColumnState> {
  static defaultProps = {
  };
  state: ICustomColumnState = {
    columnLabel: this.props.menuList[0],
    
  };

  handleMenuOnChange = (e: ClickParam, id: number) => {
    console.log(this.handleMenuOnChange);    
    const { columnLabel,columnNumber, changeSpan } = this.props;
    changeSpan(this.props, id);
  };

  render() {
    const dropDown = getDropDown(this.props, this.handleMenuOnChange);    
    const { data, columnLabel } = this.props;
    console.log(dropDown);
    return (
      <>
        <Dropdown overlay={dropDown} trigger={['click']}>
          <Button>
            {columnLabel.name} <Icon type="down" />
          </Button>
        </Dropdown>
        <CustomColumnData columnHeader={columnLabel} data={data} length={10}/>
      </>
    );
  };
};





