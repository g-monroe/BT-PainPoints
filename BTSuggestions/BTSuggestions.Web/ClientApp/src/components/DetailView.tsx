import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Divider, Comment, Tooltip, Button, Input} from 'antd';
import DetailViewEntity from '../entity/DetailViewEntity';
import moment from 'moment';
//import { APIHandler } from '../utilities/apiHandler';
//import { CommentEntity } from '../entity/CommentEntity';

const { Content, Sider } = Layout;

interface IDetailViewProps {
    data: DetailViewEntity;

}

interface IDetailViewState {
}

export default class DetailView extends React.Component<IDetailViewProps, IDetailViewState>{
    static defaultProps = {
    };

    state = {
        newComment: ''
    };

    renderComments = (comments: string[]) => {
        const { companyContact } = this.props.data;
        return comments.map((comment, index) => (
            <Comment key={index} author={companyContact} content={comment} datetime={
                <Tooltip title={moment().format('YYYY-MM-DD HH:mm:ss')}><span>{moment().fromNow()}</span></Tooltip>} />))
    };

    handleSubmit = () => {
        if (!this.state.newComment) {
            return;
        }
        this.props.data.comments = [...this.props.data.comments, this.state.newComment];
        this.setState(
            { newComment: ' ' }
        );
        /* APIHandler(`/home/$id`, {
            method: 'POST',
            responseType: CommentEntity
        }).then(function(r:any) {
            console.log(r);
        }); */
    };

    handleChange = (e : any) => {
        this.setState(
            { newComment: e.target.value },
        )
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
                    <h2>Type: {this.props.data.painPointType.join(",")}; &nbsp;&nbsp;&nbsp; Severity Level: {this.props.data.painPointSeverity}</h2>
                    <h3>Summary: {this.props.data.painPointSummary}</h3>
                    <h3>Personal Notes: {this.props.data.painPointAnnotation}</h3>
                    <Divider>Comments</Divider>
                        {this.renderComments(this.props.data.comments)}
                    <Input placeholder="New Comment" value={this.state.newComment} onChange={this.handleChange}/>
                    <Button onClick={this.handleSubmit}>Submit Comment</Button>
                </Content>
                <Sider style={{ background: '#fff' }} >
                    <h1>Submitted By:</h1>
                    <h2>{this.props.data.companyContact}</h2>
                    <h3>{this.props.data.companyName}</h3>
                    <h3>{this.props.data.companyLocation}</h3>
                </Sider>
            </Layout>
        )
    }
};