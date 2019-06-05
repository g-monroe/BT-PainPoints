import PainPointEntity from "./PainPointEntity";
import UserEntity from "./UserEntity";
export default class CommentEntity {
    commentId: number;
    painPointId: number;
    userId: number;
    commentText: string;
    status: string;
    createdOn: Date;

    constructor(JSONData: any) {
        this.commentId = JSONData.commentId;
        this.painPointId = JSONData.painPoint;
        this.userId = JSONData.user;
        this.commentText = JSONData.commentText;
        this.status = JSONData.status;
        this.createdOn = JSONData.createdOn;
    }
}