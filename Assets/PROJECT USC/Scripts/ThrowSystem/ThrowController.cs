using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace USC
{
    public class ThrowController : MonoBehaviour
    {
        public LineRenderer trajectoryRenderer;

        public Collider[] physicsObjects;
        public Rigidbody bullet;
        public Transform firePosition;
        public float firePower = 10f;
        public int simulationSteps = 300;

        private Scene simulationScene;
        private PhysicsScene physicsScene;

        private void Start()
        {
            CreatePhysicsScene();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Simulation();
            }
        }

        void CreatePhysicsScene()
        {
            simulationScene = SceneManager.CreateScene(
                "SimulationScene",
                new CreateSceneParameters(LocalPhysicsMode.Physics3D));

            physicsScene = simulationScene.GetPhysicsScene();

            for (int i = 0; i < physicsObjects.Length; i++)
            {
                GameObject ghost = Instantiate(
                    physicsObjects[i].gameObject,
                    physicsObjects[i].transform.position,
                    physicsObjects[i].transform.rotation);

                ghost.GetComponent<Renderer>().enabled = false;
                SceneManager.MoveGameObjectToScene(ghost.gameObject, simulationScene);
            }
        }

        public void Simulation()
        {
            Rigidbody ghostBullet = Instantiate(bullet, firePosition.position, firePosition.rotation);
            ghostBullet.gameObject.SetActive(true);
            ghostBullet.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostBullet.gameObject, simulationScene);
            ghostBullet.AddForce(firePosition.forward * firePower, ForceMode.Impulse);

            trajectoryRenderer.positionCount = simulationSteps;

            for (int i = 0; i < simulationSteps; i++)
            {
                physicsScene.Simulate(Time.fixedDeltaTime);
                trajectoryRenderer.SetPosition(i, ghostBullet.position);
            }

            Destroy(ghostBullet.gameObject);
        }
    }
}
