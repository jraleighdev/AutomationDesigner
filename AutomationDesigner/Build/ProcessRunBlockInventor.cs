using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using InventorWrapper.Documents;
using AutomationDesinger.Constants;
using InventorWrapper;
using AutomationDesinger.Build.ApplicationFunctions;
using System.Windows.Forms;
using System.Collections.Specialized;
using AutomationDesinger.Enums;
using AutomationDesinger.Helpers;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using InventorWrapper.Representation;

namespace AutomationDesinger.Build
{
    public class ProcessRunBlockInventor : ExcelBaseParse
    {
        private InventorDocument _topDocument;

        private InventorDocument _workingDocument;

        private InventorMethods _methods;

        private bool inRepeat = false;
        private int repeatStart = 0;
        private int repeatEnd = 0;
        private int repeatCount = 0;
        private int repeatIndex = 0;

        public ProcessRunBlockInventor(Excel.Worksheet worksheet, InventorDocument topDocument = null) : base(worksheet)
        {
            if (!InventorApplication.Attached)
            {
                InventorApplication.Attach();
            }

            _methods = new InventorMethods();
            _topDocument = topDocument;
        }

        public List<string> Run(string rangeName = "", string rangeParameter = "")
        {
            Excel.Range startCell = null;

            if (string.IsNullOrEmpty(rangeName))
            {
                startCell = _worksheet.Range[_worksheet.Name + "Type"];
            }
            else
            {
                startCell = _worksheet.Range[rangeName];
            }

            if (startCell == null) throw new Exception("Could not find start range");


            var typeCol = startCell.Column;
            var nameCol = typeCol + 1;
            var parentCol = nameCol + 1;
            var value = parentCol + 1;
            var value2 = value + 1;
            var i = startCell.Row + 1;

            while (!string.IsNullOrEmpty(GetString(i, typeCol)))
            {
                var command = GetString(i, typeCol).ToUpper();

                if (command == Commands.Comment)
                {
                    i++;
                    continue;
                }
                else if (command == Commands.OpenDocument)
                {
                    _methods.OpenDocument(GetString(i, nameCol), GetString(i, parentCol), GetString(i, value), GetString(i, value2));
                    i++;
                    continue;
                }

                var workingDocumentName = GetString(i, parentCol);

                if (string.IsNullOrEmpty(workingDocumentName))
                {
                    if (_topDocument == null)
                    {
                        _topDocument = InventorApplication.ActiveDocument;
                    }

                    _workingDocument = _topDocument;
                }
                else
                {
                    if (_workingDocument == null)
                    {
                        _workingDocument = DocumentHelper.GetDocument(workingDocumentName);

                        if (_workingDocument == null)
                        {
                            throw new Exception($"Could not find document {workingDocumentName}");
                        }
                    }
                    else
                    {
                        if (_workingDocument.Name != workingDocumentName)
                        {
                            _workingDocument = DocumentHelper.GetDocument(workingDocumentName);
                        }

                        if (_workingDocument == null)
                        {
                            throw new Exception($"Could not find document {workingDocumentName}");
                        }
                    }
                }

                switch (command)
                {
                    case Commands.TopLevelName:
                        var topLevelName = GetString(i, nameCol);

                        if (InventorApplication.ActiveDocument.Name != topLevelName)
                        {
                            throw new Exception("Top level name does not match active model");
                        }
                        else
                        {
                            _topDocument = InventorApplication.ActiveDocument;
                        }
                        break;
                    case Commands.Parameter:
                        _methods.SetParameter(_workingDocument, GetString(i, nameCol), GetString(i, value));
                        break;
                    case Commands.SetProperty:
                        _methods.SetProperty(_workingDocument, GetString(i, nameCol), GetString(i, value));
                        break;
                    case Commands.GetProperty:
                        var propertyValue = _methods.GetProperty(_workingDocument, GetString(i, nameCol));
                        SetValue(i, value, propertyValue);
                        break;
                    case Commands.ComponentActivity:
                        _methods.Suppression(_workingDocument, GetString(i, nameCol), GetString(i, value), SuppresionType.Component);
                        break;
                    case Commands.ConstraintActivity:
                        _methods.Suppression(_workingDocument, GetString(i, nameCol), GetString(i, value), SuppresionType.Constraint);
                        break;
                    case Commands.PatternActivity:
                        _methods.Suppression(_workingDocument, GetString(i, nameCol), GetString(i, value), SuppresionType.Pattern);
                        break;
                    case Commands.FeatureActivity:
                        _methods.Suppression(_workingDocument, GetString(i, nameCol), GetString(i, value), SuppresionType.Feature);
                        break;
                    case Commands.DeleteComponent:
                        _methods.Delete(_workingDocument, GetString(i, nameCol));
                        break;
                    case Commands.DeleteReferencedDocuments:
                        _methods.DeleteReferenced(_workingDocument, GetString(i, nameCol));
                        break;
                    case Commands.Stop:
                        throw new Exception("Program Stopped");
                    case Commands.UpdateDocument:
                        _workingDocument.Update();
                        break;
                    case Commands.Sub:
                        ProcessRunBlockInventor runBlock = null;
                        var subName = GetString(i, nameCol);
                        var workSheetName = "";
                        
                        if (subName.Contains("!"))
                        {
                            var subSplit = subName.Split('!');

                            workSheetName = subSplit[0];
                            subName = subSplit[1];

                            runBlock = new ProcessRunBlockInventor(Globals.ThisAddIn.Application.ActiveWorkbook.GetWorksheets().FirstOrDefault(x => x.Name == workSheetName), _topDocument);
                        }
                        else
                        {
                            runBlock = new ProcessRunBlockInventor(_worksheet, _topDocument);
                        }

                        runBlock.Run(subName, GetString(i, value));
                        break;
                    case Commands.If:
                        ValidateIf(i, typeCol);

                        var booleanValue = GetBoolean(i, value);

                        if (!booleanValue)
                        {
                            i = GetEndIfRow(i, typeCol);
                        }
                        break;
                    case Commands.Repeat:
                        ValidateRepeat(i, typeCol);
                        repeatStart = i;
                        repeatEnd = GetEndRepeatRow(i, typeCol);
                        repeatCount = GetInt(i, value);
                        repeatIndex = 1;
                        SetValue(i, value2, repeatIndex.ToString());
                        inRepeat = true;
                        break;
                }

                i++;

                if (inRepeat)
                {
                    if (i == repeatEnd)
                    {
                        if (repeatIndex == repeatCount)
                        {
                            i = repeatEnd + 1;
                            repeatStart = 0;
                            repeatEnd = 0;
                            repeatCount = 0;
                            repeatIndex = 0;
                            inRepeat = false;
                        }
                        else
                        {
                            i = repeatStart + 1;
                            repeatIndex++;
                            SetValue(repeatStart, value2, repeatIndex.ToString());
                        }
                    }
                }
            }

            if (_topDocument != null)
            {
                if (InventorApplication.ActiveDocument.Name != _topDocument.Name)
                {
                    InventorApplication.ActiveDocument.Save();

                    InventorApplication.ActiveDocument.Close();
                }
            }

            InventorApplication.ActiveDocument.Update();

            InventorApplication.ActiveDocument.Save();

            return _methods.Logs;
        }
    }
}
