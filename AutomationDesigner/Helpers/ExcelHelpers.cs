using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace AutomationDesigner.Helpers
{
    public static class ExcelHelpers
    {
        public static bool WorkSheetExists(this Excel.Workbook workbook, string name)
        {
            var value = false;

            foreach (Excel.Worksheet s in workbook.Worksheets)
            {
                if (s.Name == name)
                {
                    value = true;

                    break;
                }
            }

            return value;
        }

        public static List<Excel.Worksheet> GetWorksheets(this Excel.Workbook workbook)
        {
            var tempList = new List<Excel.Worksheet>();

            foreach (Excel.Worksheet sheet in workbook.Worksheets)
            {
                tempList.Add(sheet);
            }

            return tempList;
        }

        public static bool ActivateSheet(this Excel.Workbook workbook, string name)
        {
            var workSheets = workbook.GetWorksheets();

            var workSheet = workSheets.FirstOrDefault(x => x.Name == name);

            if (workSheet == null)
            {
                return false;
            }

            workSheet.Activate();

            return true;
        }

        public static void AddDropDownList(this Excel.Range range, string rangeName)
        {
            range.Validation.Delete();
            range.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertInformation, XlFormatConditionOperator.xlBetween, $"={rangeName}", Type.Missing);
            range.Validation.IgnoreBlank = false;
            range.Validation.InCellDropdown = true;
        }

        public static bool RangeExists(this Excel.Worksheet workSheet, string name)
        {
            return workSheet.NamedRanges().Exists(x => x == name);
        }

        public static void DeleteNamedRange(this Excel.Worksheet worksheet, string name)
        {
            if (worksheet.RangeExists(name))
            {
                var namedRange = worksheet.Names().FirstOrDefault(n => n.Name == name);

                if (namedRange != null)
                {
                    namedRange.Delete();
                }
            }
        }

        public static List<Name> Names(this Excel.Worksheet workSheet)
        {
            var value = new List<Name>();

            foreach (Excel.Name n in workSheet.Application.ActiveWorkbook.Names)
            {
                value.Add(n);
            }

            return value;
        }

        public static List<string> NamedRanges(this Excel.Worksheet workSheet)
        {
            return workSheet.Names().Select(n => n.Name).ToList();
        }

        public static Excel.Range CreateNamedRange(this Excel.Worksheet worksheet, string name, string range)
        {
            Excel.Range namedRange = null;

            if (worksheet.RangeExists(name))
            {
                try
                {
                    namedRange = worksheet.Range[name];
                }
                catch (Exception ex)
                {
                    worksheet.DeleteNamedRange(name);
                }
            }
            else
            {
                namedRange = worksheet.Range[range];

                namedRange.Name = name;
            }

            return namedRange;
        }

        public static void ClearNamedRange(this Excel.Worksheet worksheet, string name)
        {
            if (worksheet.RangeExists(name))
            {
                try
                {
                    worksheet.Range[name].Clear();
                }
                catch(Exception ex)
                {
                    worksheet.DeleteNamedRange(name);
                }
            }
        }

        public static bool WorkSheetEmpty(this Excel.Worksheet worksheet)
        {
            return worksheet.Application.WorksheetFunction.CountA(worksheet.UsedRange) == 0 && worksheet.Shapes.Count == 0;
        }

        public static List<Excel.ListObject> GetListObjects(this Excel.Worksheet worksheet)
        {
            var listObjects = worksheet.ListObjects;

            var tempList = new List<Excel.ListObject>();

            if (listObjects == null)
            {
                return tempList;
            }

            foreach (ListObject l in listObjects)
            {
                tempList.Add(l);
            }

            return tempList;
        }

        public static List<Excel.ListColumn> GetListColumns(this Excel.ListObject listObject)
        {
            var tempList = new List<Excel.ListColumn>();

            foreach (ListColumn l in listObject.ListColumns)
            {
                tempList.Add(l);
            }

            return tempList;
        }

        public static List<string> GetFilePaths(this Excel.Range range)
        {
            var tempList = new List<string>();

            foreach (Range r in range)
            {
                if (r.Value != null)
                {
                    var text = r.Value.ToString();

                    if (!string.IsNullOrEmpty(text))
                    {
                        if (ExcelHelpers.IsValidPath(text))
                        {
                            tempList.Add(text);
                        }
                    }
                }
            }
            return tempList;
        }

        public static bool IsValidPath(string path)
        {
            Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
            if (!driveCheck.IsMatch(path.Substring(0, 3))) return false;
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
            strTheseAreInvalidFileNameChars += @":/?*" + "\"";
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");

            if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
            {
                return false;
            }
                

            return true;
        }

        public static string GetColumnName(int columnNumber)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string columnName = "";

            while (columnNumber > 0)
            {
                columnName = letters[(columnNumber - 1) % 26] + columnName;
                columnNumber = (columnNumber - 1) / 26;
            }

            return columnName;
        }

        public static void WriteCollection<T>(this IEnumerable<T> collection, Worksheet worksheet, string startRange)
        {
            var workingRange = worksheet.Range[startRange];

            var startColumn = workingRange.Column;
            var startRow = workingRange.Row;

            var properties = typeof(T).GetProperties().Select(x => x.Name);

            var column = startColumn;

            foreach (var p in properties)
            {
                var columnLetter = GetColumnName(column);

                worksheet.Range[$"{columnLetter}{startRow}"].Value = p;

                column++;
            }

            column = startColumn;
            var dataRowStart = startRow + 1;

            foreach (var c in collection)
            {
             //   var properities 
            }
        }
    } 
}
