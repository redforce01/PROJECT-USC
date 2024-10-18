using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SampleAccessData
{
    public string name;
    public int age;
    public float height;
    public float weight;

    public SampleAccessData(string p_name, int p_age, float p_height, float p_weight)
    {
        name = p_name;
        age = p_age;
        height = p_height;
        weight = p_weight;
    }

    public void ShowData()
    {
        Debug.Log("Name: " + name);
        Debug.Log("Age: " + age);
        Debug.Log("Height: " + height);
        Debug.Log("Weight: " + weight);
    }
}

public class SampleAccess : MonoBehaviour
{
    public SampleAccessData dataA;
    public SampleAccessData dataB;

    private void Start()
    {
        dataA = new SampleAccessData("Iron man", 17, 178.6f, 70.7f);
        dataB = new SampleAccessData("Captain", 20, 180.8f, 78.5f);

        dataA.ShowData();
        dataB.ShowData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeDataA();
        }
    }

    public void ChangeDataA()
    {
        dataA.name = "Hulk";
        dataA.age = 30;
        dataA.height = 200.0f;
        dataA.weight = 150.0f;

        dataA.ShowData();
    }
}
