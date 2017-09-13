using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DDev.Tools
{
    public static class ConventionRegex
    {
        #region Convention Regex Checks

        #region Kebab & Snake

        /// <summary>
        /// Checks if a string is in kebab-case.
        /// Allows to set length constraints and include/exclude numbers.
        /// </summary>
        /// <param name="check"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="allowNumbers"></param>
        /// <returns></returns>
        public static bool IsKebabCase(
            this string check, 
            int minLength = 2, 
            int maxLength = 20, 
            bool allowNumbers = true,
            RegexLetterCase allowedLetters = RegexLetterCase.LowerOnly)
        {
            return CheckSymbolSeparatedCase(check, minLength, maxLength, allowNumbers, allowedLetters, '-');
        }

        /// <summary>
        /// Checks if a string is in snake_case.
        /// Allows to set length constraints and include/exclude numbers.
        /// </summary>
        /// <param name="check"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="allowNumbers"></param>
        /// <returns></returns>
        public static bool IsSnakeCase(
            this string check,
            int minLength = 2,
            int maxLength = 20,
            bool allowNumbers = true,
            RegexLetterCase allowedLetters = RegexLetterCase.LowerOnly)
        {
            return CheckSymbolSeparatedCase(check, minLength, maxLength, allowNumbers, allowedLetters, '_');
        }

        public static bool IsMixedKebabSnakeCase(this string check,
            int minLength = 2,
            int maxLength = 20,
            bool allowNumbers = true,
            RegexLetterCase allowedLetters = RegexLetterCase.LowerOnly)
        {
            return CheckSymbolSeparatedCase(check, minLength, maxLength, allowNumbers, allowedLetters, '_', '-');
        }

        /// <summary>
        /// Checks if a string is in dot.notation.
        /// Allows to set length constraints and include/exclude numbers.
        /// </summary>
        /// <param name="check"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="allowNumbers"></param>
        /// <returns></returns>
        public static bool IsDotNotation(
            this string check,
            int minLength = 2,
            int maxLength = 20,
            bool allowNumbers = true,
            RegexLetterCase allowedLetters = RegexLetterCase.LowerOnly)
        {
            return CheckSymbolSeparatedCase(check, minLength, maxLength, allowNumbers, allowedLetters, '.');
        }

        /// <summary>
        /// Internal check for kebab and snake case.
        /// </summary>
        /// <param name="check"></param>
        /// <param name="kebab"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="allowNumbers"></param>
        /// <returns></returns>
        private static bool CheckSymbolSeparatedCase(
            string check, 
            int minLength, 
            int maxLength, 
            bool allowNumbers,
            RegexLetterCase allowedLetters,
            params char[] symbols)
        {
            ValidateLengthInputs(minLength, maxLength);

            int len = check.Length;

            if (len < minLength || len > maxLength)
                return false;
            
            string numPattern = allowNumbers ? "0-9" : String.Empty;
            string letterPattern = String.Empty;

            // determine which letters are allowed
            switch (allowedLetters)
            {
                case RegexLetterCase.LowerOnly:
                    letterPattern = "a-z";
                    break;

                case RegexLetterCase.CapitalOnly:
                    letterPattern = "A-Z";
                    break;

                case RegexLetterCase.Both:
                    letterPattern = "A-Za-z";
                    break;
            }

            string pattern = String.Format("^[{2}{0}]+([{1}]{{1}}[{2}{0}]+)*$", numPattern, String.Join(String.Empty, symbols), letterPattern);

            return check.IsRegexMatch(pattern);
        }

        #endregion

        #region Camel

        /// <summary>
        /// Checks if a string is in UpperCamelCase.
        /// Allows to set length constraints and include/exclude numbers.
        /// </summary>
        /// <param name="check"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="allowNumbers"></param>
        /// <returns></returns>
        public static bool IsUpperCamelCase(this string check, int minLength = 2, int maxLength = 20, bool allowNumbers = true)
        {
            return CamelCaseCheck(check, true, minLength, maxLength, allowNumbers);
        }

        /// <summary>
        /// Checks if a string is in lowerCamelCase.
        /// Allows to set length constraints and include/exclude numbers.
        /// </summary>
        /// <param name="check"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="allowNumbers"></param>
        /// <returns></returns>
        public static bool IsLowerCamelCase(this string check, int minLength = 2, int maxLength = 20, bool allowNumbers = true)
        {
            return CamelCaseCheck(check, false, minLength, maxLength, allowNumbers);
        }

        /// <summary>
        /// Internal check for upper- and lower camel case checks.
        /// </summary>
        /// <param name="check"></param>
        /// <param name="upper"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="allowNumbers"></param>
        /// <returns></returns>
        private static bool CamelCaseCheck(string check, bool upper, int minLength, int maxLength, bool allowNumbers)
        {
            ValidateLengthInputs(minLength, maxLength);

            int min = minLength - 1;
            int max = maxLength - 1;

            string numPattern = allowNumbers ? "0-9" : String.Empty;
            string upperLowerPattern = upper ? "A-Z" : "a-z";

            string pattern = String.Format("^[{3}]{{1}}[{2}A-Za-z]{{{0},{1}}}$", min, max, numPattern, upperLowerPattern);

            return check.IsRegexMatch(pattern);
        }

        #endregion

        /// <summary>
        /// Throw exceptions if length parameters are not correct.
        /// </summary>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        private static void ValidateLengthInputs(int minLength, int maxLength)
        {
            if (minLength <= 1 || maxLength <= 1)
                throw new ArgumentException("Length has to be larger than 2");

            if (minLength > maxLength)
                throw new ArgumentException("Minimum length has to be smaller than maximum length");
        }

        /// <summary>
        /// Internal Regex Check
        /// </summary>
        /// <param name="check"></param>
        /// <param name="regexPattern"></param>
        /// <returns></returns>
        public static bool IsRegexMatch(this string check, string regexPattern)
        {
            if (check == null)
                throw new ArgumentException("Can't check on null");

            if (String.IsNullOrEmpty(regexPattern))
                throw new ArgumentException("Need a regex pattern");

            Regex regex = new Regex(regexPattern);
            return regex.IsMatch(check);
        }

        #endregion
    }

    /// <summary>
    /// Definition of which letter cases are permitted
    /// </summary>
    public enum RegexLetterCase
    {
        CapitalOnly,
        LowerOnly,
        Both
    }
}