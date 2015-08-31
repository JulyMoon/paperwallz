using System;
using System.Threading;
using System.Windows.Forms;

namespace Paperwallz
{
    static class Program
    {
        static readonly Mutex mutex = new Mutex(false, "Never forget. Don't let your dreams be dreams. - foxneZz 8/31/2015");
        // http://stackoverflow.com/a/6486819/1412924

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!mutex.WaitOne(TimeSpan.FromSeconds(2), false))
            {
                MessageBox.Show("Another instance is already running.", "Paperwallz",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Application.Run(new MainWindow());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
