using UnityEngine;

public class CoordinateSystem
{
        private Vector3 _mousePosition;
        public Material LineMaterial;
        public float LineWidth = 0.15f;
        [HideInInspector] public Line Abscissa;
        [HideInInspector] public Line Ordinate;
        [HideInInspector] public Vector2 StartPoint;

        public void DrawLine(Line line)
        {
                
        }
}