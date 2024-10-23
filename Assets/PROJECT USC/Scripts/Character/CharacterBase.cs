using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class CharacterBase : MonoBehaviour
    {
        public Animator characterAnimator;
        public UnityEngine.CharacterController unityCharacterController;

        public bool IsArmed { get; set; } = false;
        public bool IsRun { get; set; } = false;

        public float speed;
        public float armed;
        public float horizontal;
        public float vertical;
        public float runningBlend;

        public GameObject weaponHolder;
        public WeaponBase currentWeapon;

        private bool isShooting = false;
        private bool isReloading = false;

        public void Shoot(bool isShoot)
        {
            isShooting = isShoot;
        }

        public void SetArmed(bool isArmed)
        {
            IsArmed = isArmed;
            weaponHolder.SetActive(isArmed);
        }


        private void Awake()
        {
            characterAnimator = GetComponent<Animator>();
            unityCharacterController = GetComponent<UnityEngine.CharacterController>();
        }

        private void Update()
        {
            if (isShooting)
            {
                bool isFireSuccess = currentWeapon.Fire();
                if (false == isFireSuccess)
                {
                    if (currentWeapon.RemainAmmo <= 0 && false == isReloading)
                    {
                        Reload();
                    }
                }
            }

            armed = Mathf.Lerp(armed, IsArmed ? 1f : 0f, Time.deltaTime * 10f);
            runningBlend = Mathf.Lerp(runningBlend, IsRun ? 1f : 0f, Time.deltaTime * 10f);

            characterAnimator.SetFloat("Speed", speed);
            characterAnimator.SetFloat("Armed", armed);
            characterAnimator.SetFloat("Horizontal", horizontal);
            characterAnimator.SetFloat("Vertical", vertical);
            characterAnimator.SetFloat("RunningBlend", runningBlend);
        }


        public float moveSpeed = 3f;
        public float targetRotation = 0f;
        public float rotationSpeed = 0.1f;

        public void Move(Vector2 input, float yAxisAngle)
        {
            horizontal = input.x;
            vertical = input.y;
            speed = input.magnitude > 0f ? 1f : 0f;

            if (IsArmed)
            {
                Vector3 movement = transform.forward * vertical + transform.right * horizontal;
                unityCharacterController.Move(movement * Time.deltaTime * moveSpeed);
            }
            else
            {
                if (input.magnitude > 0f)
                {
                    targetRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + yAxisAngle;
                    float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationSpeed, 0.1f);
                    transform.rotation = Quaternion.Euler(0f, rotation, 0f);
                }

                unityCharacterController.Move(transform.forward * speed * Time.deltaTime * moveSpeed);
            }
        }

        public void Rotate(float angle)
        {
            float rotation = transform.rotation.eulerAngles.y + angle;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        public void Reload()
        {
            isReloading = true;
            characterAnimator.SetTrigger("Reload Trigger");
        }

        public void ReloadComplete()
        {
            currentWeapon.Reload();
            isReloading = false;
        }
    }
}

