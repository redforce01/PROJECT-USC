using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePhysics : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Trigger Enter Event 는
        // Rigidbody 컴포넌트를 가진 객체가 IsTrigger 가 True로 체크 된 Collider 와 충돌할 때,
        // 딱 1번만 호출 된다.
        Debug.Log("Trigger Enter : " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger Exit Event 는
        // Trigger Enter 상태에 있다가 => 충돌이 끝나면(빠져나가면) 딱 1번만 호출 된다.
        Debug.Log("Trigger Exit : " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        // Trigger Stay Event 는
        // Trigger Enter 가 된 오브젝트와 충돌이 지속되는 동안 계속 호출 된다.
        // Collision Stay는 transform이 변화가 없으면 잠깐 호출 되었다가 안나왔지만,
        // Trigger Stay는 계속 호출이 된다.
        Debug.Log("Trigger Stay : " + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Collision Enter Event 는 
        // Rigidbody 컴포넌트를 가진 객체가 충돌을 시작할 때 딱 1번만 호출 된다.
        Debug.Log("지금 충돌 시작한 객체 이름 : " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        // Collision Exit Event 는
        // Collision Enter 상태에 있다가 => 충돌이 끝나면(빠져나가면) 딱 1번만 호출 된다.
        Debug.Log("충돌이 안되고 빠져나간 객체 이름 : " + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        // Collision Stay Event 는
        // 충돌이 지속되는 동안 계속 호출 된다.
        // 다만? transform 의 변화(위치/회전/스케일)가 아에 없다면 일정 횟수만큼만 호출 되었다가 멈춘다.
        Debug.Log("현재 계속 충돌중인 객체 이름 : " + collision.gameObject.name);
    }
}
