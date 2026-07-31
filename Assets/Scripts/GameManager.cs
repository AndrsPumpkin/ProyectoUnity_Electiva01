using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject objeto3D;
    private int currentAction = 0;
    private int currentDirection = 0;
    private bool isActive = false;
    
    void Start()
    {
        
    }

    void Update()
{
    if (!isActive) return;

    switch (currentAction)
    {
        case 0:
            Translate(currentDirection);
            break;
    }
}

private void StartAction(int action, int direction)
{
    currentAction = action;
    currentDirection = direction;
    isActive = true;
}

public void StopAction()
{
    isActive = false;
}

// Traslación
public void TranslateUp()    => StartAction(0, 1);
public void TranslateRight() => StartAction(0, 2);
public void TranslateDown()  => StartAction(0, 3);
public void TranslateLeft()  => StartAction(0, 4);



public void Translate(int direction)
{
    Vector3 movement = direction switch
    {
        1 => Vector3.up,
        2 => Vector3.right,
        3 => Vector3.down,
        4 => Vector3.left,
        _ => Vector3.zero
    };

    objeto3D.transform.Translate(movement * Time.deltaTime * 10f, Space.World);
}

}
