using System.Collections.Generic;
using Game.DataTypes;

namespace Game.Files.Csv
{
    public class CsvConverter
    {
        // Take in list of string lists (from csvreader output), output a List<new-datatype>
        static public List<KanjiInfo> csvToKanji(List<List<string>> _listOfStringLists)
        {
            List<KanjiInfo> kanjiList = new List<KanjiInfo>();
            foreach(List<string> stringList in _listOfStringLists)
            {
                kanjiList.Add(new KanjiInfo
                {
                    Kanji = stringList[0],
                    Onyomi = stringList[1],
                    Kunyomi = stringList[2],
                    Meaning = stringList[3],
                    JlptLevel = stringList[4]
                });
            }
            return kanjiList;
        }
    }
}
