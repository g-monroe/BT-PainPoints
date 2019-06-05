import CommentEntity from "./CommentEntity";

export default class CommentEntities{
    comments: CommentEntity[];
    constructor( jsonData: any){
        this.comments = jsonData.commentsList.map((x:string) => new CommentEntity(x));
    }
}
