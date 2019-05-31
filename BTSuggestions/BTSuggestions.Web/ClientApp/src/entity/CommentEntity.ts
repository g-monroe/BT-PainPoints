export class CommentEntity {
    comments: string[];

    constructor(JSONData: any) {
        this.comments = JSONData.comments;
    }
}