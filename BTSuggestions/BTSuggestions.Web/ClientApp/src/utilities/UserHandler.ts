import { APIHandler } from './apiHandler';
import UserEntity from '../entity/UserEntity';
//import SuperheroItems  from '../types/superhero/SuperheroItems';
export interface IUserHandler{
    getById(id: number): Promise<UserEntity>;
    getByUsername(username: string): Promise<UserEntity>;
    createUser(user: UserEntity): Promise<UserEntity>;
    deleteById(id: number): Promise<UserEntity>;
    updateById(id: number, entity: UserEntity): Promise<UserEntity>;
}
// export class SuperheroCollectionResponse{
//     collection: SuperheroItem[]
//     constructor(data: any[]){
//         this.collection = data.map(d => new SuperheroItem(d));
//     }
// }
export class UserHandler implements IUserHandler{
    //Get Element by ID and then respond with the Item.
    async getById(id: number): Promise<UserEntity>{
        return await APIHandler(`/api/user/${id}`, {
            method: "GET",
            responseType: UserEntity
        });
    }
    async getByUsername(username: string): Promise<UserEntity>{
        return await APIHandler(`/api/user/${username}`, {
            method: "GET",
            responseType: UserEntity
        });
    }
    //Create Element by ID and then respond with the Item.
    async createUser(user: UserEntity): Promise<UserEntity>{
        return await APIHandler(`/api/user`, {
            method: "POST",
            data: user,
            responseType: UserEntity
        });
    }
    //Delete Element by ID and then respond with the Item.
    async deleteById(id: number): Promise<UserEntity>{
        return await APIHandler(`/api/user/${id}`, {
            method: "DELETE",
            responseType: UserEntity
        });
    }
    // //Update Element by ID and then respond with the Item.
    async updateById(id: number, entity: UserEntity): Promise<UserEntity>{
        return await APIHandler(`/api/user/${id}`, {
            method: "PUT",
            data: entity,
            responseType: UserEntity
        });
    }
}

