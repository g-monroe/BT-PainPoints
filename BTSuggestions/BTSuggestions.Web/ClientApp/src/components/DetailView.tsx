import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Divider, Comment, Tooltip, Button, Input, Breadcrumb, Card, Empty, Alert} from 'antd';
import moment from 'moment';
import { ICommentHandler, CommentHandler } from '../utilities/CommentHandler';
import CommentEntity from '../entity/CommentEntity';
import PainPointEntity from '../entity/PainPointEntity';
import { IPainPointHandler, PainPointHandler } from '../utilities/painPointHandler';
import '../styles/DetailView.css';

const { Content} = Layout;

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
        if (comments != null) {
            let displayedComments = comments;
            if (displayedComments.length < 5) {
                return displayedComments.map((comment, index) => (
                    <Comment key={index} author={this.state.result!.companyContact} content={comment.commentText} datetime={this.renderCreatedOn(comment.createdOn)} />))
            }
            else {
                return displayedComments.slice(displayedComments.length - 5, displayedComments.length).map((comment, index) => (<Comment key={index} author={this.state.result!.companyContact} content={comment.commentText} datetime={this.renderCreatedOn(comment.createdOn)} />))
            }
        }
        else {
            return <Empty image={Empty.PRESENTED_IMAGE_SIMPLE}/>;
        }
    };

    renderAllComments = () => {
        const { comments } = this.state;
        if (comments != null) {
            return comments.map((comment, index) => (
                <Comment key={index} author={this.state.result!.companyContact} content={comment.commentText} datetime={this.renderCreatedOn(comment.createdOn)} />))
        }
        else{
            return <Empty image={Empty.PRESENTED_IMAGE_SIMPLE}/>;
        }
    }

    renderCreatedOn = (createdOn: Date) => {
        if (createdOn.toString() != null) {
            return <Tooltip title={moment().format('MM-DD-YYYY')}><span>{moment(createdOn.toString()).format('HH:mm on MM-DD-YYYY')}</span></Tooltip>
        }
        else {
            return <Tooltip title={moment().format('YYYY-MM-DD HH:mm:ss')}><span>{moment().fromNow()}</span></Tooltip>
        }
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
    };

    hideElement = (id: string) => {
        let element = document.getElementById(id);
        if (id === "allComments") {
            this.hideElement("recents");
        }
        if (element != null) {
            if (element.style.display === "none") {
                element.style.display = "block";
            }
            else {
                element.style.display = "none";
            }
        }
    };

    render() {
        const { result } = this.state;
        if (result) {  
            return (
                <Layout>
                    <Content>
                        <Breadcrumb style={{ margin: '16px'}}>
                            <Breadcrumb.Item>Admin</Breadcrumb.Item>
                            <Breadcrumb.Item>Issues</Breadcrumb.Item>
                            <Breadcrumb.Item>{result.title}</Breadcrumb.Item>
                        </Breadcrumb>
                        <div style={{ background: '#fff', padding: 24, minHeight: 380 }}>
                            <Card title={result.title}>
                                <Card type="inner" title="Issue Information" extra={<Button onClick={()=>this.hideElement("issueTable")}>Collapse</Button>}>
                                    <table className="table" id="issueTable">
                                        <tbody>
                                            <tr>
                                                <th colSpan={1} className="first-column">Date Created</th>
                                                <td colSpan={2}>{result.createdOn}</td>
                                                <th colSpan={4} className="second-column">Issue Type</th>
                                                <td colSpan={1}>{result.types}</td>
                                            </tr>
                                            <tr>
                                                    <th colSpan={1} className="first-column">Issue Summary</th>
                                                    <td colSpan={3}>{result.summary}</td>
                                                    <th colSpan={1} className="second-column">Severity Level</th>
                                                    <td colSpan={1}>{result.priorityLevel}</td>
                                            </tr>
                                            <tr>
                                                <th colSpan={1} className="first-column">Personal Notes</th>
                                                <td colSpan={3}>{result.annotation}</td>
                                                <th colSpan={1} className="second-column">Issue Status</th>
                                                <td colSpan={1}>{result.status}</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </Card>
                                <Card type="inner" title="Client Information" extra={<Button onClick={()=>this.hideElement("clientTable")}>Collapse</Button>}>
                                    <table className="table" id="clientTable">
                                            <tbody>
                                                <tr>
                                                    <th colSpan={1} className="first-column">Company Contact</th>
                                                    <td colSpan={2}>{result.companyContact}</td>
                                                    <th colSpan={1} className="second-column">Company Name</th>
                                                    <td colSpan={2}>{result.companyName}</td>
                                                    <th colSpan={1} className="third-column">Company Location</th>
                                                    <td colSpan={3}>{result.companyLocation}</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                </Card>
                            </Card>
                        </div>
                        <Divider>Comments</Divider>
                        <div id="recents" className="new-comment"><Alert message="Displaying Most Recent Comments" type="info"/></div>
                        <div id="allComments" style={{display:'none'}}  >
                        {this.renderAllComments()}
                        </div>
                        {this.renderComments()}
                            <div className="wrapper">
                                <Input placeholder="New Comment" value={this.state.newComment} onChange={this.handleChange} className="new-comment"/>
                            <Button className="comments-button" onClick={this.handleSubmit}>Submit Comment</Button>
                            <Button className="comments-button" onClick={()=>this.hideElement("allComments")}>See All Comments</Button>
                            </div>
                    </Content>
                </Layout>
            )
        } else {
            return <h2>This issue has been resolved.</h2>;
        }
    }
};