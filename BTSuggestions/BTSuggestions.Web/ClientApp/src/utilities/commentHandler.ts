import { APIHandler } from '../utilities/apiHandler';
import { CreateFormEntity } from '../entity/CreateFormEntity';

export interface ICommentHandler{
    getUserName(id: number): any;
}

export class CommentHandler implements ICommentHandler{
    getUserName(id: number) {
        return APIHandler(`/api/comments/${id}`, {
            method: 'GET',
            responseType: CreateFormEntity
        })
    }
}