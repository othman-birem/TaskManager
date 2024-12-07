namespace TaskManager.Server.Models.Common
{
    public static class MetaData
    {
        public enum TaskStatus
        {
            Pending,
            InProgress,
            Success,
            Failed
        }
        public enum NotificationType
        {
            Warning,
            Error,
            Regular
        }
        public enum AccessPrivileges
        {
            Admin,
            Manager,
            Employee,
            Observer
        }
    }
}
