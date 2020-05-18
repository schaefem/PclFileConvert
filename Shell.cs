using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PclFileConvert
{
    public partial class dlgShell : Form
    {
        //Timer, zur Überwachung des Ordners
        private Timer _FileAllocationTimer = new Timer();

        public dlgShell()
        {
            InitializeComponent();

            //Timer zur Ordnerüberwachung initilisieren
            if (!DesignMode)
            {                
                _FileAllocationTimer = new Timer() { Interval = Methods.Instance.ProgramSettings.LookupInterval };
                _FileAllocationTimer.Tick += _FileAllocationTimer_Tick;
                //Timer starten, wenn Programm mit Automodeargument gestartet wurde
                _FileAllocationTimer.Enabled = Methods.Instance.AutoMode;
            }
         }

        /// <summary>        /// <summary>

        /// Fenster wird angezeigt
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            binSettings.DataSource = Methods.Instance.ProgramSettings;
        }

        /// <summary>
        /// Fenster wird geschlossen
        /// </summary>        
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            //Einstellungen speichern
            Methods.Instance.SaveSettings();
        }

        /// <summary>
        /// Timer zur Ordnerüberwachung erreicht
        /// </summary>´
        private void _FileAllocationTimer_Tick(object sender, EventArgs e)
        {
            _FileAllocationTimer.Enabled = false;

            try
            {
                Methods.Instance.AddNewLog("Beginne Suche nach PCL-Dateien", Methods.LogType.info, logGuiOutput: Methods.Instance.AutoMode ? null : mleLog);
                Methods.Instance.WritePdfFiles(Methods.Instance.AutoMode ? null : mleLog);
                Methods.Instance.DeleteOldPdfFiles(Methods.Instance.AutoMode ? null : mleLog);
            }
            catch (Exception error) { Methods.Instance.AddNewLog($"Fehler in der Verarbeitung des Ordners {error.Message} - {error.StackTrace}", Methods.LogType.error, logGuiOutput: Methods.Instance.AutoMode ? null : mleLog); }
            finally
            {
                Methods.Instance.AddNewLog($"Suche nach PCL-Dateien abgeschlossen, nächster Start in {Methods.Instance.ProgramSettings.LookupInterval / 1000} Sekunden", Methods.LogType.info, logGuiOutput: Methods.Instance.AutoMode ? null : mleLog);
                _FileAllocationTimer.Enabled = true;
            }
        }

        /// <summary>
        /// Sucht einen Ordner
        /// </summary>        
        private void LookForDir(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlgBrowseDir = new FolderBrowserDialog())
            {
                if (dlgBrowseDir.ShowDialog(this) == DialogResult.OK)
                {
                    if (sender == btnPclDir)
                        Methods.Instance.ProgramSettings.PclInputFolder = dlgBrowseDir.SelectedPath;
                    else if (sender == btnTargetDir)
                        Methods.Instance.ProgramSettings.PdfOutputFolder = dlgBrowseDir.SelectedPath;
                    else
                        throw new NotImplementedException($"Für {sender} ist kein Prozess festgelegt");

                    binSettings.DataSource = Methods.Instance.ProgramSettings;
                }
            }
        }

        /// <summary>
        /// GhostPCL soll gesucht werden
        /// </summary>        
        private void btnGhostExecutable_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgOpenFile = new OpenFileDialog())
            {
                dlgOpenFile.Filter = "Ausführbare Datei|*.exe";

                if (dlgOpenFile.ShowDialog(this) == DialogResult.OK)
                    Methods.Instance.ProgramSettings.GhostPclPath = dlgOpenFile.FileName;

                binSettings.DataSource = Methods.Instance.ProgramSettings;
            }
        }

        /// <summary>
        /// Einstellungen sollen gespeichert werden
        /// </summary>        
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                //Methods.Instance.ProgramSettings = (Settings)binSettings.DataSource;
                Methods.Instance.SaveSettings();
                Methods.Instance.AddNewLog("Einstellungen gespeichert", Methods.LogType.info, logGuiOutput: mleLog);
            }
            catch (Exception error) { Methods.Instance.AddNewLog($"Fehler beim Speichern der Einstellungen: {error.Message} - {error.StackTrace}", Methods.LogType.error, logGuiOutput: mleLog); }
        }

        /// <summary>
        /// Timer starten/anhalten
        /// </summary>        
        private void ckbStart_CheckedChanged(object sender, EventArgs e)
        {
            //Angabe, ob Controls enabled
            bool controlsEnabled = ckbStart.Checked ? false : true;

            _FileAllocationTimer.Enabled = ckbStart.Checked;

            //Controls anpassen
            sleGhostExecutable.Enabled = controlsEnabled;
            sleGhostParams.Enabled = controlsEnabled;
            sleIntervall.Enabled = controlsEnabled;
            slePclDir.Enabled = controlsEnabled;
            slePclExtension.Enabled = controlsEnabled;
            sleTargetDir.Enabled = controlsEnabled;
            sleDeleteOldPdf.Enabled = controlsEnabled;
            ckbRemovePclFiles.Enabled = controlsEnabled;

            btnSaveSettings.Enabled = controlsEnabled;
        }
    }
}
