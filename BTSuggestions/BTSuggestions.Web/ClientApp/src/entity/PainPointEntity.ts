import UserEntity from "./UserEntity";

export default class PainPointEntity {
        painPointId: number;
        title: string;
        summary: string;
        annotation?: string;
        status: string;
        user: UserEntity;
        userId?: number;
        priorityLevel: number;
        companyName?: string;
        companyContact?: string;
        companyLocation?: string;
        industryType?: string;
        createdOn: Date;
        types: string[];

    constructor(JSONData: any){
        this.painPointId =  JSONData.painPointId;
        this.title =  JSONData.title;
        this.summary = JSONData.summary;
        this.annotation = JSONData.annotation;
        this.status =JSONData.status;
        this.user = JSONData.user;
        this.userId = JSONData.userId;
        this.priorityLevel = JSONData.priorityLevel;
        this.companyName = JSONData.companyName;
        this.companyContact  = JSONData.companyContact;
        this.companyLocation  = JSONData.companyLocation;
        this.industryType  = JSONData.industryType;
        this.createdOn  = JSONData.createdOn;
        if(!JSONData.types){
            this.types = [];
        }
        else {
            this.types = JSONData.types;
        }
    }
}

