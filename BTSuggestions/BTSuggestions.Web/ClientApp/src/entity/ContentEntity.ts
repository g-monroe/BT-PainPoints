import UserEntity from "./UserEntity";
export default class ContentEntity {
    contentId: number;
    content: string;
    user: UserEntity;

    constructor(JSONData: any) {
        this.contentId = JSONData.contentId;
        this.content = JSONData.content;
        this.user = JSONData.user;
    }
}