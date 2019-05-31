export default class TestingDbEntity {
    "$id": number;
    "painPointId": number;
    "title": string;
    "type": string[];
    "summary": string;
    "status": string;
    "priorityLevel": number;
    "user": string;
    "userId": number;
    "companyName": string;
    "companyContact": string;
    "companyLocation": string;
    "createdOn": Date;
    "industryType": string;

    constructor(JSONData: any){
        this.$id = JSONData.$id;
        this.painPointId = JSONData.painPointId;
        this.title = JSONData.title;
        this.type = JSONData.type;
        this.summary = JSONData.summary;
        this.status = JSONData.status;
        this.priorityLevel = JSONData.priorityLevel;
        this.user = JSONData.user;
        this.userId = JSONData.userId;
        this.companyName = JSONData.companyName;
        this.companyContact = JSONData.companyContact;
        this.companyLocation = JSONData.companyLocation;
        this.createdOn = JSONData.createdOn;
        this.industryType = JSONData.industryType;
    }
}

