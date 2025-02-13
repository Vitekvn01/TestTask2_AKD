using System;
using UnityEngine;

public class MobileInputController : MonoBehaviour, IInputController
{
    [SerializeField] private Joystick _leftJoystick;
    [SerializeField] private TouchPanel _touchPanel;
    [SerializeField] private float _sensitivity = 1f;

    float mouseX = 0;
    float mouseY = 0;

    public event Action<Vector2> OnTouchEvent;

    public float GetAxisHorizontal()
    {
        return _leftJoystick.Horizontal;
    }

    public float GetAxisVertical()
    {
        return _leftJoystick.Vertical;
    }

    public float GetAxisMouseX()
    {
        return mouseX;
    }

    public float GetAxisMouseY()
    {
        return mouseY;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                OnTouchEvent?.Invoke(touch.position);
            }
        }

        HandleRotationTouch();
    }

    private void HandleRotationTouch()
    {
        if (_touchPanel.IsPressed)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == _touchPanel.FingerId)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        mouseY = touch.deltaPosition.y * _sensitivity;
                        mouseX = touch.deltaPosition.x * _sensitivity;
                    }

                    if (touch.phase == TouchPhase.Stationary)
                    {
                        mouseY = 0;
                        mouseX = 0;
                    }
                }
            }
        }
        else
        {
            mouseY = 0;
            mouseX = 0;
        }

    }


}
