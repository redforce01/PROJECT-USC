using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    [CreateAssetMenu(fileName = "Character Stat Data", menuName = "USC/Character/Character Stat Data")]
    public class CharacterStatData : ScriptableObject
    {
        public float MaxHP;
        public float MaxSP;


        public float WalkSpeed = 1f;
        public float RunSpeed = 2.5f;
        
        public float RunStaminaCost = 3f;
        public float StaminaRecoverySpeed = 2f;

    }
}

