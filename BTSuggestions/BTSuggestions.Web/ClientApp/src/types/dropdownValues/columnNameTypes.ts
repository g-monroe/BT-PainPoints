import {SelectOption} from './SelectOption';

export class SelectOptionWithEntityAndWidth implements SelectOption {
    id: number;
    entityName: string;
    name: string;
    width: number;
}

export const columnNameList: SelectOptionWithEntityAndWidth[] =[  
    {id: 0, width: 200, entityName:"title" ,name: "Title" },
    {id: 1, width: 600, entityName:"summary" ,name: "Summary"},
    {id: 2, width: 400, entityName:"annotation" ,name: "Annotation"},
    {id: 3, width: 400, entityName:"status" ,name:"Status" },
    {id: 4, width: 200, entityName:"user" ,name: "User"},
    {id: 5, width: 200, entityName:"priorityLevel" ,name:"Priority Level"  },
    {id: 6, width: 600, entityName:"companyName" ,name:"Company Name" },
    {id: 7, width: 400, entityName:"companyContact" ,name:"Company Contact" },
    {id: 8, width: 400, entityName:"companyLocation" ,name:"Company Location" },
    {id: 9, width: 200, entityName:"industryType" ,name:"Industry Type" },
    {id: 10, width: 200, entityName:"createdOn" ,name: "Created On" },
    {id: 11, width: 200, entityName:"types" ,name:"Types" },
    
    
]

