using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    private int _centerOfXCoords;

    private void Awake()
    {
        _centerOfXCoords = Screen.width / 2;
    }

    private void Update()
    {
        if (!EndGameMenu.IsGamePaused)
        {
            int direction = 0;
            if (InputSystem.GetClick() == InputSystem.InputType.Left)
            {
                if (transform.position.x > -1f)
                {
                    direction = -1;
                }
            }
            else if (InputSystem.GetClick() == InputSystem.InputType.Right)
            {
                if (transform.position.x < 1f)
                {
                    direction = 1;
                }
            }


            transform.Translate(new Vector3(
                       direction * (_speed + Time.timeSinceLevelLoad / 500f),
                       0,
                       0), Space.World);
            transform.Rotate(new Vector3(0, 1, 0), direction * (_speed * 50 + Time.timeSinceLevelLoad / 500f));
        }
    }
}
