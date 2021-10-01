using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseSystem
{
    class Program
    {
        // 程式進入點
        static void Main(string[] args)
        {
            Model model = new Model();
            Form selectCourseform = new SelectCourseForm(model);
            Application.Run(selectCourseform);
        }
    }
}
