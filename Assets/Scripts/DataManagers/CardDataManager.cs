using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DataTypes;
using Game.Files.Csv;

namespace Game.DataManagers
{

    public class CardDataManager : MonoBehaviour
    {
        private static List<KanjiInfo> KanjiList;
        private static List<KanjiInfo> N5KanjiList = new List<KanjiInfo>();
        private static List<KanjiInfo> N4KanjiList = new List<KanjiInfo>();
        private static List<KanjiInfo> N3KanjiList = new List<KanjiInfo>();
        private static List<KanjiInfo> N2KanjiList = new List<KanjiInfo>();
        private static string csvPath = "Assets/TextResources/kanjiList.csv";

        void Awake()
        {
            Initialize();
        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Initialize()
        {
            KanjiList = Files.Csv.CsvConverter
                .csvToKanji(CsvReader
                .GetStringListsFromCsvRows(csvPath));
            SplitKanjiOnJlptLevel();
        }

        public static KanjiInfo GetRandomKanji(string _jlptLevel = "ANY")
        {
            KanjiInfo kanji = new KanjiInfo();
            switch (_jlptLevel)
            {
                case ("ANY"):
                    kanji = KanjiList[Random.Range(0, KanjiList.Count)];
                    break;
                case ("N5"):
                    kanji = N5KanjiList[Random.Range(0, N5KanjiList.Count)];
                    break;
                case ("N4"):
                    kanji = N5KanjiList[Random.Range(0, N4KanjiList.Count)];
                    break;
                case ("N3"):
                    kanji = N5KanjiList[Random.Range(0, N3KanjiList.Count)];
                    break;
                case ("N2"):
                    kanji = N5KanjiList[Random.Range(0, N2KanjiList.Count)];
                    break;
                default:
                    // TODO: Throw error because csv file has an error
                    break;
            }
            return kanji;
        }

        void SplitKanjiOnJlptLevel()
        {
            foreach (KanjiInfo data in KanjiList)
            {
                switch (data.JlptLevel)
                {
                    case ("N5"):
                        N5KanjiList.Add(data);
                        break;
                    case ("N4"):
                        N4KanjiList.Add(data);
                        break;
                    case ("N3"):
                        N3KanjiList.Add(data);
                        break;
                    case ("N2"):
                        N2KanjiList.Add(data);
                        break;
                    /*
                case("N1"):
                    break;
                    */
                    default:
                        break;
                }
            }
        }
    }

}