using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePhysics : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Trigger Enter Event ��
        // Rigidbody ������Ʈ�� ���� ��ü�� IsTrigger �� True�� üũ �� Collider �� �浹�� ��,
        // �� 1���� ȣ�� �ȴ�.
        Debug.Log("Trigger Enter : " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger Exit Event ��
        // Trigger Enter ���¿� �ִٰ� => �浹�� ������(����������) �� 1���� ȣ�� �ȴ�.
        Debug.Log("Trigger Exit : " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        // Trigger Stay Event ��
        // Trigger Enter �� �� ������Ʈ�� �浹�� ���ӵǴ� ���� ��� ȣ�� �ȴ�.
        // Collision Stay�� transform�� ��ȭ�� ������ ��� ȣ�� �Ǿ��ٰ� �ȳ�������,
        // Trigger Stay�� ��� ȣ���� �ȴ�.
        Debug.Log("Trigger Stay : " + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Collision Enter Event �� 
        // Rigidbody ������Ʈ�� ���� ��ü�� �浹�� ������ �� �� 1���� ȣ�� �ȴ�.
        Debug.Log("���� �浹 ������ ��ü �̸� : " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        // Collision Exit Event ��
        // Collision Enter ���¿� �ִٰ� => �浹�� ������(����������) �� 1���� ȣ�� �ȴ�.
        Debug.Log("�浹�� �ȵǰ� �������� ��ü �̸� : " + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        // Collision Stay Event ��
        // �浹�� ���ӵǴ� ���� ��� ȣ�� �ȴ�.
        // �ٸ�? transform �� ��ȭ(��ġ/ȸ��/������)�� �ƿ� ���ٸ� ���� Ƚ����ŭ�� ȣ�� �Ǿ��ٰ� �����.
        Debug.Log("���� ��� �浹���� ��ü �̸� : " + collision.gameObject.name);
    }
}
