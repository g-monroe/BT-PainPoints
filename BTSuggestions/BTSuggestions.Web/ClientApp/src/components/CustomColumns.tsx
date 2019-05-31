import React from "react";
import "antd/dist/antd.css";
import CustomColumn, { ICustomColumnProps } from "./CustomColumn"
import { columnNameList, SelectOptionWithEntityAndSpan } from '../types/dropdownValues/columnNameTypes';
import { Button, Col, Pagination, Layout } from "antd";
import PainPointEntity from '../entity/PainPointEntity';

import "../styles/CustomColumns.css"

const { Footer } = Layout;


interface ICustomColumnsProps {
  data: PainPointEntity[]
  menuList: SelectOptionWithEntityAndSpan[];
}

interface ICustomColumnsState {
  customColumnArray: CustomColumn[]
  itemsPerPage: number[];  
  currentPage: number;
}

export default class CustomColumns extends React.Component<ICustomColumnsProps, ICustomColumnsState> {
  handleChangeSpan = (props: ICustomColumnProps, id: number) => {
    let { itemsPerPage, customColumnArray } = this.state;
    console.log("HandleChangeSpan--");
    console.log(itemsPerPage);    
    let currentSpanCount = 0;
    let currentItemCount = 0;
    itemsPerPage = [];
    for (let i = 0; i < customColumnArray.length; i++) {
      console.log("HandleChangeSpan: " + i);
      console.log(itemsPerPage);
      if (currentSpanCount + customColumnArray[i].props.columnLabel.span <= 23) {
        currentSpanCount += customColumnArray[i].props.columnLabel.span;
        currentItemCount++;
      } else {
        itemsPerPage.push(currentItemCount);
        currentItemCount = 0;
        currentSpanCount = 0;
      }
    }
    itemsPerPage.push(currentItemCount);
    console.log("HandleChangeSpan++");
    console.log(itemsPerPage);
    this.setState({ itemsPerPage, customColumnArray });
  }

  static defaultProps = {
    data: [],
    menuList: []
  };

  state: ICustomColumnsState = {   
    itemsPerPage: [1],   
    currentPage: 1,
    customColumnArray: [new CustomColumn({
      menuList: this.props.menuList, data: this.props.data,
      columnNumber: 0, changeSpan: this.handleChangeSpan, columnLabel: this.props.menuList[0]
    })],
  };


  handleAddOnClick = (e?: any) => {
    console.log("handleAddOnClick");
    let { customColumnArray } = this.state;
    customColumnArray.push
      (new CustomColumn(
        {
          menuList: columnNameList,
          data: this.props.data,
          columnNumber: customColumnArray.length,
          changeSpan: this.handleChangeSpan,
          columnLabel: this.props.menuList[0]
        }))
    this.setState({ customColumnArray });
  }

  handlePageChange = (page: number, pageSize?: number) => {
    console.log("PAGECHANGE: " + page);
    let { currentPage } = this.state;
    currentPage = page;
    this.setState({ currentPage });
  }

  getColumnIndex = () => {
    const { currentPage, itemsPerPage } = this.state;
    let columnIndex = 0;
    for (let i = 0; i < currentPage - 1; i++) {
      columnIndex += itemsPerPage[i];
    }
    return columnIndex;
  }

  render() {
    console.log(this.props.menuList);
    const { customColumnArray: CustomColumnArray, itemsPerPage, currentPage } = this.state;
    const { data } = this.props;
    let columnIndex = this.getColumnIndex();   
    return (
      <>
        {
          CustomColumnArray.slice(columnIndex, columnIndex + itemsPerPage[currentPage - 1]).map((c, index) =>
            <Col key={index} span={c.props.columnLabel.span}>
              <CustomColumn key={index} menuList={c.props.menuList} data={data}
                changeSpan={c.props.changeSpan} columnNumber={c.props.columnNumber} columnLabel={c.props.columnLabel} />
            </Col>
          )}

        <Button onClick={e => this.handleAddOnClick(e)}>+</Button>
        <Footer className="footer">
          <Pagination className="rightAlign" simple defaultCurrent={1} onChange={this.handlePageChange}
            pageSize={itemsPerPage[currentPage - 1]} total={itemsPerPage[currentPage - 1] * itemsPerPage.length} /></Footer>

      </>
    )
  }
}