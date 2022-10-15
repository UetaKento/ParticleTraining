using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachineExample
{
    public class HUDPanel : MonoBehaviour
    {
        public Button HomeButton;
        public Button State1Button;
        public Button State2Button;

        public void OnHomeButtonClick()
        {
            StateManager.Instance.ChangeState((ExampleState.HomeState).ToString());
        }

        public void OnState1ButtonClick()
        {
            StateManager.Instance.ChangeState((ExampleState.State1).ToString());
        }

        public void OnState2ButtonClick()
        {
            StateManager.Instance.ChangeState((ExampleState.State2).ToString());
        }
    }
}