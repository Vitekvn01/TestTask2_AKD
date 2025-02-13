using System;
using UnityEngine;

public interface IInputController
{
    public event Action<Vector2> OnTouchEvent;
    public float GetAxisVertical();

    public float GetAxisHorizontal();

    public float GetAxisMouseY();

    public float GetAxisMouseX();

}
