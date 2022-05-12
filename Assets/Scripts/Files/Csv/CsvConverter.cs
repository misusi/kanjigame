using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                    KanjiChar = stringList[0],
                    Pronunciation = stringList[1],
                    Definition = stringList[2],
                    JlptLevel = stringList[3]
                });
            }
            return kanjiList;
        }
    }
}
