using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Game.DataTypes;
using Game.DataManagers;

namespace Game.GameObjects
{

public class Card : MonoBehaviour
{
    private KanjiInfo m_currentKanji = new KanjiInfo();
    [SerializeField] private Text m_kanjiText;
    [SerializeField] private Text m_onyomiText;
    [SerializeField] private Text m_kunyomiText;
    [SerializeField] private Text m_meaningText;
    [SerializeField] private Text m_levelText;

    void Start()
    {
        
    }

    private void SetText(KanjiInfo _kanjiInfo)
    {

        m_kanjiText.text = _kanjiInfo.Kanji;
        m_onyomiText.text = _kanjiInfo.Onyomi;
        m_kunyomiText.text = _kanjiInfo.Kunyomi;
        m_meaningText.text = _kanjiInfo.Meaning;
        m_levelText.text = _kanjiInfo.JlptLevel;
    }

    public void GetNextKanji(string _jlptLevel)
    {
        SetText(CardDataManager.GetRandomKanji(_jlptLevel));
    }

}

}
