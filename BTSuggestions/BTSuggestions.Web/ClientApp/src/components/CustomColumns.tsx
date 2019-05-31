import React from "react";
import "antd/dist/antd.css";
import CustomColumn from "./CustomColumn"
import { columnNameList } from '../types/dropdownValues/columnNameTypes';
import { Button, Col, Pagination, Layout } from "antd";
import PainPointEntity from '../entity/PainPointEntity';
import fakeDataImport from '../types/painPointTestDataArray.api.json';
import "../styles/CustomColumns.css"

const { Footer } = Layout;
const fakeData: PainPointEntity[] = fakeDataImport.data.map(m => new PainPointEntity(m)).slice(0,15);

interface ICustomColumnsProps {
  data?: PainPointEntity[]
}

interface ICustomColumnsState {
  customColumnArray: CustomColumn[]
  totalItems: number;
  itemsPerPage: number[];
  spanArray: number[];
  currentPage: number;  
}

export default class CustomColumns extends React.Component<ICustomColumnsProps, ICustomColumnsState> {
  handleChangeSpan = (span: number, columnNumber: number) => {
    let { itemsPerPage, spanArray,totalItems } = this.state;
    console.log("HandleChangeSpan--");
      console.log(totalItems)
      console.log(itemsPerPage);
      console.log(spanArray)
      spanArray[columnNumber] = span;
      let currentSpanCount = 0;
      let currentItemCount = 0;
      itemsPerPage = [];
      for (let i = 0; i < spanArray.length; i++){
        console.log("HandleChangeSpan: " + i);
        console.log(totalItems)
        console.log(itemsPerPage);
        console.log(spanArray)
        if (currentSpanCount + spanArray[i] <= 23){
          currentSpanCount += spanArray[i];
          currentItemCount++;
        } else {
          itemsPerPage.push(currentItemCount);
          currentItemCount = 0;
          currentSpanCount = 0;
        }
      }
      itemsPerPage.push(currentItemCount);
      console.log("HandleChangeSpan++");
      console.log(totalItems)
      console.log(itemsPerPage);
      console.log(spanArray)
      this.setState({  itemsPerPage, spanArray, totalItems });
  }
 
  static defaultProps = {
    data: fakeData
  };

  state: ICustomColumnsState = {
    totalItems: 1,
    itemsPerPage: [],
    spanArray: [],
    currentPage: 1,
    customColumnArray: [],    
  };

  constructor(props:ICustomColumnsProps){
    super(props)    
    let { customColumnArray: CustomColumnArray, totalItems } = this.state;    
    CustomColumnArray.push(new CustomColumn({ menuList: columnNameList, data: this.props.data ? this.props.data : [], 
    columnNumber: 0, changeSpan:this.handleChangeSpan}))  
    
  }


  handleAddOnClick = (e?: any) => {
    console.log("handleAddOnClick");
    let { customColumnArray: CustomColumnArray, totalItems } = this.state;    
    CustomColumnArray.push(new CustomColumn({ menuList: columnNameList, data: this.props.data ? this.props.data : [], columnNumber: totalItems, changeSpan:this.handleChangeSpan}))
    totalItems += 1;
    console.log("HOC: " + totalItems);
    this.setState({ customColumnArray: CustomColumnArray,totalItems });
  }

  handlePageChange = (page:number, pageSize?:number) => {
    console.log("PAGECHANGE: " + page);
    let { currentPage } = this.state;
    currentPage = page;
    this.setState({ currentPage });
  }

  getColumnIndex = () => {
    const {currentPage , itemsPerPage} = this.state;
    let columnIndex = 0;
    for(let i = 0; i < currentPage-1; i++){
      columnIndex += itemsPerPage[i];
    }
    return columnIndex;
  }

  render() {
    const { customColumnArray: CustomColumnArray,totalItems, spanArray, itemsPerPage, currentPage} = this.state;
    const { data } = this.props;
    let columnIndex = this.getColumnIndex();
    console.log("Render Column Index: " + columnIndex);
    console.log("Render Items per Page: " + JSON.stringify(itemsPerPage));
    console.log("Render Current Page: " + JSON.stringify(currentPage));
    return (
      <>      
        {          
          CustomColumnArray.slice(columnIndex,columnIndex+itemsPerPage[currentPage-1]).map((c, index) =>
          <Col key={index} span={spanArray[index]}>
            <CustomColumn key={index} menuList={c.props.menuList} data={data ? data : []}
             changeSpan={c.props.changeSpan} columnNumber={c.props.columnNumber} />
          </Col>
        )}

        <Button onClick={e => this.handleAddOnClick(e)}>+</Button>
        <Footer className="footer"> 
        <Pagination className="rightAlign" simple defaultCurrent={1} onChange={this.handlePageChange}
         pageSize={itemsPerPage[currentPage-1]} total={itemsPerPage[currentPage-1]*itemsPerPage.length} /></Footer>
        
      </>
    )
  }
}