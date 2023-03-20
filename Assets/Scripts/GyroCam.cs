using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCam : MonoBehaviour
{

    private bool _isGyroEnabled;
    private Gyroscope gyroscope;
    void Awake()
    {
        _isGyroEnabled = SystemInfo.supportsGyroscope;

        if (_isGyroEnabled)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
        }
    }

    void Update()
    {
        if (_isGyroEnabled)
        {
            transform.rotation = GyroToUnity(gyroscope.attitude);
        }
    }

    private Quaternion GyroToUnity(Quaternion quaternion)
    {
        return new Quaternion(
            0,
            -5 * SetToTheBorders(quaternion.y, -1, 1),
            0, 
            180);
    }

    private float SetToTheBorders(float value, float min, float max)
    {
        if (value < min)
        {
            return min;
        }

        if (value > max)
        {
            return max;
        }

        return value;
    }
}
