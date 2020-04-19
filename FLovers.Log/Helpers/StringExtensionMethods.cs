using System;
using System.Linq;
using System.Text;

namespace FLovers.Log.Helpers
{
    /// <summary>
    /// Source:
    /// http://blog.csharphelper.com/2010/06/13/convert-strings-between-pascal-case-camel-case-and-proper-case-in-c.aspx
    /// </summary>
    public static class StringExtensionMethods
    {
        
        /// <summary>
        /// Convert the string to Pascal case.
        /// </summary>
        /// <param name="theString">the string to turn into Pascal case</param>
        /// <returns>a string formatted as Pascal case</returns>
        public static string ToPascalCase(this string theString)
        {
            // If there are 0 or 1 characters, just return the string.
            if (theString == null) return theString;
            if (theString.Length < 2) return theString.ToUpper();

            // Split the string into words.
            string[] words = theString.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            string result = "";
            foreach (string word in words)
            {
                result +=
                    word.Substring(0, 1).ToUpper() +
                    word.Substring(1);
            }

            return result;
        }
        
        /// <summary>
        /// Convert the string to camel case.
        /// </summary>
        /// <param name="theString">the string to turn into Camel case</param>
        /// <returns>a string formatted as Camel case</returns>
        public static string ToCamelCase(this string theString)
        {
            // If there are 0 or 1 characters, just return the string.
            if (theString == null || theString.Length < 2) return theString;

            // Split the string into words.
            string[] words = theString.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            string result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                result +=
                    words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1);
            }

            return result;
        }

        /// <summary>
        /// Capitalize the first character and add a space before 
        /// each capitalized letter (except the first character). 
        /// </summary>
        /// <param name="theString">the string to turn into Proper case</param>
        /// <returns>a string formatted as Proper case</returns>
        public static string ToProperCase(this string theString)
        {
            // If there are 0 or 1 characters, just return the string.
            if (theString == null) return theString;
            if (theString.Length < 2) return theString.ToUpper();

            // Start with the first character.
            string result = theString.Substring(0, 1).ToUpper();

            // Add the remaining characters.
            for (int i = 1; i < theString.Length; i++)
            {
                if (Char.IsUpper(theString[i])) result += " ";
                result += theString[i];
            }

            return result;
        }

        private const string NEWLINE = "\r\n";

        /// <summary>
        /// Word wraps the given text to fit within the specified width.
        /// </summary>
        /// <param name="theString"></param>
        /// <param name="width">Width, in characters, to which the text
        /// should be word wrapped</param>
        /// <returns>The modified text</returns>
        /// <see cref="http://www.softcircuits.com/Blog/post/2010/01/10/Implementing-Word-Wrap-in-C.aspx"/>
        public static string WordWrap(this string theString, int width)
        {
            int pos, next;
            StringBuilder sb = new StringBuilder();

            // Lucidity check
            if (width < 1)
                return theString;

            // Parse each line of text
            for (pos = 0; pos < theString.Length; pos = next)
            {
                // Find end of line
                int eol = theString.IndexOf(NEWLINE, pos, StringComparison.Ordinal);

                if (eol == -1)
                    next = eol = theString.Length;
                else
                    next = eol + NEWLINE.Length;

                // Copy this line of text, breaking into smaller lines as needed
                if (eol > pos)
                {
                    do
                    {
                        int len = eol - pos;

                        if (len > width)
                            len = BreakLine(theString, pos, width);

                        sb.Append(theString, pos, len);
                        sb.Append(NEWLINE);

                        // Trim whitespace following break
                        pos += len;

                        while (pos < eol && char.IsWhiteSpace(theString[pos]))
                            pos++;

                    } while (eol > pos);
                }
                else sb.Append(NEWLINE); // Empty line
            }

            return sb.ToString();
        }

        /// <summary>
        /// Locates position to break the given line so as to avoid
        /// breaking words.
        /// </summary>
        /// <param name="text">String that contains line of text</param>
        /// <param name="pos">Index where line of text starts</param>
        /// <param name="max">Maximum line length</param>
        /// <returns>The modified line length</returns>
        public static int BreakLine(string text, int pos, int max)
        {
            // Find last whitespace in line
            int i = max - 1;

            while (i >= 0 && !char.IsWhiteSpace(text[pos + i]))
                i--;

            if (i < 0)
                return max; // No whitespace found; break at maximum length

            // Find start of whitespace
            while (i >= 0 && char.IsWhiteSpace(text[pos + i]))
                i--;

            // Return length of text before whitespace
            return i + 1;
        }

        /// <summary>
        /// Returns part of a string up to the specified number of characters, while maintaining full words
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length">Maximum characters to be returned</param>
        /// <returns>String</returns>
        public static string Chop(this string s, int length)
        {
            if (String.IsNullOrEmpty(s))
                throw new ArgumentNullException(s);
            var words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            foreach (var word in words.Where(word => (sb.ToString().Length + word.Length) <= length))
            {
                sb.Append(word + " ");
            }
            return sb.ToString().TrimEnd(' ') + "...";
        }

    }
}