using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;

[State("SpinningState")]
public class SlotSpinningState : FSMState
{
    [Enter]
    private void EnterThis()
    {
        Settings.Model.Set("btnStart", false);
        Settings.Invoke("StartSpinning");
    }

    [Bind("onStopEvent")]
    private void OnStopClick()
    {
        Parent.Change("StoppingState");
    }
}
