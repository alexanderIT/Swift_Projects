using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionControlSystem.Data
{
    public class FileVersion
    {
        public int Id { get; set; }
        public int Creator { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int FileId { get; set; }

        public virtual NewFile File { get; set; }
        public virtual User User { get; set; }
    }
}
