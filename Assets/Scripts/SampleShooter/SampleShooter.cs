using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleShooter : MonoBehaviour
{
    public GameObject bulletPrefab; // 복제 생성할 원본 GameObject
    public Transform firePoint;     // 복제 생성할 시작 위치의 Transform

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0)) // Mouse Left Button이 눌러진 순간 1번만 발생함
        {
            // Fire 함수를 호출
            Fire();
        }
    }

    void Fire()
    {
        // bullet Prefab을 복제 생성 + firePoint Transform의 위치/회전 값을 넣은 곳에 생성
        GameObject newObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        newObj.SetActive(true); // 생성된 GameObject를 활성화

        // 새로 복제한 게임 오브젝트에서 Rigidbody 컴포넌트를 Get 하여 가져오고
        Rigidbody newObjRigidbody = newObj.GetComponent<Rigidbody>();

        // 가져온 Rigidbody 컴포넌트에 힘을 가하는 함수를 호출함
        newObjRigidbody.AddForce(firePoint.forward * 10, ForceMode.Impulse);
    }
}
