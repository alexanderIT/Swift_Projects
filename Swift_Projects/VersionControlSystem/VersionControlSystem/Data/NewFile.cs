using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionControlSystem.Data
{
    public partial class NewFile
    {       
        public NewFile()
        {
            this.Versions = new HashSet<FileVersion>();
        }

        public int Id { get; set; }
        public string File1 { get; set; }
        public Nullable<int> Locked { get; set; }
        public string Comment { get; set; }
        public string SaveDirectory { get; set; }

        public virtual User User { get; set; }        
        public virtual ICollection<FileVersion> Versions { get; set; }
    }
}
