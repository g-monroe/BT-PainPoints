import { APIHandler } from './apiHandler';
import PainPointEntity  from '../entity/PainPointEntity';
import AdminViewEntity from '../entity/AdminViewEntity';
import CommentEntity from '../entity/CommentEntity';
import CommentEntities from '../entity/CommentEntities';

export interface IPainPointHandler{
    getAll(): Promise<PainPointEntity>;
    getById(id: number): Promise<PainPointEntity>;
    getCommentsById(id: number): Promise<CommentEntities>;
    createHero(issue:PainPointEntity): Promise<PainPointEntity>;
    deleteById(id: number): Promise<PainPointEntity>;
    updateById(id: number, entity:PainPointEntity): Promise<PainPointEntity>;
}
export class CommentCollectionResponse{
    collection: CommentEntity[]
    constructor(data: any[]){
        this.collection = data.map(d => new CommentEntity(d));
    }
}
export class PainPointHandler implements IPainPointHandler{
    //Get Element by ID and then respond with the Item.
    async getById(id: number): Promise<PainPointEntity>{
        return await APIHandler(`/api/painpoint/${id}`, {
            method: "GET",
            responseType: PainPointEntity
        });
    }
    async getAll(): Promise<PainPointEntity>{
        return await APIHandler(`/api/painpoint`, {
            method: "GET",
            responseType: PainPointEntity
        });
    }
    async getCommentsById(id: number): Promise<CommentEntities>{
       
        return await APIHandler(`/api/painpoint/${id}/comments`, {
            method: "GET",
            responseType: CommentEntities
           
        });
    }
    //Create Element by ID and then respond with the Item.
    async createHero(issue:PainPointEntity): Promise<PainPointEntity>{
        return await APIHandler(`/api/painpoint`, {
            method: "POST",
            data: issue,
            responseType:PainPointEntity
        });
    }
    //Delete Element by ID and then respond with the Item.
    async deleteById(id: number): Promise<PainPointEntity>{
        return await APIHandler(`/api/painpoint/${id}`, {
            method: "DELETE",
            responseType:PainPointEntity
        });
    }
    //Update Element by ID and then respond with the Item.
    async updateById(id: number, entity:PainPointEntity): Promise<PainPointEntity>{
        return await APIHandler(`/api/painpoint/${id}`, {
            method: "PUT",
            data: entity,
            responseType:PainPointEntity
        });
    }
}
