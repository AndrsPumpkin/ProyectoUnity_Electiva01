using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject objeto3D;
    [Header("Audio")]
    public AudioClip sonido;

    private int currentAction = 0;
    private int currentDirection = 0;
    private bool isActive = false;
    
    void Start()
    {
        
    }

    public void PlaySound()
    {
        if (sonido != null)
        {
            AudioSource.PlayClipAtPoint(sonido, Camera.main.transform.position);
        }
    }

    void Update()
{
    if (!isActive) return;

    switch (currentAction)
    {
        case 0:
            Translate(currentDirection);
            break;
        case 1:
            Rotate(currentDirection);
            break;
         case 2:
            Scale(currentDirection);
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

// Rotación
public void RotateRight() => StartAction(1, 2);
public void RotateLeft()  => StartAction(1, 1);

// Escala
public void ScaleUp()   => StartAction(2, 1);
public void ScaleDown() => StartAction(2, 2);


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

    objeto3D.transform.Translate(movement * Time.deltaTime * 50f, Space.World);
}

public void Rotate(int direction)
{
    float rotation = direction == 1 ? 1f : -1f;

    objeto3D.transform.Rotate(
        Vector3.up * rotation * Time.deltaTime * 50f,
        Space.World);
}

public void Scale(int direction)
{
    float scale = direction == 1 ? 1f : -1f;

    objeto3D.transform.localScale +=
        Vector3.one * scale * Time.deltaTime* 10f;
}

}
