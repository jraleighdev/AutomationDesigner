using InventorWrapper.Documents;
using SolidworksWrapper.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesigner.CopyTools
{
    public class CopyDocumentItem
    {
        public string OldDocName { get; set; }

        public string OldPath { get; set; }

        public string NewDocName { get; set; }

        public string NewPath { get; set; }

        public CopyDocumentItem(InventorDocument document)
        {
            OldDocName = document.Name;
            OldPath = document.FileName;
            NewDocName = OldDocName;
            NewPath = OldPath;
        }

        public CopyDocumentItem(string fileName)
        {
            OldDocName = fileName;
            OldPath = fileName;
            NewDocName = OldDocName;
            NewPath = OldPath;
        }
    }
}
