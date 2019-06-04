import {SelectOption} from './SelectOption';

export class SelectOptionWithEntityAndWidth implements SelectOption {
    id: number;
    entityName: string;
    name: string;
    width: number;
}

export const columnNameList: SelectOptionWithEntityAndWidth[] =[
    {id: 0, width: 200, entityName:"painPointType" ,name: "Pain Point Type"},
    {id: 1, width: 200, entityName:"painPointSeverity" ,name: "Pain Point Severity"},
    {id: 2, width: 600, entityName:"description" ,name: "Description"},
    {id: 3, width: 400, entityName:"highestKeyword" ,name: "Highest Keyword"},
    {id: 4, width: 400, entityName:"dateCreated" ,name: "Date Created"},
    {id: 5, width: 200, entityName:"status" ,name: "Status"}
]