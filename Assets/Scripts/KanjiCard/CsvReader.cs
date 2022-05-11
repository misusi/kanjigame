using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

namespace KanjiCard
{

    public class CsvReader
    {
        public List<KanjiInfo> ReadKanjiFromCsv(string csvPath)
        {
            List<KanjiInfo> kanjiList = new List<KanjiInfo>();

            StreamReader reader = new StreamReader(csvPath, true);
            // Get rid of headings line
            string[] headings = reader.ReadLine().Split(',');

            while (!reader.EndOfStream)
            {
                string newRow = reader.ReadLine();
                List<int> breakIndexes = new List<int>();

                // Iterate through data row to find splits
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
                KanjiInfo newKanjiInfo = new KanjiInfo()
                {
                    KanjiChar = newRow.Substring(0, breakIndexes[0]).Trim('"'),
                    Pronunciation = newRow.Substring(breakIndexes[0] + 1, breakIndexes[1] - breakIndexes[0] - 1).Trim('"'),
                    Definition = newRow.Substring(breakIndexes[1] + 1, breakIndexes[2] - breakIndexes[1] - 1).Trim('"'),
                    JlptLevel = newRow.Substring(breakIndexes[2] + 1, newRow.Length - breakIndexes[2] - 1).Trim('"'),
                };
                kanjiList.Add(newKanjiInfo);
            }
            return kanjiList;
        }



    }

}