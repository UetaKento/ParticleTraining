using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachineExample
{
    public class State1 : MonoBehaviour
    {
        [SerializeField]
        private Button HomeButton;
        [SerializeField]
        private Button State1Button;
        [SerializeField]
        private Button State2Button;

        [StateEnterMethod("Base.State1")]
        public void OnStateEnter()
        {
            Debug.Log("Enter:State1");
            InitializeButtons();
        }

        [StateUpdateMethod("Base.State1")]
        public void OnStateUpdate()
        {
            Debug.Log("Update:State1");
        }

        [StateExitMethod("Base.State1")]
        public void OnStateExit()
        {
            Debug.Log("Exit:State1");
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