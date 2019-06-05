import { APIHandler } from './apiHandler';
import PainPointEntity  from '../entity/PainPointEntity';

export interface IPainPointHandler{
    getAll(): Promise<PainPointCollectionResponse>;
    getById(id: number): Promise<PainPointEntity>;
    createHero(issue:PainPointEntity): Promise<PainPointEntity>;
    deleteById(id: number): Promise<PainPointEntity>;
    updateById(id: number, entity:PainPointEntity): Promise<PainPointEntity>;
}
export class PainPointCollectionResponse{
    painPointsList: PainPointEntity[]
    constructor(data: PainPointCollectionResponse ){
        console.log("DATA IS:\n\n" + JSON.stringify(data));
        this.painPointsList = data.painPointsList.map(d => new PainPointEntity(d));
    }
}
export class PainPointHandler implements IPainPointHandler{
    //Get Element by ID and then respond with the Item.
    async getById(id: number): Promise<PainPointEntity>{
        return await APIHandler(`/api/painpoint/${id}`, {
            method: "GET",
            responseType:PainPointEntity
        });
    }
    async getAll(): Promise<PainPointCollectionResponse>{
        return await APIHandler(`/api/painpoint`, {
            method: "GET",
            responseType: PainPointCollectionResponse,
        });
    }
    //Create Element by ID and then respond with the Item.
    async createHero(issue:PainPointEntity): Promise<PainPointEntity>{
        return await APIHandler(`/api/painpoint`, {
            method: "POST",
            data: issue,
            responseType: PainPointEntity
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
