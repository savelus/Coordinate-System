using UnityEngine;
using UnityEngine.Serialization;

public class CoordinateSystem : MonoBehaviour
{
        public Material LineMaterial;
        public float LineWidth = 0.15f;
        public GameObject originCoordinatesPrefab;
        [HideInInspector] public Line Abscissa;
        [HideInInspector] public Line Ordinate;
        [HideInInspector] public Vector2 StartPoint;

        public Vector3 originCoordinates; 
        public void DrawOriginCoordinatesPoint(Vector3 position)
        {
                Instantiate(originCoordinatesPrefab, position, Quaternion.identity, transform);
                originCoordinates = position;
        }

        public void FirstDrawLine(Line line)
        {
                var mousePosition = originCoordinates;
                line.LineRenderer.SetPosition(0, mousePosition);
                line.LineRenderer.SetPosition(1, mousePosition);
        }
}