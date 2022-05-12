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
            string[] headings = reader.ReadLine().Split(',');// Don't need

            while (!reader.EndOfStream)
            {
                // Remove heading
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
                List<string> rowStrings = new List<string> { 
                    newRow.Substring(0, breakIndexes[0]),
                    newRow.Substring(breakIndexes[0] + 1, breakIndexes[1] - breakIndexes[0] - 1).Trim('"'),
                    newRow.Substring(breakIndexes[1] + 1, breakIndexes[2] - breakIndexes[1] - 1).Trim('"'),
                    newRow.Substring(breakIndexes[2] + 1, newRow.Length - breakIndexes[2] - 1).Trim('"'),
                };

            // Append this string list to the total list from the csv file
            listOfStringLists.Add(rowStrings);
            };
            return listOfStringLists;
        }



    }

}