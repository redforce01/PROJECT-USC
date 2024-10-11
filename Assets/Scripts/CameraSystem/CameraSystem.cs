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
        // ������ VirtualCamera GameObject
        public Cinemachine.CinemachineVirtualCamera tpsCamera;
        public Cinemachine.CinemachineVirtualCamera quaterCamera;
        public Cinemachine.CinemachineVirtualCamera fpsCamera;

        private CameraType currentCameraType = CameraType.TPS;
        private bool isZoom = false;

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
        }
    }    
}

