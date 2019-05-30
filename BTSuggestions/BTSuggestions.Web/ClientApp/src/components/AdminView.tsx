import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Button} from 'antd';
import AdminViewEntity from '../entity/AdminViewEntity';

const { Content, Sider } = Layout;

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
    companyContact?: string,
    companyLocation?: string,
    industryType?: string,
    comments?: string

    //userId?: number,
    //userName: string
}

export default class AdminView extends React.Component<IAdminViewProps, IAdminViewState>{
    static defaultProps = {
    };

    render() {
        const css = "../src/styles/App.css";
        return (
            <Layout>
                <style>
                    {css}
                </style>
                <Content>
                    <h2>Issue table will be displayed here</h2>
                    <h3>Intentionally left blank until list component is finished</h3>
                    <Button>Create Group</Button>
                    <Button>Delete</Button>
                </Content>
            </Layout>
        )
    }
};
