import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Divider, Comment, Tooltip, Button, Input } from 'antd';
import DetailViewEntity from '../entity/DetailViewEntity';
import moment from 'moment';
import { ICommentHandler, CommentHandler } from '../utilities/CommentHandler';
import CommentEntity from '../entity/CommentEntity';
import UserEntity from '../entity/UserEntity';
import PainPointEntity from '../entity/PainPointEntity';
import { IPainPointHandler, PainPointHandler } from '../utilities/PainPointHandler';
import CommentEntities from '../entity/CommentEntities';

const { Content, Sider } = Layout;

interface IDetailViewProps {
    commentHandler?: ICommentHandler;
    painpointHandler?: IPainPointHandler;
    id: number;
}

interface IDetailViewState {
    result?: PainPointEntity;
    newComment: string;
    comments?: CommentEntity[];
}

export default class DetailView extends React.Component<IDetailViewProps, IDetailViewState>{
    static defaultProps = {
        commentHandler: new CommentHandler(),
        painpointHandler: new PainPointHandler()
    };

    state: IDetailViewState = {
        result: undefined,
        comments: undefined,
        newComment: ''
    };
    componentDidMount = async () => {
        const { painpointHandler, id } = this.props;
        if (id) {
            const result = await painpointHandler!.getById(id);
            const commentResult = await this.props.painpointHandler!.getCommentsById(this.props.id);
            this.setState({ result, comments: commentResult.comments });
        }
    }
    renderComments = () => {
        //let painResult = await this.props.painpointHandler!.getById(this.props.id);
        const { comments } = this.state;
        return comments!.map((comment, index) => (
            <Comment key={index} author={this.state.result!.CompanyContact} content={comment.commentText} datetime={
                <Tooltip title={moment().format('YYYY-MM-DD HH:mm:ss')}><span>{moment().fromNow()}</span></Tooltip>} />))
    };

    handleSubmit = () => {
        if (!this.state.newComment) {
            return;
        }
       
        this.setState(
            { newComment: ' ' }
        );
        let newComment = new CommentEntity({
            commentId: 1,
            painPoint: this.props.id,
            user: 1,
            commentText: "test",
            status: "Completed",
            createdOn: new Date(),
        })
        this.props.commentHandler!.createComment(newComment);

    };

    handleChange = (e: any) => {
        this.setState(
            { newComment: e.target.value },
        )
    }

    render() {
        const css = "../src/styles/App.css";
        const { result } = this.state;
      
        if (result) {
            
            return (
                <Layout>
                    <style>
                        {css}
                    </style>
                    <Content>
                        <h1>Issue: {result.Title}</h1>
                        <h2>Type: {result.Types.join(", ")}; &nbsp;&nbsp;&nbsp; Severity Level: {result.PriorityLevel}</h2>
                        <h3>Summary: {result.Summary}</h3>
                        <h3>Personal Notes: {result.Annotation}</h3>
                        <Divider>Comments</Divider>
                        {this.renderComments()}
                        <Input placeholder="New Comment" value={this.state.newComment} onChange={this.handleChange} />
                        <Button onClick={this.handleSubmit}>Submit Comment</Button>
                    </Content>
                    <Sider style={{ background: '#fff' }} >
                        <h1>Submitted By:</h1>
                        <h2>{result.CompanyContact}</h2>
                        <h3>{result.CompanyName}</h3>
                        <h3>{result.CompanyLocation}</h3>
                    </Sider>
                </Layout>
            )
        } else {
            return <h1>Nothing to render!</h1>;
        }
    }
};