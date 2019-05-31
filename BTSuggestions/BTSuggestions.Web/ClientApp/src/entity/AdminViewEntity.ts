export default class AdminViewEntity {
    issues: any[]

    constructor(JSONData: any) {
        this.issues = JSONData.issues;
    }
}