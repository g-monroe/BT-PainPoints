import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Divider, Comment, Tooltip, Button, Input} from 'antd';
import moment from 'moment';
import { ICommentHandler, CommentHandler } from '../utilities/CommentHandler';
import CommentEntity from '../entity/CommentEntity';
import PainPointEntity from '../entity/PainPointEntity';
import { IPainPointHandler, PainPointHandler } from '../utilities/painPointHandler';

const { Content, Sider } = Layout;

export interface IDetailViewProps {
    commentHandler?: ICommentHandler;
    painpointHandler?: IPainPointHandler;
    id: string;
}

interface IDetailViewState {
    result?: PainPointEntity;
    newComment: string;
    comments?: CommentEntity[];
}

export default class DetailView extends React.Component<IDetailViewProps, IDetailViewState>{
    static defaultProps = {
        commentHandler: new CommentHandler(),
        painpointHandler: new PainPointHandler(),
        id: "0"
    };

    state: IDetailViewState = {
        result: undefined,
        comments: undefined,
        newComment: ''
    };

    componentDidMount = async () => {
        const { painpointHandler, id } = this.props;
        if (id) {
            const result = await painpointHandler!.getById(parseInt(id));
            const commentResult = await this.props.painpointHandler!.getCommentsById(parseInt(this.props.id));
            this.setState({ result, comments: commentResult.commentsList });
        }
    }

    renderComments = () => {
        const { comments } = this.state;
        return comments!.map((comment, index) => (
            <Comment key={index} author={this.state.result!.companyContact} content={comment.commentText} datetime={
               <Tooltip title={moment().format('YYYY-MM-DD HH:mm:ss')}><span>{moment().fromNow()}</span></Tooltip>} />))
    };

    handleSubmit = () => {
        if (!this.state.newComment) {
            return;
        }
      
        let newComment = new CommentEntity({
            commentId: 1,
            painPoint: parseInt(this.props.id),
            user: 1,
            commentText: this.state.newComment,
            status: "Completed",
            createdOn: new Date(),
        })
        this.props.commentHandler!.createComment(newComment);
        if (newComment) {
            this.state.comments!.push(newComment);
        }
        this.setState(
            {
                newComment: ' '
            }
        );
     
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
                    <Content>
                        <h1>Issue: {result.title}</h1>
                        <h2>Type: {result.types.join(",")}; &nbsp;&nbsp;&nbsp; Severity Level: {result.priorityLevel}</h2>
                        <h3>Summary: {result.summary}</h3>
                        <h3>Personal Notes: {result.annotation}</h3>
                        <Divider>Comments</Divider>
                            {this.renderComments()}
                        <Input placeholder="New Comment" value={this.state.newComment} onChange={this.handleChange}/>
                        <Button onClick={this.handleSubmit}>Submit Comment</Button>
                    </Content>
                    <Sider style={{ background: '#fff' }} >
                        <h1>Submitted By:</h1>
                        <h2>{result.companyContact}</h2>
                        <h3>{result.companyName}</h3>
                        <h3>{result.companyLocation}</h3>
                    </Sider>
                </Layout>
            )
        } else {
            return <h2>This issue has been resolved.</h2>;
        }
    }
};