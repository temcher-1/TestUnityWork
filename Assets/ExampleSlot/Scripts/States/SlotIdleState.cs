using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using System.Diagnostics;

[State("IdleState")]
public class SlotIdleState : FSMState
{
    [Enter]
    private void EnterThis()
    {
        //включаем Start
        Settings.Model.Set("btnStart", true);
    }

    [Bind("onStartEvent")]
    private void OnSpinningStart()
    {
        Parent.Change("SpinningState");
    }
}
