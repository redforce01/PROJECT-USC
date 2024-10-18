using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleShooter : MonoBehaviour
{
    public GameObject bulletPrefab; // ���� ������ ���� GameObject
    public Transform firePoint;     // ���� ������ ���� ��ġ�� Transform

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0)) // Mouse Left Button�� ������ ���� 1���� �߻���
        {
            // Fire �Լ��� ȣ��
            Fire();
        }
    }

    void Fire()
    {
        // bullet Prefab�� ���� ���� + firePoint Transform�� ��ġ/ȸ�� ���� ���� ���� ����
        GameObject newObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        newObj.SetActive(true); // ������ GameObject�� Ȱ��ȭ

        // ���� ������ ���� ������Ʈ���� Rigidbody ������Ʈ�� Get �Ͽ� ��������
        Rigidbody newObjRigidbody = newObj.GetComponent<Rigidbody>();

        // ������ Rigidbody ������Ʈ�� ���� ���ϴ� �Լ��� ȣ����
        newObjRigidbody.AddForce(firePoint.forward * 10, ForceMode.Impulse);
    }
}
