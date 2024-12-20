using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class WeaponBase : MonoBehaviour
    {
        public int RemainAmmo => currentAmmo; // 현재 탄창의 남은 총알 수를 반환하는 프로퍼티

        public CharacterBase Owner
        {
            get => owner;
            set => owner = value;
        }

        private Cinemachine.CinemachineImpulseSource impulseSource; // 총기 반동을 위한 CinemachineImpulseSource 객체
        private CharacterBase owner; // 무기를 소유한 캐릭터 객체

        public Projectile bulletPrefab; // 총알 프리팹 객체 - 발사 시 => 복사할 총알의 원본 GameObject
        public Transform firePoint; // 총알 발사 위치+방향을 의미하는 Transform

        public float fireRate; // 연사 속도 (시간 값) => ex) 0.1: 0.1초에 1발씩 발사 할 수 있는 값
        public int clipSize; // 탄창 크기
        public float spread = 1f;

        private float lastFireTime; // 마지막 발사 실제 시간
        private int currentAmmo; // 현재 탄창의 남은 총알 수

        private void Awake()
        {
            currentAmmo = clipSize;
            fireRate = Mathf.Max(fireRate, 0.1f); // 연사 속도가 0.1보다 작다면, 0.1로 설정
            impulseSource = GetComponent<Cinemachine.CinemachineImpulseSource>();
        }

        public bool Fire()
        {
            if (currentAmmo <= 0 || Time.time - lastFireTime < fireRate)
                return false;

            Vector2 randomSpread = Random.insideUnitCircle;
            Vector2 spreadRotation = randomSpread * spread;

            Projectile bullet = Instantiate(bulletPrefab,
                firePoint.position,
                firePoint.rotation * Quaternion.Euler(spreadRotation.x, 0f, spreadRotation.y));

            bullet.gameObject.SetActive(true);

            lastFireTime = Time.time;

            currentAmmo--;

            // Muzzle Effect 출력
            EffectManager.Instance.CreateEffect(EffectType.Muzzle_01, firePoint.position, firePoint.rotation);

            // Sound 출력
            SoundManager.Singleton.PlaySFX(SFXFileName.GunFire, firePoint.position);

            if (currentAmmo <= 0)
            {
                SoundManager.Singleton.PlaySFX(SFXFileName.GunEmpty, transform.position);
            }

            // Owner 가 NPC가 아닐 경우 => ImpulseSource를 통해 카메라 Shake 반동을 생성
            if (false == owner.IsNPC)
            {
                impulseSource.GenerateImpulse();
            }

            return true;
        }

        public void Reload()
        {
            currentAmmo = clipSize;
        }
    }
}
