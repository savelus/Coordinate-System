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
                case GameState.DrawingAbscissa:
                    _currentLine = _coordinateSystem.Abscissa;
                    if (_currentLine == null)
                    {
                        _currentLine = new Line("Abscissa", _coordinateSystem.LineMaterial,
                            _coordinateSystem.LineWidth);
                    }
                    _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _mousePosition.z = 0;
                    _currentLine.LineRenderer.SetPosition(0, _mousePosition);
                    _currentLine.LineRenderer.SetPosition(1, _mousePosition);
                    break;
                case GameState.DrawingOrdinate:
                    _currentLine = _coordinateSystem.Ordinate;
                    if (_currentLine == null)
                    {
                        _currentLine = new Line("Abscissa", _coordinateSystem.LineMaterial,
                            _coordinateSystem.LineWidth);
                    }
                    _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _mousePosition.z = 0;
                    _currentLine.LineRenderer.SetPosition(0, _mousePosition);
                    _currentLine.LineRenderer.SetPosition(1, _mousePosition);
                    break;
                
            }
        } else if(Input.GetMouseButtonUp(0) && _currentLine.LineRenderer)
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = 0;
            _currentLine.LineRenderer.SetPosition(1, _mousePosition);
            _currentLine = null;
        } else if(Input.GetMouseButton(0) && _currentLine.LineRenderer)
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = 0;
            _currentLine.LineRenderer.SetPosition(1, _mousePosition);
        }
        
    }
    
}