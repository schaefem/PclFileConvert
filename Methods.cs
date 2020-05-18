using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PclFileConvert
{
    public class Methods
    {
        /// <summary>
        /// Enum des Logtyps
        /// </summary>
        internal enum LogType { info, warnung, error };

        /// <summary>
        /// Pfad, zur Logdatei
        /// </summary>
        private string _LogPath = null;        

        #region Schnittstellen
        /// <summary>
        /// Gibt an, ob das Programm mit Debug Parameter gestartet wurde
        /// </summary>
        internal bool DebugMode { get; set; } = false;

        /// <summary>
        /// Gibt an, ob das Programm mit Automode Parameter gestartet wurde
        /// </summary>
        internal bool AutoMode { get; set; } = false;

        /// <summary>
        /// Programmeinstellungen
        /// </summary>
        internal Settings ProgramSettings { get; set; } = new Settings();
        #endregion

        #region Singleton
        private static Methods _Instance;

        /// <summary>
        /// Singletonzugriff
        /// </summary>
        internal static Methods Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Methods();

                return _Instance;
            }
        }
        #endregion

        /// <summary>
        /// Fügt der Logdatei einen neuen Eintrag hinzu
        /// </summary>
        /// <param name="logMessage">Lognachricht</param>
        /// <param name="logType">Logtyp</param>
        internal void AddNewLog(string logMessage, LogType logType, TextBox logGuiOutput = null)
        {
            //Prüfen, ob in Datei geschrieben werden soll
            bool writeToFile = DebugMode;

            if (logType == LogType.error)
                writeToFile = true;            

            //Prüfen ob Logdatei vorhanden
            if (File.Exists(_LogPath) == false)
                _LogPath = Path.Combine(Application.StartupPath, $"{Guid.NewGuid()}.txt");

            //Nachrichtentext erzeugen
            string messageText = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()} - {logType}: {logMessage}{Environment.NewLine}";

            //Prüfen, ob Nachricht geschrieben werden soll
            if (writeToFile)
                File.AppendAllText(_LogPath, messageText);

            //Prüfen, ob Meldung ausgegeben werden soll
            if (logGuiOutput != null)
            {
                if (logGuiOutput.Lines.Length > 50)
                    logGuiOutput.Text = messageText;
                else
                    logGuiOutput.Text += messageText;
            }
        }       

        /// <summary>
        /// Löscht alte PDF-Dateien anhand der Einstellungen
        /// </summary>
        /// <param name="logGuiOutput">Optional: Logausgabe</param>
        internal void DeleteOldPdfFiles(TextBox logGuiOutput = null)
        {
            //Prüfen, ob gelöscht werden soll
            if (ProgramSettings.DeleteOldPdfDayCounter > 0)
            {
                //Einzelnen PDF-Dateien durchgehen und prüfen, ob Alter erreicht wurde
                foreach (string pdfFileName in Directory.GetFiles(ProgramSettings.PdfOutputFolder, "*.pdf"))
                {
                    FileInfo pdfFileInfo = new FileInfo(pdfFileName);

                    if (pdfFileInfo.CreationTime.AddDays(ProgramSettings.DeleteOldPdfDayCounter) < DateTime.Now)
                    {
                        File.Delete(pdfFileName);
                        AddNewLog($"Datei {pdfFileName} ist älter als {ProgramSettings.DeleteOldPdfDayCounter} Tag(e) und wurde gelöscht.", LogType.info, logGuiOutput);

                        //Prüfen, ob die dazugehörige PCL-Datei noch vorhanden
                        string pclFileName = Path.Combine(ProgramSettings.PclInputFolder, $"{pdfFileInfo.Name.Replace(pdfFileInfo.Extension, ProgramSettings.PclExtension.Replace("*", String.Empty))}");
                        //Versuchen die dazugehörige PCL-Datei zu löschen
                        try { File.Delete(pclFileName); }
                        catch (Exception error)
                        {                            
                            if (error is FileNotFoundException)
                                AddNewLog($"Die zugehörige PCL-Datei wurde bereits entfernt", LogType.info, logGuiOutput);
                            else
                                throw error;
                        }
                    }
                }                
            }
        }

        /// <summary>
        /// Liest PCL Dateien aus und wandelt diese, mit Hilfe von GhostPCL, in PDF um
        /// </summary>
        /// <param name="logGuiOutput">Optional: Logausgabe</param>
        internal void WritePdfFiles(TextBox logGuiOutput = null)
        {
            //Pfade prüfen
            if (File.Exists(ProgramSettings.GhostPclPath) == false)
                throw new FileNotFoundException($"GhostPcl konnte unter {ProgramSettings.GhostPclPath} nicht gefunden werden");

            if (Directory.Exists(ProgramSettings.PclInputFolder) == false)
                throw new DirectoryNotFoundException($"Ordner mit PCL-Dateien unter {ProgramSettings.PclInputFolder} nicht gefunden");

            if (Directory.Exists(ProgramSettings.PdfOutputFolder) == false)
                throw new DirectoryNotFoundException($"Ordner mit PCL-Dateien unter {ProgramSettings.PdfOutputFolder} nicht gefunden");

            //GhostPcl Parameter auf erforderliche Parameter prüfen
            if (ProgramSettings.GhostPclParams.Contains("#OUTPUT#") == false)
                throw new Exception("Parameter #OUTPUT# in den GhostPcl Parametern fehlt");

            if (ProgramSettings.GhostPclParams.Contains("#INPUT#") == false)
                throw new Exception("Parameter #INPUT# in den GhostPcl Parametern fehlt");

            //PCL-Dateien beziehen und durchgehen
            foreach (string pclFileName in Directory.GetFiles(ProgramSettings.PclInputFolder, ProgramSettings.PclExtension))
            {
                //Dateiinfos und arbeitsname für Dateien erzeugen um Zeichen im Dateinamen zu vermeiden, mit denen GhostPCL nicht umgehen kann
                FileInfo fileInfo = new FileInfo(pclFileName);

                //Prüfen, ob zur PCL-Datei bereits eine PDF Datei erzeugt wurde
                if (File.Exists(Path.Combine(ProgramSettings.PdfOutputFolder, $"{fileInfo.Name.Replace(fileInfo.Extension, ".pdf")}")) == false)
                {
                    Guid workingId = Guid.NewGuid();
                    string workingFileName = Path.Combine(fileInfo.DirectoryName, $"{workingId}{fileInfo.Extension}");
                    string workingPdfName = Path.Combine(ProgramSettings.PdfOutputFolder, $"{workingId}.pdf");

                    //Dateinamen anpassen
                    File.Copy(pclFileName, workingFileName);

                    //Prüfen ob die originale PCL-Datei gelöscht werden soll
                    if (ProgramSettings.RemovePclFiles)
                        File.Delete(pclFileName);

                    //GhostPcl Parameter ersetzen
                    string ghostParams = ProgramSettings.GhostPclParams;

                    ghostParams = ghostParams.Replace("#OUTPUT#", workingPdfName);
                    ghostParams = ghostParams.Replace("#INPUT#", workingFileName);

                    Process pdfProcess = new Process();

                    //Writer/Reader für Kommandos
                    StreamWriter writer = null;
                    StreamReader reader = null;
                    //Prozess erzeugen, um GhostPCL per Commandshell aufzurufen
                    ProcessStartInfo processInfo = new ProcessStartInfo("cmd");
                    processInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    //Umleiten der Ein-/Ausgaben sowie Commandshell verstecken
                    processInfo.CreateNoWindow = true;
                    processInfo.UseShellExecute = false;
                    processInfo.RedirectStandardInput = true;
                    processInfo.RedirectStandardOutput = true;

                    //Warten, bis das PDF erzeugt wurde
                    try
                    {
                        pdfProcess.StartInfo = processInfo;
                        pdfProcess.Start();

                        writer = pdfProcess.StandardInput;
                        reader = pdfProcess.StandardOutput;
                        writer.AutoFlush = true;
                        //GhostPCL Kommando absetzen
                        writer.WriteLine($"{ProgramSettings.GhostPclPath} {ghostParams}");
                        writer.Close();

                        string ausgabe = reader.ReadToEnd();
                        pdfProcess.WaitForExit();

                        //Protkoll schreiben
                        AddNewLog($"GhostPCL Rückgabe: {ausgabe}", LogType.info, logGuiOutput);
                        AddNewLog($"Datei {pclFileName} in PDF konvertiert", LogType.info, logGuiOutput);

                        //PDF Datei umbennen und PCL Datei löschen
                        string newPdfFileName = Path.Combine(ProgramSettings.PdfOutputFolder, fileInfo.Name.Replace(fileInfo.Extension, ".pdf"));
                        File.Copy(workingPdfName, newPdfFileName, true);
                        File.Delete(workingPdfName);
                        File.Delete(workingFileName);
                        
                    }
                    catch (Exception error) { AddNewLog($"Datei {pclFileName} konnte nicht gewandelt werden: {error.Message} - {error.StackTrace}", LogType.error, logGuiOutput); }
                    finally
                    { //Aufräumen
                        pdfProcess.Dispose(); writer?.Dispose(); reader?.Dispose();
                    }
                }
            }
        }        

        /// <summary>
        /// Lädt die serialisierten Einstellungen
        /// </summary>
        /// <param name="path">optional: Pfad, zu den serialisierten Einstellungen (Standard Programmordern + einstellungen.settings)</param>
        internal void LoadSettings(string path = null)
        {
            if (String.IsNullOrEmpty(path))
                path = Path.Combine(Application.StartupPath, "einstellungen.settings");

            //Prüfen, ob Datei vorhanden, ansosnten neue Einstellungen erzeugen
            if (File.Exists(path))            
                ProgramSettings = DeserialiseObject<Settings>(path);            
            else
                ProgramSettings = new Settings();
        }

        #region Serialization
        /// <summary>
        /// Serialisiert das angegebene Objekt im angegebenen Pfad
        /// </summary>
        /// <typeparam name="T">Typ der serialisiert werden soll</typeparam>
        /// <param name="path">Pfad in dem das serialisierte Objekt abgelegt werden soll</param>
        /// <param name="objectClass">Objekt, das serialisiert werden soll</param>
        private void SerializeObject<T>(string path, T objectClass)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (TextWriter writer = new StreamWriter(path))
                serializer.Serialize(writer, objectClass);
        }

        /// <summary>
        /// Deserialisiert das angegebene Objekt
        /// </summary>
        /// <typeparam name="T">Typ der deserialisiert werden soll</typeparam>
        /// <param name="path">Pfad zum serialisierten Objekt</param>
        /// <returns>Gibt ein deserialisiertes Objekt vom gegebenen Typ zurück</returns>
        private T DeserialiseObject<T>(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StreamReader(path))
                return (T)deserializer.Deserialize(reader);
        }
        #endregion

        /// <summary>
        /// Schreibt die serialisierten Einstellungen
        /// </summary>
        /// <param name="path">optional: Pfad, zu den serialisierten Einstellungen (Standard Programmordern + einstellungen.settings)</param>
        internal void SaveSettings(string path = null)
        {
            if (String.IsNullOrEmpty(path))
                path = Path.Combine(Application.StartupPath, "einstellungen.settings");

            SerializeObject(path, ProgramSettings);
        }
    }
}
