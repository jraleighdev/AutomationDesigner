using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesinger.Helpers
{
    public static class FractionConverter
    {
        public static string Convert(decimal pvalue,
        bool skip_rounding = false, decimal dplaces = (decimal)0.0625)
        {
            decimal value = pvalue;

            if (!skip_rounding)
                value = FractionConverter.DecimalRound(pvalue, dplaces);

            if (value == Math.Round(value, 0)) // whole number check
                return value.ToString();

            // get the whole value of the fraction
            decimal mWhole = Math.Truncate(value);

            // get the fractional value
            decimal mFraction = value - mWhole;

            // initialize a numerator and denomintar
            uint mNumerator = 0;
            uint mDenomenator = 1;

            // ensure that there is actual a fraction
            if (mFraction > 0m)
            {
                // convert the value to a string so that
                // you can count the number of decimal places there are
                string strFraction = mFraction.ToString().Remove(0, 2);

                // store the number of decimal places
                uint intFractLength = (uint)strFraction.Length;

                // set the numerator to have the proper amount of zeros
                mNumerator = (uint)Math.Pow(10, intFractLength);

                // parse the fraction value to an integer that equals
                // [fraction value] * 10^[number of decimal places]
                uint.TryParse(strFraction, out mDenomenator);

                // get the greatest common divisor for both numbers
                uint gcd = GreatestCommonDivisor(mDenomenator, mNumerator);

                // divide the numerator and the denominator by the greatest common divisor
                mNumerator = mNumerator / gcd;
                mDenomenator = mDenomenator / gcd;
            }

            // create a string builder
            StringBuilder mBuilder = new StringBuilder();

            // add the whole number if it's greater than 0
            if (mWhole > 0m)
            {
                mBuilder.Append(mWhole);
            }

            // add the fraction if it's greater than 0m
            if (mFraction > 0m)
            {
                if (mBuilder.Length > 0)
                {
                    mBuilder.Append(" ");
                }

                mBuilder.Append(mDenomenator);
                mBuilder.Append("/");
                mBuilder.Append(mNumerator);
            }

            return mBuilder.ToString();
        }

        // Converts fraction to decimal.
        // There are two formats a fraction greater than 1 can consist of
        // which this function will work for:
        //  Example: 4-1/2 or 4 1/2
        // Fractions less than 1 are in the format of 1/2, etc..
        public static decimal Convert(string value)
        {
            string[] dparse;
            string[] fparse;
            string whole = "0";
            string dec = "";
            decimal dReturn = 0;

            // check for '-' or ' ' separator between whole number and fraction
            dparse = value.Contains('-') ? value.Split('-') : value.Split(' ');
            int pcount = dparse.Count();

            // fraction greater than one.
            if (pcount == 2)
            {
                whole = dparse[0];
                dec = dparse[1];
            }
            // whole number or fraction less than 1.
            else if (pcount == 1)
                dec = dparse[0];

            // split out fractional part of value passed in.
            fparse = dec.Split('/');

            // check for fraction.
            if (fparse.Count() == 2)
            {
                try
                {
                    decimal d0 = System.Convert.ToDecimal(fparse[0]); // convert numerator
                    decimal d1 = System.Convert.ToDecimal(fparse[1]); // convert denominator
                    dReturn = d0 / d1; // divide the fraction (converts to decimal)
                    decimal dWhole = System.Convert.ToDecimal(whole); // convert
                                                                      // whole number part to decimal.

                    dReturn = dWhole + dReturn; // add whole number
                                                // and fractional part and we're done.
                }
                catch (Exception e)
                {
                    dReturn = 0;
                }
            }
            else
            // there is no fractional part of the input.
            {
                try
                {
                    dReturn = System.Convert.ToDecimal(whole + dec);
                }
                catch (Exception e)
                {
                    // bad input so return 0.
                    dReturn = 0;
                }
            }

            return dReturn;
        }

        private static uint GreatestCommonDivisor(uint valA, uint valB)
        {
            // return 0 if both values are 0 (no GSD)
            if (valA == 0 &&
              valB == 0)
            {
                return 0;
            }
            // return value b if only a == 0
            else if (valA == 0 &&
                  valB != 0)
            {
                return valB;
            }
            // return value a if only b == 0
            else if (valA != 0 && valB == 0)
            {
                return valA;
            }
            // actually find the GSD
            else
            {
                uint first = valA;
                uint second = valB;

                while (first != second)
                {
                    if (first > second)
                    {
                        first = first - second;
                    }
                    else
                    {
                        second = second - first;
                    }
                }

                return first;
            }

        }

        // Converts a value to feet and inches.
        // Examples:
        //  12.1667 converts to 12' 2"
        //  4 converts to 4'
        //  0.1667 converts to 2"
        public static bool ReformatForFeetAndInches
            (ref string line_type, bool zero_for_blank = true)
        {
            if (string.IsNullOrEmpty(line_type))
            {
                if (zero_for_blank)
                    line_type = "0'";
                return true;
            }

            decimal d = System.Convert.ToDecimal(line_type);
            decimal d1 = Math.Floor(d);
            decimal d2 = d - d1;
            d2 = Math.Round(d2 * 12, 2);

            string s1;
            string s2;

            s1 = d1 == 0 ? "" : d1.ToString() + "'";
            s2 = d2 == 0 ? "" : FractionConverter.Convert(d2) + @"""";

            line_type = string.Format(@"{0} {1}", s1, s2).Trim();

            if (string.IsNullOrEmpty(line_type))
            {
                if (zero_for_blank)
                    line_type = "0'";
                return true;
            }

            return true;
        }

        // Rounds a number to the nearest decimal.
        // For instance, carpenters do not want to see a number like 4/5.
        // That means nothing to them
        // and you'll have an angry carpenter on your hands
        // if you ask them cut a 2x4 to 36 and 4/5 inches.
        // So, we would want to convert to the nearest 1/16 of an inch.
        // Example: DecimalRound(0.8, 0.0625) Rounds 4/5 to 13/16 or 0.8125.
        private static decimal DecimalRound(decimal val, decimal places)
        {
            string sPlaces = FractionConverter.Convert(places, true);
            string[] s = sPlaces.Split('/');

            if (s.Count() == 2)
            {
                int nPlaces = System.Convert.ToInt32(s[1]);
                decimal d = Math.Round(val * nPlaces);
                return d / nPlaces;
            }

            return val;
        }
    }
}
