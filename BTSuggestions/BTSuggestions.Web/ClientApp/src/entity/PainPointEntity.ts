export default class PainPointEntity {
    "painPointType": number;
    "painPointSeverity": number;
    "description"?: string;
    "highestKeyword"?: string;
    "dateCreated": Date;
    "status": number ;

    constructor(JSONData: any){
        this.painPointType = JSONData.painPointType;
        this.painPointSeverity = JSONData.painPointSeverity;
        this.description = JSONData.description;
        this.highestKeyword = JSONData.highestKeyword;
        this.dateCreated = JSONData.dateCreated;
        this.status = JSONData.status;
    }
}

