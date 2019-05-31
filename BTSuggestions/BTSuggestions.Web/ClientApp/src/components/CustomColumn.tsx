import React from "react";
import "antd/dist/antd.css";

import { SelectOptionWithEntityAndSpan } from "../types/dropdownValues/columnNameTypes";

import { Button, Menu, Dropdown, Icon } from "antd";
import { ClickParam } from "antd/lib/menu";
import CustomColumnData from "./CustomColumnData"

interface ICustomColumnProps {
  menuList: SelectOptionWithEntityAndSpan[]
  data: any[]
  columnNumber: number
  changeSpan: (span:number, columnNumber: number) => void;
}

interface ICustomColumnState {  
  columnLabel: SelectOptionWithEntityAndSpan
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

  constructor(props:ICustomColumnProps){
    super(props);
    const { changeSpan,menuList,columnNumber } = this.props;
    changeSpan(menuList[0].span,columnNumber);
  }

  handleMenuOnChange = (e: ClickParam, id: number) => {
    console.log(this.handleMenuOnChange);
    let { columnLabel } = this.state;
    const { menuList,changeSpan,columnNumber } = this.props;
    columnLabel = menuList[id];
    changeSpan(columnLabel.span, columnNumber);
    this.setState({ columnLabel });
  };

  render() {
    const dropDown = getDropDown(this.props, this.handleMenuOnChange);
    const { columnLabel } = this.state;
    const { data } = this.props;
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





