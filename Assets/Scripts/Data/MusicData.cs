using System;
using System.Collections.Generic;

namespace RhythmGame.Data
{
    /// <summary>
    /// 노트 타입 (기본 노트, 롱노트)
    /// </summary>
    public enum NoteType
    {
        Normal,
        Slide
    }

    /// <summary>
    /// 노트 판정 (퍼펙트, 굿, 미스)
    /// </summary>
    public enum NoteJudgement
    {
        Perfect,
        Good,
        Miss
    }
    
    [Serializable]
    public class NoteData
    {
        public float timing;
        public int line; //D,F,K,L 라인
        public NoteType noteType;
    }
    
    [Serializable]
    public class MapData
    {
        public string musicName; // "안녕"
        public float bpm; //12.341f
        public List<NoteData> notes = new List<NoteData>();
    }
}

