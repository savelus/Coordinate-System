using DefaultNamespace;
using UnityEngine;
public class InputSystem : MonoBehaviour
{
    private GameManager _gameManager;

    private CoordinateSystem _coordinateSystem;

    private Line _currentLine;
    private Vector3 _mousePosition;

    public void Initialize(GameManager gameManager, CoordinateSystem coordinateSystem)
    {
        _coordinateSystem = coordinateSystem;
        _gameManager = gameManager;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (_gameManager.CurrentState)
            {
                case GameState.DrawingStartPoint:
                    _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _mousePosition.z = 0;
                    _coordinateSystem.DrawOriginCoordinatesPoint(_mousePosition);
                    _gameManager.ChangeGameState();
                    break;
                case GameState.DrawingAbscissa:
                    _coordinateSystem.Abscissa ??= new Line("Abscissa", _coordinateSystem.LineMaterial,
                        _coordinateSystem.LineWidth, _coordinateSystem.transform);
                    _currentLine = _coordinateSystem.Abscissa;
                    _coordinateSystem.FirstDrawLine(_currentLine);
                    break;
                case GameState.DrawingOrdinate:
                    _coordinateSystem.Ordinate ??= new Line("Ordinate", _coordinateSystem.LineMaterial,
                        _coordinateSystem.LineWidth, _coordinateSystem.transform);
                    _currentLine = _coordinateSystem.Ordinate;
                    _coordinateSystem.FirstDrawLine(_currentLine);
                    break;
                
            }
        } else if(Input.GetMouseButtonUp(0) && _currentLine != null  && 
                  _gameManager.CurrentState is GameState.DrawingAbscissa or GameState.DrawingOrdinate )
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = 0;
            _currentLine.LineRenderer.SetPosition(1, _mousePosition);
            _currentLine.EndPosition = _mousePosition;
            _gameManager.ChangeGameState();
        } else if(Input.GetMouseButton(0) && _currentLine != null &&
                  _gameManager.CurrentState is GameState.DrawingAbscissa or GameState.DrawingOrdinate)
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = 0;
            
            _currentLine.LineRenderer.SetPosition(1, _mousePosition);
        }
        
    }
}