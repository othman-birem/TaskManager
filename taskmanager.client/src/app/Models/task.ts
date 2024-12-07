export interface task{
    Id: string;
    name: string;
    description: string;
    categoryId: string;
    status: TaskStatus;
    createDate: Date;
    dueDate: Date;
}
export enum TaskStatus
{
    Pending = "Pending",
    InProgress = "InProgress",
    Success = "Success",
    Failed = "Failed"
}