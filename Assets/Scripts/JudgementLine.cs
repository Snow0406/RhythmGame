using UnityEngine;

namespace RhythmGame
{
    [RequireComponent(typeof(LineRenderer))]
    public class JudgementLine : MonoBehaviour
    {
        public float perfectRange = 0.1f;
        public float goodRange = 0.2f;
        public float missRange = 0.3f;
        
        [Header("Line Settings")]
        [SerializeField] private float lineWidth = 0.2f;
        [SerializeField] private Color lineColor = Color.cyan;
        
        private LineRenderer _line;

        private void Start()
        {
            CreateLine();
        }

        private void CreateLine()
        {
            _line = GetComponent<LineRenderer>();
            _line.startWidth = lineWidth;
            _line.endWidth = lineWidth;
            _line.startColor = lineColor;
            _line.endColor = lineColor;
            _line.material = new Material(Shader.Find("Sprites/Default"));
            _line.SetPosition(0, new Vector3(-5f, transform.position.y, 0f));
            _line.SetPosition(1, new Vector3(5f, transform.position.y, 0f));
        }
    }
}