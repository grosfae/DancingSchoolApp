using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingSchoolApp.Components.Model
{
    public partial class Student
    {
            public string FullName
            {
                get
                {
                    return $"{Name} {Surname}";
                }
            }
    }
    
}
