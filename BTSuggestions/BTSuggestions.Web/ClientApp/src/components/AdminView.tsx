import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Button, Table, Icon, Select, Input, InputNumber} from 'antd';
import AdminViewEntity from '../entity/AdminViewEntity';
import { statusList } from '../types/dropdownValues/statusTypes';
import { painPointList } from '../types/dropdownValues/painPointTypes';
import { industryList } from '../types/dropdownValues/industryTypes';

const { Content} = Layout;

interface IAdminViewProps {
    data: AdminViewEntity;
}

interface IAdminViewState {
    issues: any[]
}

export default class AdminView extends React.Component<IAdminViewProps, IAdminViewState>{
    static defaultProps = {
    };

    state = {
        issues: this.props.data.issues
    }

    columns = [
        {
            title: 'Issue Title',
            dataIndex: 'painPointTitle',
            fixed: true,
            render: (text: string) => <a href="/home/:id">{text}</a>
        }, 
        {
            title: 'ID',
            width: 50,
            dataIndex: 'painPointId'
        },
        {
            title: 'Description',
            width: 250,
            dataIndex: 'painPointSummary',
            render: (text: string) => <Input value={text}/>
        },
        {
            title: 'Annotation',
            width: 250,
            dataIndex: 'painPointAnnotation',
            render: (text: string) => <Input value={text}/>
        },
        {
            title: 'Issue Type',
            dataIndex: 'painPointType',
            width: 100,
            render: (text : string) => <Select defaultValue={text}>{painPointList.map((s:any) => <Select.Option key={s.id} value={s.id}>{s.name}</Select.Option>)}</Select>
        },
        {
            title: 'Severity',
            dataIndex: 'painPointSeverity',
            width: 15,
            render: (text: number) => <InputNumber value={text}/>
        },
        {
            title: 'Company Name',
            dataIndex: 'companyName',
            width: 150,
            render: (text: string) => <Input value={text}/>
        },
        {
            title: 'Industry Type',
            dataIndex: 'industryType',
            render: (text: string) => <Select defaultValue={text}>{industryList.map((s:any) => <Select.Option key={s.id} value={s.id}>{s.name}</Select.Option>)}</Select>
        },
        {
            title: 'Date Posted',
            dataIndex: 'datetime'
        },
        {
            title: 'Issue Status',
            dataIndex: 'submissionStatus',
            width: 200,
            render: (text: string) => <Select defaultValue={text}>{statusList.map((s:any) => <Select.Option key={s.id} value={s.id}>{s.name}</Select.Option>)}</Select>
        },
        {
            title: 'Edit',
            dataIndex: 'editIndex',
            width: 25,
            render: (index: number) => <Button onClick={()=>alert("Clicked!")}><Icon type="edit"></Icon></Button>
        },
    ]

    rowSelection = {
        getCheckboxProps: (record: string) => ({
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
                    <Table rowSelection={this.rowSelection} columns={this.columns} dataSource={this.state.issues} scroll={{ x: 1300 }}/>
                    <Button>Create Group</Button>
                    <Button>Delete</Button>
                </Content>
            </Layout>
        )
    }
};
