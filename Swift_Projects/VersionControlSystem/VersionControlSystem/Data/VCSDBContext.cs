namespace VersionControlSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;

    public class VCSDBContext : DbContext
    {
        public VCSDBContext()
            : base()
        {
        }
        public virtual DbSet<NewFile> Files { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<FileVersion> Versions { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}