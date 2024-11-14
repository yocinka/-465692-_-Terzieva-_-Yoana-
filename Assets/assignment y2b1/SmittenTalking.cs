using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
namespace Unity.FPS.Gameplay
{
    public class SmittenTalking : Objective
    {


        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start(); //idk vro #experimenting basickly calling otger functon script on parent :D
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void endQuest()
        {
            CompleteObjective(string.Empty,  "", "Objective complete : " + Title); // a function to end the quest from other scripts - in this case the dialogue script

        }
    }
    }
