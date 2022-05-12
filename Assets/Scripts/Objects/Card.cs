using System.Collections;
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
    [SerializeField] private Button m_button;
    [SerializeField] private TextMeshProUGUI m_kanjiText;
    [SerializeField] private TextMeshProUGUI m_pronunciationText;
    [SerializeField] private TextMeshProUGUI m_definitionText;

    void Start()
    {
        
        if (m_kanjiText == null)
        {
            Debug.LogError("Card::Kanji text field is null");
        }
        if(m_pronunciationText == null)
        {
            Debug.LogError("Card::Onyomi text field is null");
        }
        if (m_definitionText == null)
        {
            Debug.LogError("Card::Kunyomi text field is null");
        }
    }

    private void SetText(KanjiInfo _kanjiInfo)
    {
        m_kanjiText.text = _kanjiInfo.Kanji;
        m_pronunciationText.text = _kanjiInfo.Onyomi;
        m_definitionText.text = _kanjiInfo.Meaning;
    }

    public void GetNextKanji(string _jlptLevel)
    {
        SetText(CardDataManager.GetRandomKanji(_jlptLevel));
    }

}

}
