export default class CreateFormEntity {
    Id: number;
    Type: string[];
    Title: string;
    Summary: string;
    painPointAnnotation: string;
    painPointSeverity: number;

    Status: string;

    companyName: string;
    companyContact: string;
    companyLocation: string;
    industryType: string;

    //userId?: number;
    //userName: string;

    constructor(JSONData: any) {
        this.Id = JSONData.Id;
        this.Type = JSONData.Type;
        this.Title = JSONData.Title;
        this.Summary = JSONData.Summary;
        this.painPointAnnotation = JSONData.painPointAnnotation;
        this.painPointSeverity = JSONData.painPointSeverity;

        this.Status = JSONData.Status;

        this.companyName = JSONData.companyName;
        this.companyContact = JSONData.companyContact;
        this.companyLocation = JSONData.companyLocation;
        this.industryType = JSONData.industryType;

        //this.userId = JSONData.userId;
        //this.userName = JSONData.userName;
    }
}

export class IssueEntity {
    Id: number;
    Type: string[];
    Title: string;
    Summary: string;
    painPointAnnotation: string;
    painPointSeverity: number;

    Status: string;

    companyName?: string;
    companyContact?: string;
    companyLocation?: string;
    industryType?: string;

    //userId?: number;
    //userName: string;

    constructor(JSONData: any) {
        this.Id = JSONData.Id;
        this.Type = JSONData.Type;
        this.Title = JSONData.Title;
        this.Summary = JSONData.Summary;
        this.painPointAnnotation = JSONData.painPointAnnotation;
        this.painPointSeverity = JSONData.painPointSeverity;

        this.Status = JSONData.Status;

        this.companyName = JSONData.companyName;
        this.companyContact = JSONData.companyContact;
        this.companyLocation = JSONData.companyLocation;
        this.industryType = JSONData.industryType;

        //this.userId = JSONData.userId;
        //this.userName = JSONData.userName;
    }
}