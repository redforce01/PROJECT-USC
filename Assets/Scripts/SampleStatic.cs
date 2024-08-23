using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleUtility
{
    public const int MAX_COUNT = 100;

    public static float PI = 3.141592f;

    public static float GetCircleArea(float radius)
    {
        float result = PI * radius * radius;
        return result;
    }
}

public class SampleStatic : MonoBehaviour
{
    public const float PI = 3.14f;
        
    void Start()
    {
        SampleUtility.PI = 3f;
        int maxCount = SampleUtility.MAX_COUNT;

        float resultA = SampleUtility.GetCircleArea(5.0f);
        float resultB = SampleUtility.GetCircleArea(10.0f);

        Debug.Log(resultA);
        Debug.Log(resultB);
    }
}
