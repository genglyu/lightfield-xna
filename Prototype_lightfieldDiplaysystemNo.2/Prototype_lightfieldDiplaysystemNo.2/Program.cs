using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

using Prototype_lightfieldDiplaysystemNo2.WindowforStart;
using Prototype_lightfieldDiplaysystemNo2.MainViewSystem;

namespace Prototype_lightfieldDiplaysystemNo2
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {

            //==建立初始化窗口的部分================================================
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowForStart_Prototype_LFDS windowsFormforStart = new WindowForStart_Prototype_LFDS();
            Application.Run(windowsFormforStart);
            //======================================================================


            using (Prototype_LightfieldDisplaySystemII Prototype_LFDS = new Prototype_LightfieldDisplaySystemII())
            {
                Prototype_LFDS.Run();
            }
        }
    }
#endif
}

