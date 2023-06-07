using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState CurrentState;

    public CoordinateSystem CoordinateSystem;

    public InputSystem InputSystem;

    public InputDataWindow InputDataWindow;
    // Start is called before the first frame update
    void Start()
    {
        InputSystem.Initialize(this, CoordinateSystem);
        InputDataWindow.Initializate(this);
    }

    public void ChangeGameState()
    {
        CurrentState += 1;
        InputDataWindow.gameObject.SetActive(CurrentState == GameState.SetData);
        if(CurrentState == GameState.RunPoint) MoveObject();
    }

    private void MoveObject()
    {
        GameObject movingPoint = Instantiate(CoordinateSystem.OriginCoordinatesPrefab,
            CoordinateSystem.originCoordinates, Quaternion.identity);
        var tween = movingPoint.transform.DOMove(CoordinateSystem.EndPointCoordinate, 3f);
    }
}
