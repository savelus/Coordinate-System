using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState CurrentState;

    public CoordinateSystem CoordinateSystem;

    public InputSystem InputSystem;
    // Start is called before the first frame update
    void Start()
    {
        CoordinateSystem = new();
        InputSystem.Initialize(this, CoordinateSystem);
    }

}
