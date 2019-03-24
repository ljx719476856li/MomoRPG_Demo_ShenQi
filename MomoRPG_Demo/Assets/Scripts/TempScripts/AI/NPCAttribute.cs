using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public enum CharacterState
    {
        Idle,
        Running,
        Attacking,
        Around,
        Stunned,
        Dead,
        Birth,
        CastSkill,
        Story,
        Patrol,

        Flee,
    };

    public class NPCAttribute : MonoBehaviour
    {
        public CharacterState _characterState = CharacterState.Idle;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}



