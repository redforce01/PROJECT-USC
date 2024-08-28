using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGimmick : MonoBehaviour
{
    public GameObject originalPrefab;
    public Vector3 spawnPositionAsLocal;

    private void OnCollisionEnter(Collision collision)
    {
        // Instantiate :
        //  => Instantiate �Լ��� MonoBehaviour Ŭ������ �Լ��μ�,
        //   => �Ѱܹ��� �Ű������� ù ��°�� ���� �����ϴ� �Լ��̴�.
        Instantiate(originalPrefab, transform.position + spawnPositionAsLocal, Quaternion.identity);
    }
}
