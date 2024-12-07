export interface notification{
    Id: string;
    userId: string;
    deliveredAt: Date;
    content: string;
    type: NotificationType;
    isRead: boolean;
}
export enum NotificationType
{
    Warning = "Warning",
    Error = "Error",
    Regular = "Regular"
}