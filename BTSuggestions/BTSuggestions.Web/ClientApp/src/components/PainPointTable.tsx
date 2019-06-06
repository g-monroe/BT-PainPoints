import React from "react";
import "antd/dist/antd.css";
import CustomColumns from "./CustomColumns"
import PainPointEntity from "../entity/PainPointEntity";
import CustomColumnEntity from "../entity/CustomColumnEntity";
import fakeColumnData from '../types/painPointCustomColumns.api.json';
import { columnNameList } from '../types/dropdownValues/columnNameTypes';
import { SelectOptionWithEntityAndWidth } from "../types/dropdownValues/columnNameTypes";
import  { IPainPointHandler, PainPointHandler } from '../utilities/PainPointHandler';

interface IPainPointTableProps{
  painPointHandler?:IPainPointHandler; 
}

interface IPainPointTableState{
  isFetching: boolean;
  customColumnsArray : CustomColumnEntity[];
  currentColumnIndex: number;
  data : PainPointEntity[];
  menuList : SelectOptionWithEntityAndWidth[];
}

export default class PainPointTable extends React.Component<IPainPointTableProps,IPainPointTableState> {
  static defaultProps = {
    painPointHandler: new PainPointHandler()
  };

  state: IPainPointTableState = {
    isFetching: true,
    customColumnsArray: [],
    currentColumnIndex: 0,  
    data: [],
    menuList: []
  };

  componentDidMount = () => {
    this.getData();
  }

   getData = async () => {
    console.log("getData called");
    this.setState({isFetching: true});
    console.log("is fetching true");
    const {painPointHandler} = this.props;
    let { data, customColumnsArray, currentColumnIndex, menuList } = this.state;
    //TODO get data and update customColumnIdArray and data with real data
    if (painPointHandler){
    data =  (await painPointHandler.getAll()).painPointsList.map(m => new PainPointEntity(m));
    }
    customColumnsArray = fakeColumnData.data.map(m=>new CustomColumnEntity(m))
    currentColumnIndex = fakeColumnData.currentColumnIndex;
    menuList = columnNameList;
    this.sortData();
    console.log("sort data complete");
    this.setState({isFetching: false, data, customColumnsArray, currentColumnIndex, menuList})
    console.log("setState");
  }

  sortData = () => {
    console.log("sortData called");
  }

  deleteColumn = (event:any,columnNumber: number) => {
    const { customColumnsArray,currentColumnIndex } = this.state;
    let newArray = customColumnsArray[currentColumnIndex].columnIds.slice(0,columnNumber);
    customColumnsArray[currentColumnIndex].columnIds.slice(columnNumber+1).forEach(c=>newArray.push(c))
    customColumnsArray[currentColumnIndex].columnIds = [...newArray]
    this.setState({ customColumnsArray });
  }

  addColumn = (event: any) => {
    const { customColumnsArray,currentColumnIndex } = this.state;
    let array = customColumnsArray[currentColumnIndex].columnIds;
    array.push(0);
    this.setState ({customColumnsArray});
  }

  changeColumn = (columnNumber: number, columnHeaderId: number) => {
    const { customColumnsArray,currentColumnIndex } = this.state;
    customColumnsArray[currentColumnIndex].columnIds[columnNumber] = columnHeaderId;
    this.setState({ customColumnsArray });
  }




  render () {
    const { isFetching, data, customColumnsArray, currentColumnIndex, menuList } = this.state
   
    return (<>
      {isFetching ? (
      'Table is loading...'
    ) : (
      <CustomColumns data={data} menuList={menuList} 
      customColumnIdArray={customColumnsArray[currentColumnIndex].columnIds} 
      changeColumn={this.changeColumn}
      addColumn={this.addColumn}
      deleteColumn={this.deleteColumn}/>
    ) } 
    </>)

   
  }
}