using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachineExample
{
    public class State2 : MonoBehaviour
    {
        [SerializeField]
        private Button HomeButton;
        [SerializeField]
        private Button State1Button;
        [SerializeField]
        private Button State2Button;

        [StateEnterMethod("Base.State2")]
        public void OnStateEnter()
        {
            Debug.Log("Enter:State2");
            InitializeButtons();
        }

        [StateUpdateMethod("Base.State2")]
        public void OnStateUpdate()
        {
            Debug.Log("Update:State2");
        }

        [StateExitMethod("Base.State2")]
        public void OnStateExit()
        {
            Debug.Log("Exit:State2");
        }

        #region Methods
        private void InitializeButtons()
        {
            HomeButton.interactable = true;
            State2Button.interactable = false;
            State1Button.interactable = false;
        }
        #endregion
    }
}