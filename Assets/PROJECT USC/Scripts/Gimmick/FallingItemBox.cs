using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class FallingItemBox : MonoBehaviour, IDamage
    {
        private bool isActivatedBox = false;

        public void ApplyDamage(float damage)
        {
            if (!isActivatedBox)
            {
                transform.parent = null;
                Rigidbody boxRigidbody = GetComponent<Rigidbody>();
                boxRigidbody.isKinematic = false;
                
                isActivatedBox = true;
            }
        }
    }
}
