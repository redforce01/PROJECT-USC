using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class WeaponBase : MonoBehaviour
    {
        public int RemainAmmo => currentAmmo; // ���� źâ�� ���� �Ѿ� ���� ��ȯ�ϴ� ������Ƽ

        public CharacterBase Owner
        {
            get => owner;
            set => owner = value;
        }

        private Cinemachine.CinemachineImpulseSource impulseSource; // �ѱ� �ݵ��� ���� CinemachineImpulseSource ��ü
        private CharacterBase owner; // ���⸦ ������ ĳ���� ��ü

        public Projectile bulletPrefab; // �Ѿ� ������ ��ü - �߻� �� => ������ �Ѿ��� ���� GameObject
        public Transform firePoint; // �Ѿ� �߻� ��ġ+������ �ǹ��ϴ� Transform

        public float fireRate; // ���� �ӵ� (�ð� ��) => ex) 0.1: 0.1�ʿ� 1�߾� �߻� �� �� �ִ� ��
        public int clipSize; // źâ ũ��
        public float spread = 1f;

        private float lastFireTime; // ������ �߻� ���� �ð�
        private int currentAmmo; // ���� źâ�� ���� �Ѿ� ��

        private void Awake()
        {
            currentAmmo = clipSize;
            fireRate = Mathf.Max(fireRate, 0.1f); // ���� �ӵ��� 0.1���� �۴ٸ�, 0.1�� ����
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

            // Muzzle Effect ���
            EffectManager.Instance.CreateEffect(EffectType.Muzzle_01, firePoint.position, firePoint.rotation);

            // Sound ���
            SoundManager.Singleton.PlaySFX(SFXFileName.GunFire, firePoint.position);

            if (currentAmmo <= 0)
            {
                SoundManager.Singleton.PlaySFX(SFXFileName.GunEmpty, transform.position);
            }

            // Owner �� NPC�� �ƴ� ��� => ImpulseSource�� ���� ī�޶� Shake �ݵ��� ����
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
