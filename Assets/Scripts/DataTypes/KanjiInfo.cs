using System.Collections.Generic;

namespace Game.DataTypes
{

    public class KanjiInfo
    {
        public string Kanji;
        public string Onyomi;
        public string Kunyomi;
        public string Meaning;
        public string JlptLevel;
        public KanjiInfo()
        {
        }
        public KanjiInfo(string[] _csvDataLine)
        {
            Kanji = _csvDataLine[0];
            Onyomi = _csvDataLine[1];
            Kunyomi = _csvDataLine[2];
            Meaning = _csvDataLine[3];
            JlptLevel = _csvDataLine[4];
        }
        public override string ToString()
        {
            return Kanji + "\n" + Onyomi + "\n" + Kunyomi + "\n" + Meaning + "\n" + JlptLevel;
        }
    }

}