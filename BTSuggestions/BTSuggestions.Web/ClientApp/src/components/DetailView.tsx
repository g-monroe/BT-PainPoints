import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Divider, Comment, Tooltip, Button, Form} from 'antd';
import DetailViewEntity from '../entity/DetailViewEntity';
import moment from 'moment';
import TextArea from 'antd/lib/input/TextArea';
const { Content, Sider } = Layout;

interface IDetailViewProps {
    data: DetailViewEntity;
}

interface IDetailViewState {
}

const Editor = (onChange:any, onSubmit:any, submitting:any, value:any) => (
  <>
        <Form.Item>
            <TextArea rows={4} onChange={onChange} value={value}/>
        </Form.Item>      
        <Form.Item>
            <Button htmlType="submit" loading={submitting} onClick={onSubmit} type="primary">Send</Button>
        </Form.Item>
    </>
);

export default class DetailView extends React.Component<IDetailViewProps, IDetailViewState>{
    static defaultProps = {
    };

    state = {
        submitting: false,
        value: '',
        comments: []
    };

    renderComments = (comments: string[]) => {
        const { companyContact } = this.props.data;
        return comments.map((comment, index) => (
            <Comment key={index} author={companyContact} content={comment} datetime={
                <Tooltip title={moment().format('YYYY-MM-DD HH:mm:ss')}><span>{moment().fromNow()}</span></Tooltip>} />))
    };

    handleChange = (e: any) => {
        this.setState({
            value: e.target.value
        });
    };

    handleSubmit = () => {
        if (!this.state.value) {
            return;
        }
        this.setState({
            submitting: true
        });

        setTimeout(() => {
            this.setState({
                submitting: false,
                value: '',
                comments: [
                    {
                        author: 'Test User',
                        content: <p>{this.state.value}</p>,
                        datetime: moment().fromNow()
                    },
                    ...this.state.comments,
                ],
            });
        }, 1000);
    };
    
    render() {
        const css = "../src/styles/App.css";
        const { submitting, value } = this.state;
        console.log(value)
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
                    <Comment content={<Editor onChange={this.handleChange} onSubmit={this.handleSubmit} submitting={submitting} value={value} />} />
                    
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
