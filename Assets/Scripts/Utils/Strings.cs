using System.Collections;
using System.Collections.Generic;

namespace Game.Utils{
public class Strings
{
    // If string contains anything but english alphabet, return false
    public static bool StringIsEnglish(string _str)
    {
        foreach (char c in _str)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }

    // If a string contains english mixed with another language (japanese), break it up into chunks and return as a list
    public static List<string> SplitMultilanguageString(string _str)
    {
        List<string> splitString = new List<string>();
        int startIndex = 0;
        for (int i = 0; i < _str.Length - 1; i++)
        {
            if (
                (char.IsLetter(_str[i]) && !char.IsLetter(_str[i+1])) ||
                (!char.IsLetter(_str[i]) && char.IsLetter(_str[i+1])))
            {
                splitString.Add(_str.Substring(startIndex, i + 1 - startIndex));
                startIndex = i + 1;
            }
        }
        return splitString;
    }

    }

}