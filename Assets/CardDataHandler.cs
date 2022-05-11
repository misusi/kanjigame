using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataHandler : MonoBehaviour
{
    public List<KanjiData> KanjiList;
    public List<KanjiData> N5KanjiList = new List<KanjiData>();
    public List<KanjiData> N4KanjiList = new List<KanjiData>();
    public List<KanjiData> N3KanjiList = new List<KanjiData>();
    public List<KanjiData> N2KanjiList = new List<KanjiData>();
    //public List<KanjiData> N1KanjiList = new List<KanjiData>();
    public CsvReader csvReader;
    public string csvPath = "Assets/kanjiList.csv";

    void Start()
    {
        csvReader = new CsvReader();
        KanjiList = csvReader.ReadKanjiFromCsv(csvPath);
        SplitKanjiOnJlptLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SplitKanjiOnJlptLevel()
    {
        foreach (KanjiData data in KanjiList) {
            switch(data.JlptLevel) {
                case("N5"):
                    N5KanjiList.Add(data);
                    break;
                case("N4"):
                    N4KanjiList.Add(data);
                    break;
                case("N3"):
                    N3KanjiList.Add(data);
                    break;
                case("N2"):
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
