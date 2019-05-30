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
            render: (text: string) => <a href="/home/:id">{text}</a>
        }, 
        {
            title: 'Issue Description',
            dataIndex: 'painPointSummary'
        },
        {
            title: 'Issue Annotation',
            dataIndex: 'painPointAnnotation'
        },
        {
            title: 'Issue Type',
            dataIndex: 'painPointType'
        },
        {
            title: 'Issue Severity',
            dataIndex: 'painPointSeverity'
        },
        {
            title: 'Company Name',
            dataIndex: 'companyName'
        },
        {
            title: 'Industry Type',
            dataIndex: 'industryType'
        },
        {
            title: 'Date Posted',
            dataIndex: 'datetime'
        },
        {
            title: 'Issue Status',
            dataIndex: 'painPointStatus',
            render: () =>  <Select>{statusList.map((s:any) => <Select.Option key={s.id} value={s.id}>{s.name}</Select.Option>)}</Select>
        },
        {
            title: 'Edit Issue',
            dataIndex: 'painPointSummary',
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
