﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador_Web
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.EDU
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Navegador_Web());
        }
    }
}
