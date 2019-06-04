import { APIHandler } from './apiHandler';
import { IssueEntity } from '../entity/CreateFormEntity';
import { Issues } from '../entity/AdminViewEntity';
//import SuperheroItems  from '../types/superhero/SuperheroItems';
export interface IPainPointHandler{
    getAll(): Promise<Issues>;
    getById(id: number): Promise<IssueEntity>;
    createHero(issue: IssueEntity): Promise<IssueEntity>;
    deleteById(id: number): Promise<IssueEntity>;
    updateById(id: number, entity: IssueEntity): Promise<IssueEntity>;
}
// export class SuperheroCollectionResponse{
//     collection: SuperheroItem[]
//     constructor(data: any[]){
//         this.collection = data.map(d => new SuperheroItem(d));
//     }
// }
export class PainPointHandler implements IPainPointHandler{
    //Get Element by ID and then respond with the Item.
    async getById(id: number): Promise<IssueEntity>{
        return await APIHandler(`/api/painpoint/${id}`, {
            method: "GET",
            responseType: IssueEntity
        });
    }
    async getAll(): Promise<Issues>{
        return await APIHandler(`/api/painpoint`, {
            method: "GET",
            responseType: Issues
        });
    }
    //Create Element by ID and then respond with the Item.
    async createHero(issue: IssueEntity): Promise<IssueEntity>{
        return await APIHandler(`/api/painpoint`, {
            method: "POST",
            data: issue,
            responseType: IssueEntity
        });
    }
    //Delete Element by ID and then respond with the Item.
    async deleteById(id: number): Promise<IssueEntity>{
        return await APIHandler(`/api/painpoint/${id}`, {
            method: "DELETE",
            responseType: IssueEntity
        });
    }
    // //Update Element by ID and then respond with the Item.
    async updateById(id: number, entity: IssueEntity): Promise<IssueEntity>{
        return await APIHandler(`/api/painpoint/${id}`, {
            method: "PUT",
            data: entity,
            responseType: IssueEntity
        });
    }
}

