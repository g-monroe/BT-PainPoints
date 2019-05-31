import React from "react";
import "antd/dist/antd.css";
import { SelectOptionWithEntity } from "../types/dropdownValues/columnNameTypes";
import { Button, Menu, Dropdown, Icon } from "antd";
import { ClickParam } from "antd/lib/menu";
import CustomColumnData from "./CustomColumnData"

interface ICustomColumnProps {
  menuList: SelectOptionWithEntity[]
  data: any[]
  
}

interface ICustomColumnState {
  columnLabel: SelectOptionWithEntity
}

const getDropDown = (props: ICustomColumnProps, handleOnClick: (e: ClickParam, id: number) => void) => {
  console.log(props);
  const { menuList } = props;
  const dropDownMenu = (menuList.map((d, index) => (
    <Menu.Item key={index} onClick={e => handleOnClick(e, index)}>
      {d.name}
    </Menu.Item>
  )));
  return (<Menu>{dropDownMenu}</Menu>);
};

export default class CustomColumn extends React.Component<ICustomColumnProps, ICustomColumnState> {
  static defaultProps = {
  };
  state: ICustomColumnState = {
    columnLabel: this.props.menuList[0]
  };

  handleOnClick = (e: ClickParam, id: number) => {
    console.log(this.handleOnClick);
    let { columnLabel } = this.state;
    const { menuList } = this.props;
    columnLabel = menuList[id];
    this.setState({ columnLabel });
  };

  render() {
    const dropDown = getDropDown(this.props, this.handleOnClick);
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





