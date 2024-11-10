using TaskManager.Server.Models;

namespace TaskManager.Server.EntitiesManagement
{
    public class TaskManagerContext: DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }


    }
}
