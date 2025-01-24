using System.Collections.Generic;
using RhythmGame.Data;
using RhythmGame.Manager;
using UnityEngine;

namespace RhythmGame
{
    public class NoteSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject notePrefab;
        [SerializeField] private int notePoolSize = 20;
        [SerializeField] private float noteSpeed = 5f;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private JudgementLine judgementLine;
        
        private ObjectPool _notePool;
        private Queue<NoteData> _noteQueue;
        private float _distanceToJudgement;
        
    
        private void Start()
        {
            _notePool = new ObjectPool(notePrefab, notePoolSize);
            _noteQueue = new Queue<NoteData>();
            _distanceToJudgement = Mathf.Abs(spawnPoint.position.y - judgementLine.transform.position.y);
        }

        private void Update()
        {
            if (!GameManager.Instance.IsPlaying || _noteQueue.Count == 0) return;
            
            float currentTime = GameManager.Instance.audioSource.time;
            float spawnTime = _distanceToJudgement / noteSpeed;

            while (_noteQueue.Count > 0 && _noteQueue.Peek().timing <= currentTime + spawnTime)
            {
                SpawnNote(_noteQueue.Dequeue());
            }
        }

        private void SpawnNote(NoteData noteData)
        {
            GameObject note = _notePool.GetPool();
            float trackWidth = 2f;
            float startX = -5f;
            note.transform.position = new Vector2(startX + (noteData.line * trackWidth), spawnPoint.position.y);
            //note.GetComponent<Note>().Initialize(noteSpeed, judgementLine, noteData);
        }
    }
}