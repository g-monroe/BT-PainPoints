import UserEntity from "./UserEntity";

export default class PainPointEntity {
        painpointId: number;
        Title: string;
        Summary: string;
        Annotation?: string;
        Status: string;
        User: UserEntity;
        UserId?: number;
        PriorityLevel: number;
        CompanyName?: string;
        CompanyContact?: string;
        CompanyLocation?: string;
        IndustryType?: string;
        CreatedOn: Date;
        Types: string[];

    constructor(JSONData: any){
        this.painpointId =  JSONData.painPointId;
        this.Title =  JSONData.title;
        this.Summary = JSONData.summary;
        this.Annotation = JSONData.annotation;
        this.Status =JSONData.status;
        this.User = JSONData.user;
        this.UserId = JSONData.userId;
        this.PriorityLevel = JSONData.priorityLevel;
        this.CompanyName = JSONData.companyName;
        this.CompanyContact  = JSONData.companyContact;
        this.CompanyLocation  = JSONData.comapnyLocation;
        this.IndustryType  = JSONData.industryType;
        this.CreatedOn  = JSONData.createdOn;
        this.Types  = JSONData.type;
        
    }
}

