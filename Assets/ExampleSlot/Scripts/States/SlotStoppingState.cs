using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;

[State("StoppingState")]
public class SlotStoppingState : FSMState
{
    [Enter]
    private void EnterThis()
    {
        Settings.Model.Set("btnStop", false);
        Settings.Invoke("StopSpinning");
    }

    [Bind("StopCompleted")]
    private void OnStoped()
    {
        Parent.Change("IdleState");
    }
}
