using System;
using System.Text.RegularExpressions;


namespace Test.GlobalClasses
{
    class MatchToRegex
    {
        public static bool EvaluationFlag__;

        public static bool ValidateByRegex(string TextToMatch, string RegexToMatchWith, string CalledFrom_)
        {
            System.Console.WriteLine("\nMatch to regex, called from " + CalledFrom_ + "\n");

            Match Match_ = Regex.Match(TextToMatch, RegexToMatchWith, RegexOptions.IgnoreCase);

            if (Match_.Success)
            {

                EvaluationFlag__ = false;

            }
            else
            {

                EvaluationFlag__ = true;

            };

            return EvaluationFlag__;
        }//ValidateByRegex
    }
}
