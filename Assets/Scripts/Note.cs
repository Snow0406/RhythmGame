using System;
using RhythmGame.Data;
using RhythmGame.Manager;
using UnityEngine;

namespace RhythmGame
{
    public class Note : MonoBehaviour
    {
        private float speed;
        private JudgementLine judgementLine;
        private NoteData noteData;
        private bool isJudged;
        //private bool isHolding;
        //private float holdStartTime;
        private KeyCode[] trackKeys = new KeyCode[] { KeyCode.D, KeyCode.F, KeyCode.K, KeyCode.L };

        private void Update()
        {
            if (!GameManager.Instance.IsPlaying) return;
            transform.Translate(Vector2.down * (speed * Time.deltaTime));
            
            if (isJudged) return;
            float distanceToJudgement = Mathf.Abs(transform.position.y - judgementLine.transform.position.y);
            
            switch (noteData.noteType)
            {
                case NoteType.Normal:
                    HandleNormalNote(distanceToJudgement);
                    break;
                case NoteType.Slide:
                    //HandleSlideNote(distanceToJudgement);
                    break;
            }

            if (transform.position.y < judgementLine.transform.position.y - judgementLine.missRange)
            {
                JudgeNote(NoteJudgement.Miss);
            }
        }
        

        public void Initialize(float noteSpeed, JudgementLine judgementLine, NoteData noteData)
        {
            speed = noteSpeed;
            this.judgementLine = judgementLine;
            this.noteData = noteData;
            isJudged = false;
            //isHolding = false;
            UpdateSpriteNote();
        }

        private void UpdateSpriteNote()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            switch (noteData.noteType)
            {
                case NoteType.Normal:
                    spriteRenderer.color = Color.white;
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    break;
                case NoteType.Slide:
                    spriteRenderer.color = Color.cyan;
                    transform.localScale = new Vector3(1f, noteData.duration * speed, 1f);
                    break;
            }
        }
        
        // 이거 타겟팅 RayCast로 하면 될듯

        private void HandleNormalNote(float distance)
        {
            if (Input.GetKeyDown(trackKeys[noteData.line]))
            {
                if (distance <= judgementLine.perfectRange) JudgeNote(NoteJudgement.Perfect);
                else if (distance <= judgementLine.goodRange) JudgeNote(NoteJudgement.Good);
                else JudgeNote(NoteJudgement.Miss);
            }
        }
        
        // private void HandleSlideNote(float distance)
        // {
        //     if (Input.GetKeyDown(trackKeys[noteData.line]) && !isHolding)
        //     {
        //         if (distance <= judgementLine.goodRange)
        //         {
        //             isHolding = true;
        //             holdStartTime = Time.time;
        //         }
        //         else
        //         {
        //             JudgeNote(NoteJudgement.Miss);
        //         }
        //     }
        //
        //     if (isHolding)
        //     {
        //         if (Input.GetKeyDown(trackKeys[noteData.line]))
        //         {
        //             JudgeNote(Time.time - holdStartTime >= noteData.duration
        //                 ? NoteJudgement.Perfect
        //                 : NoteJudgement.Miss);
        //         }
        //         else
        //         {
        //             JudgeNote(NoteJudgement.Miss);
        //         }
        //     }
        // }

        private void JudgeNote(NoteJudgement noteJudgement)
        {
            isJudged = true;
            ScoreManager.Instance.AddScore(noteJudgement);
            gameObject.SetActive(false);
        }
    }
}