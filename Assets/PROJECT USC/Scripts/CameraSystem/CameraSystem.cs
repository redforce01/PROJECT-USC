using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public enum CameraType
    {
        TPS, QuaterView, FPS,
    }

    public class CameraSystem : MonoBehaviour
    {
        public static CameraSystem Instance { get; private set; } = null;

        // ������ VirtualCamera GameObject
        public Cinemachine.CinemachineVirtualCamera tpsCamera;
        public Cinemachine.CinemachineVirtualCamera quaterCamera;
        public Cinemachine.CinemachineVirtualCamera fpsCamera;

        public Vector3 AimingPoint { get; private set; }

        public LayerMask aimingLayerMask;

        private CameraType currentCameraType = CameraType.TPS;
        private bool isZoom = false;

        private void Awake()
        {
            Instance = this;
        }

        public void ChangeCameraType(CameraType newType)
        {
            // �Ķ���ͷ� �Ѿ�� ī�޶� Ÿ�� ���� currentCameraType�� �����Ѵ�.
            currentCameraType = newType;

            // �ϴ� ��� ī�޶� ���ش�.
            tpsCamera.gameObject.SetActive(false);
            quaterCamera.gameObject.SetActive(false);
            fpsCamera.gameObject.SetActive(false);

            // ���ο� ī�޶� Ÿ�Կ� �ش��ϴ� ī�޶� ���ش�.
            switch (currentCameraType)
            {
                case CameraType.TPS:
                    tpsCamera.gameObject.SetActive(true);
                    break;
                case CameraType.QuaterView:
                    quaterCamera.gameObject.SetActive(true);
                    break;
                case CameraType.FPS:
                    fpsCamera.gameObject.SetActive(true);
                    break;
            }
        }

        private void Update()
        {
            // F1,F2,F3Ű�� ���� ��, ������ �����Ǵ� Virtual Camera �� GameObject�� ���ش�.
            // �ش����� �ʴ� Virtucal Camera�� gameObject�� ���ش�.
            if (Input.GetKeyDown(KeyCode.F1))
            {
                ChangeCameraType(CameraType.TPS);
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                ChangeCameraType(CameraType.QuaterView);
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                ChangeCameraType(CameraType.FPS);
            }

            // ���콺 �� Ŭ��(Right Button)�� �ٿ��� ���� ��, �� 1���� ������ �̺�Ʈ
            if (Input.GetMouseButtonDown(1))
            {
                isZoom = !isZoom;
            }

            float targetFov = isZoom ? 20f : 60f;
            tpsCamera.m_Lens.FieldOfView = Mathf.Lerp(tpsCamera.m_Lens.FieldOfView, targetFov, Time.deltaTime * 5);

            // Aiming Point ���
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 1f));
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000f, aimingLayerMask, 
                QueryTriggerInteraction.Ignore))
            {
                AimingPoint = hitInfo.point;
            }
            else
            {
                AimingPoint = ray.GetPoint(100f);
            }
        }

    }    
}

