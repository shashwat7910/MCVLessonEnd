using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLessonEnd.Models
{
    public class ClassModel:BaseModel
    {
        public string Class { get; set; }
        public string section { get; set; }
        public int totstundents { get; set; }

    }
}
