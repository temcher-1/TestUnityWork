using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

public class SlotBootstrap : MonoBehaviourExtBind
{
    [OnStart]
    private void StartThis()
    {
        Settings.Fsm = new FSM();

        Settings.Fsm.Add(new SlotIdleState());
        Settings.Fsm.Add(new SlotSpinningState());
        Settings.Fsm.Add(new SlotStoppingState());

        Settings.Fsm.Start("IdleState");
    }

    [Bind("OnStartButtonClick")]
    private void PlayButtonClickHandler()
    {
        Settings.Invoke("onStartEvent");
    }

    [Bind("OnStopButtonClick")]
    private void StopButtonClickHandler() 
    {
        Settings.Invoke("onStopEvent");
    }
        
}
