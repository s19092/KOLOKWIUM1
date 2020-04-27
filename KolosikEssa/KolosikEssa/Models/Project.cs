using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolosikEssa.Models
{
    public class Project
    {
        public string ProjectName { get; set; }
        public Nullable<int> IdProject { get; set; }
        public DateTime Deadline { get; set; }

        public List<Task> Tasks { get; set; }

    }
}
