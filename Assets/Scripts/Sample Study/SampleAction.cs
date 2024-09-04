using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAction : MonoBehaviour
{
    // To do :
    // 1. Update에서 Input.GetKeyDown 으로 1,2,3번키를 누르면 ?
    // 2.  => 1,2,3번 키를 눌렀을 때, 대응하는 "액션 이벤트"를 수행함 (액션 이벤트가 3개가 필요함)
    // 3.   => 각 액션 이벤트에 구독(:Chain)한 다른 외부 클래스에서 잘 액션이 불러졌다라는 이벤트가 발동됐는지 확인

    // 콜백 함수의 원형을 정의
    //public delegate void ActionEvent();

    //public ActionEvent actionCallback_1;
    //public ActionEvent actionCallback_2;
    //public ActionEvent actionCallback_3;

    // System.Action 을 사용하면 delegate 를 굳이 안만들어도, 콜백 함수를 구현할 수가 있다.
    // 다만, System.Action은 반환형이 void 이어야 한다. (:제한 사항)
    public System.Action actionCallback_1;
    public System.Action actionCallback_2;
    public System.Action actionCallback_3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            actionCallback_1();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            actionCallback_2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            actionCallback_3();
        }
    }
}
