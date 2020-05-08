using Squirrel;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MainWindows
{
    static class Program
    {
        static bool ShowTheWelcomeWizard;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (var mgr = new UpdateManager("https://github.com/Ficss/ReportesPeajesCentralizado"))
            //{
            //    // Note, in most of these scenarios, the app exits after this method
            //    // completes!
            //    SquirrelAwareApp.HandleEvents(
            //      onInitialInstall: v => mgr.CreateShortcutForThisExe(),
            //      onAppUpdate: v => mgr.CreateShortcutForThisExe(),
            //      onAppUninstall: v => mgr.RemoveShortcutForThisExe(),
            //      onFirstRun: () => ShowTheWelcomeWizard = true);
            //}

            string guid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
            using (Mutex mutex = new Mutex(false, "Global\\" + guid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Padre());
            }

            

        }
    }
}
