using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal static class InputSystem
{
    private readonly static int _centerOfXCoords = Screen.width / 2;

    public static InputType GetClick()
    {
        if (Input.touchCount > 0)
        {
            bool isLeftSideClicked = false;
            bool isRightSideClicked = false;
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.position.x < _centerOfXCoords)
                {
                    isLeftSideClicked = true;
                }
                if (touch.position.x > _centerOfXCoords)
                {
                    isRightSideClicked = true;
                }
            }

            if (isLeftSideClicked && isRightSideClicked)
            {
                return InputType.Both;
            }
            else
            {
                return (isLeftSideClicked) ? InputType.Left : InputType.Right;
            }
        }
        return InputType.None;
    }
    public enum InputType
    {
        Left,
        Right,
        Both,
        None
    };

}
