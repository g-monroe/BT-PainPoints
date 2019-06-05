export default class CustomColumnEntity {
    configName: string;
    columnIds: number[];
    

    constructor(JSONData: any){
        this.configName = JSONData.configName;
        this.columnIds = [...JSONData.columnIds];
    }

}