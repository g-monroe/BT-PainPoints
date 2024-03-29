export default class DetailViewEntity {
    painPointId: number;
    painPointType: string[];
    painPointTitle: string;
    painPointSummary: string;
    painPointAnnotation: string;
    painPointSeverity: number;

    submissionStatus: string;

    companyName: string;
    companyContact: string;
    companyLocation: string;
    industryType: string;

    comments: string[]

    //userId?: number;
    //userName: string;

    constructor(JSONData: any) {
        this.painPointId = JSONData.painPointId;
        this.painPointType = JSONData.painPointType;
        this.painPointTitle = JSONData.painPointTitle;
        this.painPointSummary = JSONData.painPointSummary;
        this.painPointAnnotation = JSONData.painPointAnnotation;
        this.painPointSeverity = JSONData.painPointSeverity;

        this.submissionStatus = JSONData.submissionStatus;

        this.companyName = JSONData.companyName;
        this.companyContact = JSONData.companyContact;
        this.companyLocation = JSONData.companyLocation;
        this.industryType = JSONData.industryType;
        this.comments = JSONData.string;

        //this.userId = JSONData.userId;
        //this.userName = JSONData.userName;
    }
}