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
        //  => Instantiate 함수는 MonoBehaviour 클래스의 함수로서,
        //   => 넘겨받은 매개변수의 첫 번째를 복제 생성하는 함수이다.
        Instantiate(originalPrefab, transform.position + spawnPositionAsLocal, Quaternion.identity);
    }
}
