using UnityEngine;

public class CoordinateSystem : MonoBehaviour
{
        public Material LineMaterial;
        public float LineWidth = 0.15f;
        public GameObject OriginCoordinatesPrefab;
        public GameObject DivisionLinePrefab;
        public GameObject EndPointPrefab;
        public Vector2 EndPointCoordinate;
        public Vector3 originCoordinates;
        [HideInInspector] public Line Abscissa;
        [HideInInspector] public Line Ordinate;

        private int _countDivisions;
        public void DrawOriginCoordinatesPoint(Vector3 position)
        {
                Instantiate(OriginCoordinatesPrefab, position, Quaternion.identity, transform);
                originCoordinates = position;
        }

        public void FirstDrawLine(Line line)
        {
                
                line.StartPosition = originCoordinates;
                line.LineRenderer.SetPosition(0, line.StartPosition);
                line.LineRenderer.SetPosition(1, line.StartPosition);
        }

        public void DrawDivisions(int count)
        {
                _countDivisions = count;
                Vector3 divisionMarkerPosition;
                divisionMarkerPosition.z = 0;
                for (int i = 0; i < count; i++)
                {
                        divisionMarkerPosition = Abscissa.PointOnLine(Abscissa.Length / count * i);
                        Instantiate(DivisionLinePrefab, divisionMarkerPosition, Quaternion.identity, Abscissa.LineRenderer.transform);
                        
                        divisionMarkerPosition = Ordinate.PointOnLine(Ordinate.Length / count * i);
                        Instantiate(DivisionLinePrefab, divisionMarkerPosition, Quaternion.identity, Ordinate.LineRenderer.transform);
                }
        }

        public void DrawEndPoint(Vector2Int localCoordinate)
        {
                var abscissaPoint = Abscissa.PointOnLine(Abscissa.Length / _countDivisions * localCoordinate.x);
                Instantiate(EndPointPrefab, abscissaPoint, Quaternion.identity, transform);
                var ordinatePoint = Ordinate.PointOnLine(Ordinate.Length / _countDivisions * localCoordinate.y);
                Instantiate(EndPointPrefab, ordinatePoint, Quaternion.identity, transform);
                EndPointCoordinate.x = abscissaPoint.x + ordinatePoint.x - originCoordinates.x;
                EndPointCoordinate.y = ordinatePoint.y + abscissaPoint.y - originCoordinates.y;
                Instantiate(EndPointPrefab, EndPointCoordinate, Quaternion.identity, transform);
                
        }
}