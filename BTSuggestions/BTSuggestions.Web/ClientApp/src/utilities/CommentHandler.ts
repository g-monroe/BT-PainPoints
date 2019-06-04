import { APIHandler } from './apiHandler';
import CommentEntity from '../entity/UserEntity';
import UserEntity from '../entity/UserEntity';
export interface ICommentHandler{
    getById(id: number): Promise<CommentEntity>;
    createComment(comment: UserEntity): Promise<CommentEntity>;
    deleteById(id: number): Promise<CommentEntity>;
    updateById(id: number, entity: CommentEntity): Promise<CommentEntity>;
}
// export class SuperheroCollectionResponse{
//     collection: SuperheroItem[]
//     constructor(data: any[]){
//         this.collection = data.map(d => new SuperheroItem(d));
//     }
// }
export class CommentHandler implements ICommentHandler{
    //Get Element by ID and then respond with the Item.
    async getById(id: number): Promise<CommentEntity>{
        return await APIHandler(`/api/comment/${id}`, {
            method: "GET",
            responseType: CommentEntity
        });
    }
    //Create Element by ID and then respond with the Item.
    async createComment(comment: CommentEntity): Promise<CommentEntity>{
        return await APIHandler(`/api/comment`, {
            method: "POST",
            data: comment,
            responseType: CommentEntity
        });
    }
    //Delete Element by ID and then respond with the Item.
    async deleteById(id: number): Promise<CommentEntity>{
        return await APIHandler(`/api/comment/${id}`, {
            method: "DELETE",
            responseType: CommentEntity
        });
    }
    // //Update Element by ID and then respond with the Item.
    async updateById(id: number, entity: CommentEntity): Promise<CommentEntity>{
        return await APIHandler(`/api/comment/${id}`, {
            method: "PUT",
            data: entity,
            responseType: CommentEntity
        });
    }
}

