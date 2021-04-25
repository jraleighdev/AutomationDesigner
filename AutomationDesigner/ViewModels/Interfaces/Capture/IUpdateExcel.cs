using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesigner.ViewModels.Interfaces.Capture
{
    public interface IUpdateExcel
    {
        string SelectedCellName { get; set; }

        void UpdateSelectedCell(Range range);

        void UpdateSelectedSheet(object sender);
    }
}
