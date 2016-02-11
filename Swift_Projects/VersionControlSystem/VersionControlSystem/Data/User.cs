using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionControlSystem.Data
{
    public partial class User
    {
        
        public User()
        {
            this.Files = new HashSet<NewFile>();
            this.Versions = new HashSet<FileVersion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<NewFile> Files { get; set; }        
        public virtual ICollection<FileVersion> Versions { get; set; }
    }
}
