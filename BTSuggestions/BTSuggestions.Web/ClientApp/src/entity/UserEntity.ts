export default class UserEntity {
    userId: number;
    email: string;
    username: string;
    firstName: string;
    lastName: string;
    password: string;
    privilege: string;

    constructor(JSONData: any) {
        this.userId = JSONData.userId;
        this.email = JSONData.email;
        this.username = JSONData.username;
        this.firstName = JSONData.firstName;
        this.lastName = JSONData.lastName;
        this.password = JSONData.passwrod;
        this.privilege = JSONData.privilege;
    }
}