using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleWhile : MonoBehaviour
{
    public int chance = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowLog();
        }
    }

    private void ShowLog()
    {
        //for (int i = 0; i < chance; i++)
        //{
        //    Debug.Log("Chance : " + i);
        //    if (i > 2)
        //    {
        //        break;
        //    }
        //}

        int i = 0;
        while (i < chance)
        {
            Debug.Log("Chance : " + i);
            if (i > 2)
            {
                break;
            }
            i++;
        }
    }
}
