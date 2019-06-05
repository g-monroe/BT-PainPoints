export class CommentsEntity {
    comments: string[];

    constructor(JSONData: any) {
        this.comments = JSONData.comments;
    }
}