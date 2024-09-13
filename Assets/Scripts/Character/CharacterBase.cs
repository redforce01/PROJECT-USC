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

            // Movement Blend : 를 이용하는 이유는 애니메이션에 적용할 parameter 값을 갑자기 튀지 않도록
            // 하기 위해서 중간(보간)값을 구해서 적용을 했음
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

