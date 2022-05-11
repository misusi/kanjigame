using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KanjiCard
{

public class Card : MonoBehaviour
{
    KanjiInfo currentKanji = new KanjiInfo();
    CardDataHandler cardDataHandler;
    TextMeshProUGUI kanjiText;
    TextMeshProUGUI pronunciationText;
    TextMeshProUGUI definitionText;

    void Start()
    {
        // Retrieve Kanji List from CSV
        cardDataHandler = FindObjectOfType<CardDataHandler>();
        if (!cardDataHandler)
        {
            Debug.Log("Card data handler object not found.");
        }
        cardDataHandler.Initialize();

        // TODO: Remove
        currentKanji = cardDataHandler.GetRandomKanji("N5");

        // Text
        kanjiText = GetComponentInChildren<TextMeshProUGUI>();
        if (kanjiText == null)
        {
            Debug.LogError("UIHandler: Cannot find component TextMeshProUGUI in children.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetKanjiText(KanjiInfo _kanjiInfo)
    {
        kanjiText.text = _kanjiInfo.KanjiChar;
        pronunciationText.text = _kanjiInfo.Pronunciation;
        definitionText.text = _kanjiInfo.Definition;
    }

}

}
