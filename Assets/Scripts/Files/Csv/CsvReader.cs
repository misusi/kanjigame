using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Game.Files.Csv
{

    public class CsvReader
    {
        // Returns a list of string lists (list of rows that are broken into lists of strings)
        static public List<List<string>> GetStringListsFromCsvRows(string csvPath)
        {
            List < List<string> > listOfStringLists = new List<List<string>>();
            StreamReader reader = new StreamReader(csvPath, true);
            
            // Get rid of headings line
            //string[] headings = reader.ReadLine().Split(',');// Don't need

            while (!reader.EndOfStream)
            {
                string newRow = reader.ReadLine();

                // Find indexes of commas (that aren't inside quotes)
                List<int> breakIndexes = new List<int>();
                int currIndex = 0;
                bool insideQuotes = false;
                while (currIndex < newRow.Length)
                {

                    if (newRow[currIndex] == '"')
                    {
                        insideQuotes = !insideQuotes;
                    }

                    else if (!insideQuotes)
                    {
                        if (newRow[currIndex] == ',')
                        {
                            breakIndexes.Add(currIndex);
                        }
                    }

                    currIndex++;
                }

                // Create list of strings (substrings) from the found indexes
                int prevBreakIndex = -1;
                List<string> rowStrings = new List<string>();
                foreach (int breakIndex in breakIndexes)
                {
                    rowStrings.Add(newRow.Substring(prevBreakIndex + 1, breakIndex - prevBreakIndex - 1).Trim('"'));
                    prevBreakIndex = breakIndex;
                    if (prevBreakIndex == breakIndexes[breakIndexes.Count-1])
                    {
                        rowStrings.Add(newRow.Substring(breakIndex + 1, newRow.Length - prevBreakIndex - 1).Trim('"'));
                    }
                }

                // Append this string list to the total list from the csv file
                listOfStringLists.Add(rowStrings);
            };
            return listOfStringLists;
        }



    }

}