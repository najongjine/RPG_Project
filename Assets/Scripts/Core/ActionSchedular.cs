using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.core
{

    public class ActionSchedular : MonoBehaviour
    {
        IAction currentAction;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void StartAction(IAction action)
        {
            if (currentAction == action)
            {
                return;
            }
            if (currentAction != null)
            {
                currentAction.Cancel();
            }
            
            currentAction = action;
        }

    }
}