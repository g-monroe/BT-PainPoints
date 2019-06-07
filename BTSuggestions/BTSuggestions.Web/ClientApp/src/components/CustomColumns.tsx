import React from "react";
import "antd/dist/antd.css";
import CustomColumn from "./CustomColumn"
import { SelectOptionWithEntityAndWidth } from '../types/dropdownValues/columnNameTypes';
import { Table, Input, Button, Icon } from "antd";
import PainPointEntity from '../entity/PainPointEntity';
import "../styles/CustomColumns.css"
import { ColumnProps } from "antd/lib/table/interface";

interface ICustomColumnsProps {
  data: PainPointEntity[];
  menuList: SelectOptionWithEntityAndWidth[];
  customColumnIdArray: number[];
  changeColumn: (columnNumber: number, columnHeaderId: number) => void;
  addColumn: (e: any) => void;
  deleteColumn: (event: any, columnNumber: number) => void;
}

interface ICustomColumnsState {
  searchText: any;
}

export default class CustomColumns extends React.Component<ICustomColumnsProps, ICustomColumnsState> {
  static defaultProps = {
    data: [],
    menuList: []
  };

  state: ICustomColumnsState = {
    searchText: ''
  };
  searchInput: any;

  constructor(props: ICustomColumnsProps) {
    super(props);
    this.searchInput = React.createRef<HTMLInputElement>();
  }

   uuidv4 = () => {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }

  getColumns = () => {
    const { customColumnIdArray, menuList, data, changeColumn, addColumn, deleteColumn } = this.props;
    let columns: ColumnProps<PainPointEntity>[];
    columns = [];
    customColumnIdArray.forEach((id, index) => {
      columns.push({
        key: menuList[id].entityName + "-index:"+index,
        width: menuList[id].width,        
        title: <CustomColumn menuList={menuList}
          data={data}
          columnNumber={index}
          columnLabel={menuList[id]}
          changeColumn={changeColumn}
          deleteColumn={deleteColumn} />,
          dataIndex: menuList[id].entityName,
          defaultSortOrder: 'descend',
          sorter: (a, b) => {
            if(a[menuList[id].entityName] < b[menuList[id].entityName]) { return -1; }
            if(a[menuList[id].entityName] > b[menuList[id].entityName]) { return 1; }
            return 0;},
        ...this.getColumnSearchProps(menuList[id].entityName)        
      });
    });
    columns.push({
      key: "addNew",
      width: 50,
      title: <span style={{ cursor: "crosshair" }}><AddNewButton addColumn={addColumn} /></span>,
    });
    return columns;
  };

  onRow = (record: PainPointEntity, rowIndex: number) => {
    return {
      onClick: (e: any) => {
        e.preventDefault();
        window.location.href = '/home/' + record.painPointId;
      },
    };
  }

  getColumnSearchProps = (dataIndex: any) => ({
    filterDropdown: ({
      setSelectedKeys,
      selectedKeys,
      confirm,
      clearFilters }) => {
        console.log("INPUT: SK" + selectedKeys[0]);
      return (
        <div style={{ padding: 8 }}>
          <Input
            ref={node => {              
              this.searchInput = node;
            }}
            placeholder={`Search ${dataIndex}`}
            value={selectedKeys[0]}
            onChange={e => setSelectedKeys(e.target.value ? [e.target.value] : [])}
            onPressEnter={() => this.handleSearch(selectedKeys, confirm)}
            style={{ width: 188, marginBottom: 8, display: 'block' }}
          />
          <Button
            type="primary"
            onClick={() => this.handleSearch(selectedKeys, confirm)}
            icon="search"
            size="small"
            style={{ width: 90, marginRight: 8 }}
          >
            Search
        </Button>
          <Button onClick={() => this.handleReset(clearFilters)} size="small" style={{ width: 90 }}>
            Reset
        </Button>
        </div>
      )
    },
    filterIcon: (filtered: any) => (
      <Icon type="search" style={{ color: filtered ? '#1890ff' : undefined }} />
    ),
    onFilter: (value: any, record: any) => {
    console.log("onFilter: " +JSON.stringify(record));
    console.log("onFilter: " +JSON.stringify(dataIndex));
      return (
        record[dataIndex]
        .toString()
        .toLowerCase()
        .includes(value.toLowerCase()))},
         onFilterDropdownVisibleChange: (visible: any) => {
      if (visible) {
        setTimeout(() => this.searchInput.select());
      }
    },
  });

  handleSearch = (selectedKeys: any, confirm: any) => {
    confirm();
    this.setState({ searchText: selectedKeys[0] });
  };

  handleReset = (clearFilters: any) => {
    clearFilters();
    this.setState({ searchText: '' });
  };

  render() {
    const { data } = this.props;
    const columns = this.getColumns();
    return (
      <>
        <Table onRow={this.onRow} showHeader={true} pagination={false}
          columns={columns} dataSource={data}
          scroll={{ x: 1300 }}
        />
      </>
    )
  }
}

const AddNewButton = (props: any) => {
  return (<div onClick={props.addColumn}>+</div>);
};

