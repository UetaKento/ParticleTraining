using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachineExample
{
    public class HomeState : MonoBehaviour
    {
        [SerializeField]
        private Button HomeButton;
        [SerializeField]
        private Button State1Button;
        [SerializeField]
        private Button State2Button;

        [StateEnterMethod("Base.HomeState")]
        public void OnStateEnter()
        {
            Debug.Log("Enter:HomeState");
            InitializeButtons();
        }

        [StateUpdateMethod("Base.HomeState")]
        public void OnStateUpdate()
        {
            Debug.Log("Update:HomeState");
        }

        [StateExitMethod("Base.HomeState")]
        public void OnStateExit()
        {
            Debug.Log("Exit:HomeState");
        }

        #region Methods
        private void InitializeButtons()
        {
            HomeButton.interactable = true;
            State2Button.interactable = true;
            State1Button.interactable = true;
        }
        #endregion
    }
}
