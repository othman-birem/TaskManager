namespace TaskManager.Server.Models.Common
{
    public static class MetaData
    {
        public enum TaskStatus
        {
            Pending,
            OnWork,
            Success,
            Failed
        }
        public enum TaskType { }
        public enum NotificationType
        {
            Warning,
            Error,
            Regular
        }
    }
}
