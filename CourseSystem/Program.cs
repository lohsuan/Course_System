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
            StartUpForm startUpForm = new StartUpForm();
            Application.Run(startUpForm);
        }
    }
}
