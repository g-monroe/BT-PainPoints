import React from "react";
import "antd/dist/antd.css";
import CustomColumn from "./CustomColumn"
import { columnNameList } from '../types/dropdownValues/ColumnNameTypes';
import { Button, Col } from "antd";
import PainPointEntity from '../entity/PainPointEntity';
import fakeDataImport from '../types/painPointTestDataArray.api.json';


const fakeData:PainPointEntity[] = fakeDataImport.data.map(m=>new PainPointEntity(m));

interface ICustomColumnsProps {
  data?: PainPointEntity[]
}

interface ICustomColumnsState {
  CustomColumnArray: CustomColumn[]
}

export default class CustomColumns extends React.Component<ICustomColumnsProps, ICustomColumnsState> {
  static defaultProps = {
      data: fakeData
  };

  state: ICustomColumnsState = {
    CustomColumnArray: [new CustomColumn({ menuList: columnNameList, data: this.props.data?this.props.data:[]})]
  };

  handleAddOnClick = (e: any) => {
    console.log("CustomColum Add On Click")
    let { CustomColumnArray } = this.state;
    CustomColumnArray.push(new CustomColumn({ menuList: columnNameList, data: this.props.data?this.props.data:[]}))
    this.setState({ CustomColumnArray });
  }

  render() {    
    const { CustomColumnArray } = this.state;
    const { data } = this.props;
    console.log("RENDERING CUSTOM COLUMNS");
    console.log(JSON.stringify(data));
    return (
      <>
        {CustomColumnArray.map((c, index) => 
          <Col className={index.toString()} key={index} span={6}>
        <CustomColumn key={index} menuList={c.props.menuList} data={data?data:[]} />        
        </Col>
        
        )}
        
        <Button onClick={e => this.handleAddOnClick(e)}>+</Button>
      </>
    )
  }
}