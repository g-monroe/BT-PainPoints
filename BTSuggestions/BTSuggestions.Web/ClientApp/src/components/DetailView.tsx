import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Divider, Comment, Tooltip, Button, Input, Progress, PageHeader, Tag } from 'antd';
import DetailViewEntity from '../entity/DetailViewEntity';
import moment from 'moment';
import { ICommentHandler, CommentHandler } from '../utilities/CommentHandler';
import CommentEntity from '../entity/CommentEntity';
import UserEntity from '../entity/UserEntity';
import PainPointEntity from '../entity/PainPointEntity';
import CommentEntities from '../entity/CommentEntities';
import { IPainPointHandler, PainPointHandler } from '../utilities/painPointHandler';

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
            // const commentResult = await this.props.painpointHandler!.getCommentsById(this.props.id);
            //this.setState({ result, comments: commentResult.comments });
        }
    }
    refreshMount = async () => {
        const { painpointHandler, id } = this.props;
        if (id) {
            const result = await painpointHandler!.getById(id);
           // const commentResult = await this.props.painpointHandler!.getCommentsById(this.props.id);
            //this.setState({ result, comments: commentResult.comments });
        }
    }
    renderComments = () => {
        const { comments } = this.state;
        //return comments!.map((comment, index) => (
            //<Comment key={index} author={this.state.result!.CompanyContact} content={comment.commentText} datetime={
              //  <Tooltip title={moment().format('YYYY-MM-DD HH:mm:ss')}><span>{moment().fromNow()}</span></Tooltip>} />))
    };

    handleSubmit = () => {
        if (!this.state.newComment) {
            return;
        }
      
        let newComment = new CommentEntity({
            commentId: 1,
            painPoint: this.props.id,
            user: 1,
            commentText: this.state.newComment,
            status: "Completed",
            createdOn: new Date(),
        })
        this.props.commentHandler!.createComment(newComment);
        this.setState(
            { newComment: ' ' }
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
                    <style>
                        {css}
                    </style>
                    <Content style={{padding: '20px'}}>
                         {/* <PageHeader onBack={() => null} title={result.Title} tags={<Tag color="red">{result.Types.join(", ")}</Tag>}/>, */}
                        <h3>Summary:</h3>
                       {/* // <p>{result.Summary}</p> */}
                        {/* //<i>Personal Notes: {result.Annotation}</i> */}
                        <Progress
                            strokeColor={{
                                '0%': '#108ee9',
                                '100%': '#87d068',
                            }}
                            // percent={result.PriorityLevel}
                            />
                        <hr/>
                        {/* <p>Submitted by: {result.CompanyContact} at {result.CompanyName}({result.CompanyLocation})</p> */}
                       
                        <Divider>Comments</Divider>
                        {this.renderComments()}
                        <Input placeholder="New Comment" value={this.state.newComment} onChange={this.handleChange} />
                        <Button onClick={this.handleSubmit}>Submit Comment</Button>
                       
                    </Content>
                </Layout>
            )
        } else {
            return <h1>Nothing to render!</h1>;
        }
    }
};