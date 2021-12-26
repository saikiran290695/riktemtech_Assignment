using RiktamTech.Models;
using System.Data.Entity;

public class databaseContext : DbContext {
    public databaseContext() : base("name=dbconnection") { }
    public DbSet<USERS> users { get; set; }
    public DbSet<GROUPS> groups { get; set; }
    public DbSet<USERGROUPS> userGroups { get; set; }
    public DbSet<USER_MESSAGES> userMessages { get; set; }
    public DbSet<GROUP_MESSAGES> groupMessages { get; set; }

}