import PainPointEntity from "./PainPointEntity";
import UserEntity from "./UserEntity";
export default class CommentEntity {
    commentId: number;
    painPoint: PainPointEntity;
    user: UserEntity;
    commentText: string;
    status: string;
    createdOn: Date;

    constructor(JSONData: any) {
        this.commentId = JSONData.commentId;
        this.painPoint = JSONData.painPoint;
        this.user = JSONData.user;
        this.commentText = JSONData.commentText;
        this.status = JSONData.status;
        this.createdOn = JSONData.createdOn;
    }
}