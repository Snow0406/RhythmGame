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
        [SerializeField] private float lineWidth = 2f;
        [SerializeField] private Color lineColor = Color.cyan;
        
        private LineRenderer line;

        private void Start()
        {
            CreateLine();
        }

        private void CreateLine()
        {
            line = GetComponent<LineRenderer>();
            line.startWidth = lineWidth;
            line.endWidth = lineWidth;
            line.startColor = lineColor;
            line.endColor = lineColor;
            line.material = new Material(Shader.Find("Sprites/Default"));
            line.SetPosition(0, new Vector3(-5f, transform.position.y, 0f));
            line.SetPosition(1, new Vector3(5f, transform.position.y, 0f));
        }
    }
}