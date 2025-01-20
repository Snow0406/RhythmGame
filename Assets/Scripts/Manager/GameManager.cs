using System;
using System.IO;
using RhythmGame.Data;
using UnityEngine;

namespace RhythmGame.Manager
{
    /// <summary>
    /// Music 씬에서 관리하는 게임 매니저
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private string musicMapName;
        
        private MapData _currentMap;
        private bool _isPlaying;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            LoadMap(musicMapName);
        }

        private void LoadMap(string mapName)
        {
            try
            { 
                string path = Application.dataPath + "MusicMaps/" + mapName + ".json";
                string data = File.ReadAllText(path);
                _currentMap = JsonUtility.FromJson<MapData>(data);
                Debug.Log("LoadMap Success");
            }
            catch (Exception e)
            {
                Debug.Log($"LoadMap Error: {e}");
            }
        }

        public void PlayGame()
        {
            _isPlaying = true;
        }

        public void PauseGame()
        {
            if (!_isPlaying) return; // _isPlaying == false, !_isPlaying
            _isPlaying = false;
        }
    }
}