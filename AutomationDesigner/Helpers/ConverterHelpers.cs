using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesigner.Helpers
{
    public static class ConverterHelpers
    {
        public static double ConvertDouble(string value)
        {
            var unit = 0.00;

            if (double.TryParse(value, out unit))
            {
                return unit;
            }

            return 0.00;
        }

        public static int ConvertInt(string value)
        {
            var unit = 0;

            if (int.TryParse(value, out unit))
            {
                return unit;
            }

            return 0;
        }

        public static double Round(double value, double factor)
        {
            return Math.Round(value * factor) / factor;
        }

    }
}
