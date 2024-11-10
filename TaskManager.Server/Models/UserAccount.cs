﻿
#nullable disable

namespace TaskManager.Server.Models
{
    [PrimaryKey(nameof(Id))]
    public class UserAccount
    {
        public string Id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string occupation { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}