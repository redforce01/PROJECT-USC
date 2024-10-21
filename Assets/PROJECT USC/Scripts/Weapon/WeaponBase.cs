using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class WeaponBase : MonoBehaviour
    {
        public Projectile bulletPrefab; // �Ѿ� ������ ��ü - �߻� �� => ������ �Ѿ��� ���� GameObject
        public Transform firePoint; // �Ѿ� �߻� ��ġ+������ �ǹ��ϴ� Transform

        public float fireRate; // ���� �ӵ� (�ð� ��) => ex) 0.1: 0.1�ʿ� 1�߾� �߻� �� �� �ִ� ��
        public int clipSize; // źâ ũ��

        private float lastFireTime; // ������ �߻� ���� �ð�
        private int currentAmmo; // ���� źâ�� ���� �Ѿ� ��

        private void Awake()
        {
            currentAmmo = clipSize;
            fireRate = Mathf.Max(fireRate, 0.1f); // ���� �ӵ��� 0.1���� �۴ٸ�, 0.1�� ����
        }

        public bool Fire()
        {
            if (currentAmmo <= 0 || Time.time - lastFireTime < fireRate)
                return false;

            Projectile bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.gameObject.SetActive(true);

            lastFireTime = Time.time;

            // currentAmmo--;

            return true;
        }
    }
}
