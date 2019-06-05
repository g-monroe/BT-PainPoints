import { APIHandler } from './apiHandler';
import ContentEntity from '../entity/UserEntity';
import UserEntity from '../entity/UserEntity';
//import SuperheroItems  from '../types/superhero/SuperheroItems';
export interface IContentHandler{
    getById(id: number): Promise<ContentEntity>;
    getByUserId(id: number): Promise<ContentEntity>;
    getUser(id: number): Promise<UserEntity>;
    createComment(comment: UserEntity): Promise<ContentEntity>;
    deleteById(id: number): Promise<ContentEntity>;
    updateById(id: number, entity: ContentEntity): Promise<ContentEntity>;
}
// export class SuperheroCollectionResponse{
//     collection: SuperheroItem[]
//     constructor(data: any[]){
//         this.collection = data.map(d => new SuperheroItem(d));
//     }
// }
export class ContentHandler implements IContentHandler{
    //Get Element by ID and then respond with the Item.
    async getById(id: number): Promise<ContentEntity>{
        return await APIHandler(`http://localhost:62848/api/content/${id}`, {
            method: "GET",
            responseType: ContentEntity
        });
    }
    async getByUserId(id: number): Promise<ContentEntity>{
        return await APIHandler(`http://localhost:62848/api/content/user/${id}`, {
            method: "GET",
            responseType: ContentEntity
        });
    }
    async getUser(id: number): Promise<UserEntity>{
        return await APIHandler(`http://localhost:62848/api/content/${id}/user`, {
            method: "GET",
            responseType: UserEntity
        });
    }
    //Create Element by ID and then respond with the Item.
    async createComment(comment: ContentEntity): Promise<ContentEntity>{
        return await APIHandler(`http://localhost:62848/api/comment`, {
            method: "POST",
            data: comment,
            responseType: ContentEntity
        });
    }
    //Delete Element by ID and then respond with the Item.
    async deleteById(id: number): Promise<ContentEntity>{
        return await APIHandler(`http://localhost:62848/api/content/${id}`, {
            method: "DELETE",
            responseType: ContentEntity
        });
    }
    // //Update Element by ID and then respond with the Item.
    async updateById(id: number, entity: ContentEntity): Promise<ContentEntity>{
        return await APIHandler(`http://localhost:62848/api/content/${id}`, {
            method: "PUT",
            data: entity,
            responseType: ContentEntity
        });
    }
}

