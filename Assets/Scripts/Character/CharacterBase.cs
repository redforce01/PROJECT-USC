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

            // Todo: �����ϴ� �ִϸ��̼� �����ϴ� ó��
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

            // Todo : ĳ���Ͱ� �����ִٰ� �ִϸ��������� �˷��ִ� ó��
            characterAnimator.SetBool("IsGrounded", isGrounded);
        }

        public void Attack()
        {
            characterAnimator.SetTrigger("AttackTrigger");
        }
    }
}

