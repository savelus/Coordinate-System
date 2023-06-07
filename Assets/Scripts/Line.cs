using UnityEngine;
using UnityEngine.Rendering;
public class Line
{
        public Vector2 StartPosition { get; set; }
        public Vector2 EndPosition { get; set; }

        public LineRenderer LineRenderer;
        
        public float Tangent => 
                Mathf.Abs(StartPosition.y - EndPosition.y) / Mathf.Abs(StartPosition.x - EndPosition.x);

        private Material _material;
        public Line(string name, Material material, float width)
        {
                LineRenderer = new GameObject(name).AddComponent<LineRenderer>();
                _material = material;
                LineRenderer.positionCount = 2;
                LineRenderer.startWidth = width;
                LineRenderer.endWidth = width;
                LineRenderer.useWorldSpace = true;
                LineRenderer.numCapVertices = 50;
        }
}