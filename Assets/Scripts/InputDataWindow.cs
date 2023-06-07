using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputDataWindow : MonoBehaviour
{
    public TMP_InputField DivisionInput;
    public TMP_InputField AbscissaInput;
    public TMP_InputField OrdinateInput;
    public Button EnterButton;

    private int _inputDivisions;
    private Vector2Int _pointPosition;
    private GameManager _gameManager;

    public void Initializate(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    private void Start()
    {
        EnterButton.onClick.AddListener(EnterData);
    }

    private void EnterData()
    { 
        if(!CheckData()) return;
        _gameManager.CoordinateSystem.DrawDivisions(_inputDivisions);
        _gameManager.CoordinateSystem.DrawEndPoint(_pointPosition);
        _gameManager.ChangeGameState();
    }

    private bool CheckData()
    {
        int abscissaInputInt;
        int ordinateInputInt;
        if (!(int.TryParse(DivisionInput.text, out _inputDivisions) &&
              int.TryParse(AbscissaInput.text, out abscissaInputInt) &&
              int.TryParse(OrdinateInput.text, out ordinateInputInt))) return false;
        if(!(abscissaInputInt <  _inputDivisions && ordinateInputInt < _inputDivisions)) return false;
        _pointPosition = new Vector2Int(abscissaInputInt, ordinateInputInt);
        return true;
    }
}
