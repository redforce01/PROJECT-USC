using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace USC
{
    public class CharacterBase : MonoBehaviour
    {
        public Animator characterAnimator;
        public UnityEngine.CharacterController unityCharacterController;
        public Rig aimRig;
        public Rig leftHandRig;

        public bool IsArmed { get; set; } = false;
        public bool IsRun { get; set; } = false;
        public Vector3 AimingPoint
        {
            get => aimingPointTransform.position;
            set => aimingPointTransform.position = value;
        }


        public float speed;
        public float armed;
        public float horizontal;
        public float vertical;
        public float runningBlend;

        public GameObject weaponHolder;
        public WeaponBase currentWeapon;
        public Transform aimingPointTransform;

        private bool isShooting = false;
        private bool isReloading = false;

        public void Shoot(bool isShoot)
        {
            isShooting = isShoot;
        }

        public void SetArmed(bool isArmed)
        {
            IsArmed = isArmed;
            if (IsArmed)
            {
                characterAnimator.SetTrigger("Equip Trigger");
            }
            else
            {
                characterAnimator.SetTrigger("Holster Trigger");
            }            
        }

        public void SetEquipState(int equipState)
        {
            bool isEquip = equipState == 1;
            weaponHolder.SetActive(isEquip);
            aimRig.weight = isEquip ? 1f : 0f;
            leftHandRig.weight = isEquip ? 1f : 0f;
        }

        private void Awake()
        {
            characterAnimator = GetComponent<Animator>();
            unityCharacterController = GetComponent<UnityEngine.CharacterController>();

            weaponHolder.SetActive(false);
            aimRig.weight = 0f;
            leftHandRig.weight = 0f;
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
            leftHandRig.weight = 0f;
        }

        public void ReloadComplete()
        {
            currentWeapon.Reload();
            leftHandRig.weight = 1f;
            isReloading = false;

            Invoke(nameof(InvokeLeftHandRigActive), 0.01f);
        }

        void InvokeLeftHandRigActive()
        {
            leftHandRig.weight = 1f;
        }
    }
}