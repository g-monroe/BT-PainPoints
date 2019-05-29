import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Divider, Comment, Tooltip } from 'antd';
import DetailViewEntity from '../entity/DetailViewEntity';
import moment from 'moment';

const { Content, Sider } = Layout;

interface IDetailViewProps {
    data: DetailViewEntity;
}

interface IDetailViewState {
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

export default class DetailView extends React.Component<IDetailViewProps, IDetailViewState>{
    static defaultProps = {
    };

    renderComments = (comments : string[]) => {
        const { companyContact } = this.props.data;
        return comments.map((comment, index) => (
            <Comment key={index} author={companyContact} content={comment} datetime={
                <Tooltip title={moment().format('YYYY-MM-DD HH:mm:ss')}><span>{moment().fromNow()}</span></Tooltip>} />))
    }

    render() {
        const css = "../src/styles/App.css";
        return (
            <Layout>
                <style>
                    {css}
                </style>
                <Content>
                    <h1>Issue: {this.props.data.painPointTitle}</h1>
                    <h2>Type: {this.props.data.painPointType}, Severity Level: {this.props.data.painPointSeverity}</h2>
                    <h3>Summary: {this.props.data.painPointSummary}</h3>
                    <h3>Personal Notes: {this.props.data.painPointAnnotation}</h3>
                    <Divider>Comments</Divider>
                    {this.renderComments(this.props.data.comments)}
                </Content>
                <Sider style={{ background: '#fff' }}>
                    <h1>Submitted By:</h1>
                    <h2>{this.props.data.companyContact}</h2>
                    <h3>{this.props.data.companyName}</h3>
                    <h3>{this.props.data.companyLocation}</h3>
                </Sider>
            </Layout>
        )
    }
};
