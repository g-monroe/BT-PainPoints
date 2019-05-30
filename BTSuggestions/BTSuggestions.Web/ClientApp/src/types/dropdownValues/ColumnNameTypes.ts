import {SelectOption} from './SelectOption';

export class SelectOptionWithEntity implements SelectOption {
    id: number;
    entityName: string;
    name: string;
}

export const columnNameList: SelectOptionWithEntity[] =[
    {id: 1, entityName:"painPointType" ,name: "Pain Point Type"},
    {id: 2, entityName:"painPointSeverity" ,name: "Pain Point Severity"},
    {id: 3, entityName:"description" ,name: "Description"},
    {id: 4, entityName:"highestKeyword" ,name: "Highest Keyword"},
    {id: 5, entityName:"dateCreated" ,name: "Date Created"},
    {id: 6, entityName:"status" ,name: "Status"}
]