#region OLD CODE

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawWireSphere(transform.position, sensorRadius);

        //    for (int i = 0; i < detectedObjects.Count; i++)
        //    {
        //        Gizmos.color = Color.green;
        //        Vector3 startPos = transform.position + Vector3.up;
        //        Vector3 endPos = detectedObjects[i].transform.position;

        //        Gizmos.DrawLine(startPos, endPos);
        //    }
        //}

        //public float sensorRadius = 1f;
        //public Collider[] overlappedObjects;
        //public LayerMask sensorLayer;
        //public List<Collider> detectedObjects = new List<Collider>();
        //public float sensorAngle = 90f;

        //public Animator characterAnimator;
        //public UnityEngine.CharacterController unityCharacterController;
        //public CharacterStatData characterStat;

        //public Vector2 movement;
        //public Vector2 movementBlend;
        //public float rotation = 0f;
        //public bool isRunning = false;
        //public float runningBlend;

        //[Header("Current Value")]
        //public float currentHP;
        //public float currentSP;

        //public float CurrentHP => currentHP;
        //public float CurrentSP => currentSP;
        //public float MaxHP => characterStat.MaxHP;
        //public float MaxSP => characterStat.MaxSP;

        //private void Awake()
        //{
        //    characterAnimator = GetComponent<Animator>();
        //    unityCharacterController = GetComponent<UnityEngine.CharacterController>();

        //    currentHP = characterStat.MaxHP;
        //    currentSP = characterStat.MaxSP;
        //}

        //private void Update()
        //{
        //    CheckGround();
        //    FreeFall();

        //    Vector3 moveVec = new Vector3(movementBlend.x, verticalVelocity, movementBlend.y);

        //    if (isRunning)
        //    {
        //        currentSP -= (characterStat.RunStaminaCost * Time.deltaTime);
        //        currentSP = Mathf.Clamp(currentSP, 0, characterStat.MaxSP);
        //    }
        //    else
        //    {
        //        currentSP += (characterStat.StaminaRecoverySpeed * Time.deltaTime);
        //        currentSP = Mathf.Clamp(currentSP, 0, characterStat.MaxSP);
        //    }
        //    float targetSpeed = isRunning && currentSP > 0 ? characterStat.RunSpeed : characterStat.WalkSpeed;

        //    //transform.Translate(targetSpeed * moveVec * Time.deltaTime, Space.Self);

        //    Vector3 cameraForward = Camera.main.transform.forward.normalized;
        //    cameraForward.y = 0;
        //    Vector3 cameraRight = Camera.main.transform.right.normalized;
        //    cameraRight.y = 0;
        //    Vector3 resultMovement = cameraForward * moveVec.z + cameraRight * moveVec.x;
        //    resultMovement.y = verticalVelocity;

        //    unityCharacterController.Move(resultMovement * targetSpeed * Time.deltaTime);

        //    runningBlend = Mathf.Lerp(runningBlend, isRunning && currentSP > 0 ? 1f : 0f, Time.deltaTime * 10f);

        //    // Movement Blend : 를 이용하는 이유는 애니메이션에 적용할 parameter 값을 갑자기 튀지 않도록
        //    // 하기 위해서 중간(보간)값을 구해서 적용을 했음
        //    movementBlend = Vector2.Lerp(movementBlend, movement, Time.deltaTime * 10f);

        //    characterAnimator.SetFloat("Magnitude", movementBlend.magnitude);
        //    characterAnimator.SetFloat("Horizontal", movementBlend.x);
        //    characterAnimator.SetFloat("Vertical", movementBlend.y);
        //    characterAnimator.SetFloat("RunningBlend", runningBlend);
        //}

        //public void Move(Vector2 input)
        //{
        //    movement = input;
        //}


        //public void Rotate(float angle)
        //{
        //    rotation += angle;
        //    transform.rotation = Quaternion.Euler(0, rotation, 0);
        //}

        //public void SetRunning(bool isRun)
        //{
        //    isRunning = isRun;
        //}

        //[Header("Jump Setting")]
        //public float jumpForce;
        //public float verticalVelocity;
        //public bool isGrounded;
        //public float jumpTimeout;
        //public float jumpTimeoutDelta;

        //public float groundOffset;
        //public float groundRadius;
        //public LayerMask groundLayer;

        //public void Jump()
        //{
        //    if (isGrounded == false || jumpTimeoutDelta > 0f)
        //        return;

        //    verticalVelocity = jumpForce;
        //    jumpTimeoutDelta = jumpTimeout;

        //    // Todo: 점프하는 애니메이션 시작하는 처리
        //    characterAnimator.SetTrigger("JumpTrigger");
        //}

        //public void FreeFall()
        //{
        //    jumpTimeoutDelta -= Time.deltaTime;
        //    if (isGrounded == false)
        //    {
        //        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        //    }
        //    else
        //    {
        //        if (jumpTimeoutDelta > 0)
        //        {

        //        }
        //        else
        //        {
        //            verticalVelocity = 0f;
        //        }
        //    }
        //}

        //public void CheckGround()
        //{
        //    Vector3 spherePosition = transform.position + (Vector3.down * groundOffset);
        //    isGrounded = Physics.CheckSphere(spherePosition, groundRadius, groundLayer, QueryTriggerInteraction.Ignore);

        //    // Todo : 캐릭터가 땅에있다고 애니메이터한테 알려주는 처리
        //    characterAnimator.SetBool("IsGrounded", isGrounded);
        //}


        //public float attackRange = 3f;
        //public float attackAngle = 80f;
        //public float attackDamage = 10f;
        //public LayerMask characterLayer;
        //public LayerMask detectLayer;

        //public void Attack()
        //{
        //    characterAnimator.SetTrigger("AttackTrigger");

        //    overlappedObjects = Physics.OverlapSphere(transform.position, attackRange, characterLayer);
        //    detectedObjects.Clear();
        //    for (int i = 0; i < overlappedObjects.Length; i++)
        //    {
        //        // 오버랩 된 오브젝트의 transform의 루트가 나 자신이라면, continue 해서 다음 루프로 넘어간다.
        //        if (overlappedObjects[i].transform.root == this.transform)
        //        {
        //            continue;
        //        }

        //        Vector3 direction = overlappedObjects[i].transform.position - transform.position;
        //        float dot = Vector3.Dot(transform.forward.normalized, direction.normalized);
        //        if (dot > Mathf.Cos(attackAngle * 0.5f * Mathf.Deg2Rad))
        //        {
        //            Vector3 rayStartPos = transform.position + Vector3.up;
        //            Vector3 rayDirection = overlappedObjects[i].transform.position - transform.position;
        //            rayDirection.y = 0;

        //            if (Physics.Raycast(rayStartPos, rayDirection, out RaycastHit hitInfo, attackRange, detectLayer))
        //            {
        //                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Character"))
        //                {
        //                    detectedObjects.Add(overlappedObjects[i]);

        //                    //SandbackObject target = hitInfo.transform.GetComponent<SandbackObject>();
        //                    //if (target != null)
        //                    //{
        //                    //    target.ApplyDamage(attackDamage);
        //                    //}

        //                    //if (hitInfo.transform.TryGetComponent(out SandbackObject target))
        //                    if (hitInfo.transform.TryGetComponent(out IDamage target))
        //                    {
        //                        target.ApplyDamage(attackDamage);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        #endregion

