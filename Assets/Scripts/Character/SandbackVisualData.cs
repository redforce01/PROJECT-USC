using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    [CreateAssetMenu(fileName = "SandbackVisualData", menuName = "USC/SandbackVisualData")]
    public class SandbackVisualData : ScriptableObject
    {
        public float rangeMin;
        public float rangeMax;
        public Color color;
    }
}

