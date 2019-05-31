import {SelectOption} from './SelectOption';

export class SelectOptionWithEntityAndSpan implements SelectOption {
    id: number;
    entityName: string;
    name: string;
    span: number;
}

export const columnNameList: SelectOptionWithEntityAndSpan[] =[
    {id: 1, span: 2, entityName:"painPointType" ,name: "Pain Point Type"},
    {id: 2, span: 2, entityName:"painPointSeverity" ,name: "Pain Point Severity"},
    {id: 3, span: 6, entityName:"description" ,name: "Description"},
    {id: 4, span: 4, entityName:"highestKeyword" ,name: "Highest Keyword"},
    {id: 5, span: 4, entityName:"dateCreated" ,name: "Date Created"},
    {id: 6, span: 2, entityName:"status" ,name: "Status"}
]
