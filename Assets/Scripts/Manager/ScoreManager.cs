// ReSharper disable InconsistentNaming

using RhythmGame.Data;
using UnityEngine;

namespace RhythmGame.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }
        
        public int CurrentScore { get; private set; }
        public int CurrentCombo { get; private set; }
        public int MaxCombo { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        /// <summary>
        /// 노트 판정 점수 추가?
        /// </summary>
        /// <param name="judgement"></param>
        public void AddScore(NoteJudgement judgement)
        {
            switch (judgement)
            {
                case NoteJudgement.Perfect:
                    CurrentScore += 100;
                    CurrentCombo++;
                    break;
                case NoteJudgement.Good:
                    CurrentScore += 50;
                    CurrentCombo++;
                    break;
                case NoteJudgement.Miss:
                    CurrentCombo = 0;
                    break;
            }
        }
    }
}