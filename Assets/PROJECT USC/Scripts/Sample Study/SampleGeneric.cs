using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class Character<T>
    {
        public virtual void ExecuteSkill() 
        { 
        }
    }

    public class Goblin : Character<Goblin>
    {
        public override void ExecuteSkill()
        {
            Debug.Log("Goblin Skill Execute");
        }
    }

    public class Orc : Character<Orc>
    {
        public override void ExecuteSkill()
        {
            Debug.Log("Orc Skill Execute");
        }
    }


    public class SampleGeneric : MonoBehaviour
    {
        Goblin goblin = new Goblin();
        Orc orc = new Orc();

        List<int> listArray;
        int[] array;

        private void Start()
        {
            ExecuteSkillCharacter<Goblin>(goblin);
        }

        public void ExecuteSkillCharacter<T>(T character) where T : Character<T>
        {
            character.ExecuteSkill();
        }
    }
}
