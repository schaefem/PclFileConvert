﻿using System;
using System.Collections.Generic;

namespace PclFileConvert
{
    [Serializable]
    public class Settings
    {
        #region Schnittstellen (Eigenschaften)
        /// <summary>
        /// Parameter für den Ghostscriptaufruf
        /// </summary>
        public string GhostPclParams { get; set; } = "-dNOPAUSE -sDEVICE=pdfwrite -sOutputFile=#OUTPUT# #INPUT#";

        /// <summary>
        /// Pfad zu Ghostscript PCL
        /// </summary>
        public string GhostPclPath { get; set; } = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "gpcl6win64.exe");

        /// <summary>
        /// Pfad zum Ordner, in dem PCL-Dateien gesucht werden sollen
        /// </summary>
        public string PclInputFolder { get; set; } = String.Empty;

        /// <summary>
        /// Endung von PCL-Dateien nach denen gesucht werden soll
        /// </summary>
        public string PclExtension { get; set; } = "*.pcl";

        /// <summary>
        /// Pfad zum Ordner, in dem die fertigen PDF-Dateien geschrieben werden sollen
        /// </summary>
        public string PdfOutputFolder { get; set; } = String.Empty;

        /// <summary>
        /// Intervall in dem der Timer für den PCL-Ordner ausgeführt werden soll
        /// </summary>
        public int LookupInterval { get; set; } = 50000;

        /// <summary>
        /// Tageszahl nach dem alte PDF-Dateien gelöscht werden (0=kein Löschen)
        /// </summary>
        public int DeleteOldPdfDayCounter { get; set; } = 0;

        /// <summary>
        /// Legt fest, ob PCL-Dateien nach der PDF Umwandlung gelöscht werden
        /// </summary>
        public bool RemovePclFiles { get; set; } = true;
        #endregion
    }
}
