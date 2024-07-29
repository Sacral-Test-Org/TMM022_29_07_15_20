using System;
using System.Collections.Generic;

namespace TMM022_fmb.DTOs
{
    public class FormInitializationDTO
    {
        public bool MainWindowMaximized { get; set; }
        public string Title { get; set; }
        public DateTime CurrentDate { get; set; }
        public int GlobalParameter { get; set; }
        public string Mode { get; set; }
        public string CursorStyle { get; set; }
        public bool SaveButtonEnabled { get; set; }
        public Dictionary<string, bool> FieldsEnabled { get; set; }
        public string FocusField { get; set; }
    }
}