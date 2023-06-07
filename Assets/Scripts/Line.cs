using UnityEngine;
public class Line
{
        public Vector2 StartPosition { get; set; }
        public Vector2 EndPosition { get; set; }

        public LineRenderer LineRenderer;
        
        public float Tan => 
                Mathf.Abs(StartPosition.y - EndPosition.y) / Mathf.Abs(StartPosition.x - EndPosition.x);
        public float Length => Mathf.Sqrt(
                Mathf.Pow(Mathf.Abs(StartPosition.y - EndPosition.y), 2) + 
                Mathf.Pow(Mathf.Abs(StartPosition.x - EndPosition.x), 2));

        public float Sin => Mathf.Abs(StartPosition.y - EndPosition.y) / Length;
        public float Cos => Mathf.Abs(StartPosition.x - EndPosition.x) / Length;

        private Material _material;
        public Vector2 PointOnLine(float indent)
        { 
                return new Vector2
                {
                        x = StartPosition.x + indent * Cos,
                        y = StartPosition.y + indent * Sin
                };
        }
        
        public Line(string name, Material material, float width, Transform parent)
        {
                LineRenderer = new GameObject(name).AddComponent<LineRenderer>();
                _material = material;
                LineRenderer.positionCount = 2;
                LineRenderer.startWidth = width;
                LineRenderer.endWidth = width;
                LineRenderer.useWorldSpace = true;
                LineRenderer.numCapVertices = 50;
                LineRenderer.transform.SetParent(parent);
        }

        
}