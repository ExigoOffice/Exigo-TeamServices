export class Project{
    CompanyId: number;
    Id: number;
    ReferenceProjectId: number; 
    ProjectStatusTy: ProjectStatusTy; 
    ProjectTy: number;
    ProjectPriorityTy: number;
    CustomerId: number;
    AccountManagerId: number;
    Subject: string;
    EntryDate: Date;
    ProjectedDate: Date;
    ProjectedHours: number;
    ContactEmail: string;
    ContactName: string;
    ContactPhone: string;
    ActivityDate: Date;
    WorkPriority: number;
    WorkHoursTotal: number;
    WarningMessage: string;
    IsWarningActive: boolean;
    IsHot: boolean;
    Risk: number
}

export class ProjectDetail{
    CompanyId: number;
    ProjectId: number;
    Id: number;
    EntryDate: Date;
    IsPublic: boolean;
    Detail: string;
    EntryUserId: number;
    CompanyName:string;
    User: User;
    TimeEntries: TimeEntry; 

}

export class User{

}
export class TimeEntry{
    CompanyId: number;
    ProjectDetailId: number;
    Id: number;
    EntryComment: string;
    IsBillable: boolean;
    WorkTime: Date;
    User: User;

}
//TODO: Get the rest of the status types
export enum ProjectStatusTy{
    NewSubmittion = 1
}



