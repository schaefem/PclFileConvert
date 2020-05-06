using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PclFileConvert
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Einstellungen laden
            Methods.Instance.LoadSettings();
            //Prüfen ob Parameter übergeben wurde und Eigenschaften entsprechend festlegen                    
            Methods.Instance.AutoMode = args.Contains("auto");
            Methods.Instance.DebugMode = args.Contains("debug");

            //Fensterinstanze erzeugen
            using (dlgShell shellForm = new dlgShell())
            {
                try { Application.Run(shellForm); }
                catch (Exception error) { Methods.Instance.AddNewLog($"Allgemeiner Fehler {error.Message} - {error.StackTrace}", Methods.LogType.error); }
            }
        }
    }
}