import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Button, Table, Icon, Select} from 'antd';
import AdminViewEntity from '../entity/AdminViewEntity';
import { statusList } from '../types/dropdownValues/statusTypes';

const { Content} = Layout;

interface IAdminViewProps {
    data: AdminViewEntity;
}

interface IAdminViewState {
    painPointType: string,
    painPointTitle: string,
    painPointSummary: string,
    painPointAnnotation?: string,
    painPointSeverity: number,

    companyName?: string,
    industryType?: string,
    comments?: string

    //userId?: number,
    //userName: string
}

export default class AdminView extends React.Component<IAdminViewProps, IAdminViewState>{
    static defaultProps = {
    };

    columns = [
        {
            title: 'Issue Title',
            dataIndex: 'painPointTitle',
            fixed: true,
            //align: 'center',
            render: (text: string) => <a href="/home/:id">{text}</a>
        }, 
        {
            title: 'Description',
            dataIndex: 'painPointSummary'
        },
        {
            title: 'Annotation',
            dataIndex: 'painPointAnnotation',
            width: 200
        },
        {
            title: 'Issue Type',
            dataIndex: 'painPointType',
            //align: 'center'
        },
        {
            title: 'Severity',
            dataIndex: 'painPointSeverity',
            //align: 'center'
        },
        {
            title: 'Company Name',
            dataIndex: 'companyName',
            //align: 'center'
        },
        {
            title: 'Industry Type',
            dataIndex: 'industryType',
            //align: 'center'
        },
        {
            title: 'Date Posted',
            dataIndex: 'datetime',
            //display: 'center'
        },
        {
            title: 'Issue Status',
            dataIndex: 'painPointStatus',
            //align:'center',
            width: 200,
            render: () =>  <Select defaultValue="None Selected">{statusList.map((s:any) => <Select.Option key={s.id} value={s.id}>{s.name}</Select.Option>)}</Select>
        },
        {
            title: 'Edit',
            dataIndex: 'painPointSummary',
            width: 25,
            render: () => <Icon type="edit" />
        },
    ]

    rowSelection = {
        getCheckboxProps: (record: string )=> ({
            name: record
        })
    };

    render() {
        const css = "../src/styles/App.css";
        return (
            <Layout>
                <style>
                    {css}
                </style>
                <Content>
                    <h2>There should probably be a title here</h2>
                    <Table rowSelection={this.rowSelection} columns={this.columns} dataSource={this.props.data.issues} scroll={{x : 1300}}/>
                    <Button>Create Group</Button>
                    <Button>Delete</Button>
                </Content>
            </Layout>
        )
    }
};
