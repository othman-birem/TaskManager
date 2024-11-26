namespace TaskManager.Server.Models.Records
{
    public record LoginLoad
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
