export default class AdminViewEntity {
    issues: string[]

    constructor(JSONData: any) {
        this.issues = JSONData.issues;
    }
}