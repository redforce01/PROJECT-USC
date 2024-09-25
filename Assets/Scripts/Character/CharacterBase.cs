using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class CharacterBase : MonoBehaviour
    {
        public Animator characterAnimator;
        public CharacterStatData characterStat;

        public Vector2 movement;
        public Vector2 movementBlend;
        public float rotation = 0f;
        public bool isRunning = false;
        public float runningBlend;

        private void Awake()
        {
            characterAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            CheckGround();
            FreeFall();

            Vector3 moveVec = new Vector3(movementBlend.x, verticalVelocity, movementBlend.y);

            float targetSpeed = isRunning ? characterStat.RunSpeed : characterStat.WalkSpeed;
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


        public void Rotate(float angle)
        {
            rotation += angle;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        public void SetRunning(bool isRun)
        {
            isRunning = isRun;
        }

        [Header("Jump Setting")]
        public float jumpForce;
        public float verticalVelocity;
        public bool isGrounded;
        public float jumpTimeout;
        public float jumpTimeoutDelta;

        public float groundOffset;
        public float groundRadius;
        public LayerMask groundLayer;

        public void Jump()
        {
            if (isGrounded == false || jumpTimeoutDelta > 0f)
                return;

            verticalVelocity = jumpForce;
            jumpTimeoutDelta = jumpTimeout;

            // Todo: 점프하는 애니메이션 시작하는 처리
            characterAnimator.SetTrigger("JumpTrigger");
        }

        public void FreeFall()
        {
            jumpTimeoutDelta -= Time.deltaTime;
            if (isGrounded == false)
            {
                verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                if (jumpTimeoutDelta > 0)
                {
                   
                }
                else
                {
                    verticalVelocity = 0f;
                }
            }
        }

        public void CheckGround()
        {
            Vector3 spherePosition = transform.position + (Vector3.down * groundOffset);
            isGrounded = Physics.CheckSphere(spherePosition, groundRadius, groundLayer, QueryTriggerInteraction.Ignore);

            // Todo : 캐릭터가 땅에있다고 애니메이터한테 알려주는 처리
            characterAnimator.SetBool("IsGrounded", isGrounded);
        }

        public void Attack()
        {
            characterAnimator.SetTrigger("AttackTrigger");
        }
    }
}

