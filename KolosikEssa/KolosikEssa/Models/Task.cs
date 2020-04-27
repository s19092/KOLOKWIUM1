using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolosikEssa.Models
{
    public class Task
    {

        public int IdTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int IdProject { get; set; }
        public int IdTaskType { get; set; }
        public int IdAsig { get; set; }
        public int IdCreator { get; set; }


    }
}
