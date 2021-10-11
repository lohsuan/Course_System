using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem
{
    public static class Department
    {
        private static List<string> _departmentName = new List<string>();

        // add department name
        public static void AddDepartmentName(string departmentName)
        {
            _departmentName.Add(departmentName);
        }

        // get department name
        public static string GetDepartmentName(int index)
        {
            return _departmentName[index];
        }
    }
}
