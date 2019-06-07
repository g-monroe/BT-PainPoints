import { APIHandler } from './apiHandler';
import PainPointEntity  from '../entity/PainPointEntity';
import CommentEntity from '../entity/CommentEntity';
import BooleanEntity from '../entity/BooleanEntity';
export interface IPainPointHandler{
    getAll(): Promise<PainPointCollectionResponse>;
    getById(id: number): Promise<PainPointEntity>;
    getCommentsById(id: number): Promise<CommentCollectionResponse>;    
    createPainPoint(issue:PainPointEntity): Promise<PainPointEntity>;
    deleteById(id: number, userid: number): Promise<BooleanEntity>;
    updateById(id: number, entity:PainPointEntity): Promise<PainPointEntity>;
}
export class PainPointCollectionResponse{
    painPointsList: PainPointEntity[]
    constructor(data: PainPointCollectionResponse){
        this.painPointsList = data.painPointsList.map(d => new PainPointEntity(d));
    }
}

export class CommentCollectionResponse{
    commentsList: CommentEntity[]
    constructor(data: CommentCollectionResponse){
        this.commentsList = data.commentsList.map(d => new CommentEntity(d));
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

    async getAll(): Promise<PainPointCollectionResponse>{
        return await APIHandler(`/api/painpoint`, {
            method: "GET",
            responseType: PainPointCollectionResponse
        });
    }

    async getCommentsById(id: number): Promise<CommentCollectionResponse>{
       
        return await APIHandler(`/api/painpoint/${id}/comments`, {
            method: "GET",
            responseType: CommentCollectionResponse
           
        });
    }
   
    //Create Element by ID and then respond with the Item.
    async createPainPoint(issue:PainPointEntity): Promise<PainPointEntity>{
        return await APIHandler(`/api/painpoint`, {
            method: "POST",
            data: issue,
            responseType:PainPointEntity
        });
    }

    //Delete Element by ID and then respond with the Item.
    async deleteById(id: number, userid: number): Promise<BooleanEntity>{
        return await APIHandler(`/api/painpoint/${id}/user/${userid}`, {
            method: "DELETE",
            responseType: BooleanEntity
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

