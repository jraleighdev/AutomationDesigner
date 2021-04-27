using AutomationDesigner.Enums;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesigner.DTOS
{
    public class CommandItem
    {
        public CommandItem(string command, string name, string parent, string value, string value2 = "", string units = "", string notes = "", ApplicationTypeEnum applicationType = ApplicationTypeEnum.General)
        {
            Command = command;
            Name = name;
            Parent = parent;
            Value = value;
            Value2 = value2;
            Units = units;
            Notes = notes;
            ApplicationType = applicationType;
        }

        public string Command { get; set; }

        public string Name { get; set; }
        
        public string Parent { get; set; }

        public string Value { get; set; }

        public string Value2 { get; set; }

        public string Units { get; set; }

        public string Notes { get; set; }

        public ApplicationTypeEnum ApplicationType { get; set; }
    }
}
