using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class HumanCharacter : AICharacter
    {
        public override void PlayAni(string name, float speed, WrapMode wm)
        {

        }

        public override void SetAni(string name, float speed, WrapMode wm)
        {
            
        }



        public override void SetIdle()
        {
            var idleName = "idle";

        }

        public override void SetRun()
        {
            var runName = "isMoving";
            bool isMoving = true;

            

            //TODO 此处动画分类为两种：
            //run 跑步动画  runName = "Run"
            //walk 走路动画 runName = "walk"
        }
    }
}



