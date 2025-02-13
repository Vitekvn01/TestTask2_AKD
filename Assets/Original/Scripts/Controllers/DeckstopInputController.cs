using System;
using UnityEngine;

public class DeckstopInputController : MonoBehaviour, IInputController
{
    public event Action<Vector2> OnTouchEvent;

    public float GetAxisHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetAxisVertical()
    {
        return Input.GetAxis("Vertical");
    }

    public float GetAxisMouseX()
    {
        return Input.GetAxis("Mouse X");
    }

    public float GetAxisMouseY()
    {
        return Input.GetAxis("Mouse Y");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            OnTouchEvent?.Invoke(mousePosition);
        }
    }
}
