using System.Collections;
using System.Collections.Generic;

public class KanjiData
{
    public string KanjiChar;
    public string Pronunciation;
    public string Definition;
    public string JlptLevel;
    public KanjiData()
    {
    }
    public KanjiData(string[] _csvDataLine)
    {
        KanjiChar = _csvDataLine[0];
        Pronunciation = _csvDataLine[1];
        Definition = _csvDataLine[2];
        JlptLevel = _csvDataLine[3];
    }
    public override string ToString()
    {
        return KanjiChar + "\n" + Pronunciation + "\n" + Definition + "\n" + JlptLevel;
    }
}
