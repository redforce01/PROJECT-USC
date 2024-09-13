using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class CharacterBase : MonoBehaviour
    {
        public Animator characterAnimator;

        public Vector2 movement;
        public Vector2 movementBlend;

        public float characterWalkSpeed = 1f;
        public float characterRunSpeed = 2f;

        public bool isRunning = false;
        public float runningBlend;

        private void Awake()
        {
            characterAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            Vector3 moveVec = new Vector3(movementBlend.x, 0, movementBlend.y);

            float targetSpeed = isRunning ? characterRunSpeed : characterWalkSpeed;
            transform.Translate(targetSpeed * moveVec * Time.deltaTime, Space.Self);

            runningBlend = Mathf.Lerp(runningBlend, isRunning ? 1f : 0f, Time.deltaTime * 10f);

            // Movement Blend : �� �̿��ϴ� ������ �ִϸ��̼ǿ� ������ parameter ���� ���ڱ� Ƣ�� �ʵ���
            // �ϱ� ���ؼ� �߰�(����)���� ���ؼ� ������ ����
            movementBlend = Vector2.Lerp(movementBlend, movement, Time.deltaTime * 10f);

            characterAnimator.SetFloat("Magnitude", movementBlend.magnitude);
            characterAnimator.SetFloat("Horizontal", movementBlend.x);
            characterAnimator.SetFloat("Vertical", movementBlend.y);
            characterAnimator.SetFloat("RunningBlend", runningBlend);
        }

        public void Move(Vector2 input)
        {
            movement = input;
        }

        public void SetRunning(bool isRun)
        {
            isRunning = isRun;
        }
    }
}

