using System.ComponentModel;
using UnityEngine;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using AxGrid;

public class SlotMachineController : MonoBehaviourExtBind
{
    [Header("Links")]
    [SerializeField] private DrumController drum;

    [Header("Cells")]
    [SerializeField] private CellView[] cells;

    [Header("Particles")]
    [SerializeField] private ParticleSystem[] particles;
    
    [Header("Config")]
    [SerializeField] private DrumConfig drumConfig;

    [OnAwake]
    private void Wake()
    {
        var motor = new DrumMotor_Linear(drumConfig);
        var layout = new DrumLayout_Vertical4(cells);
        var view = new DrumView_UI(particles);        

        drum.Construct(motor, layout, view, drumConfig);
    }

    [Bind("StartSpinning")]
    public void Spin()
    {
        drum.StartSpin();
        Path
            .Wait(drumConfig.waitToStop)
            .Action(() => Settings.Model.Set("btnStop", true));
    }
    [Bind("StopSpinning")]
    public void Stop()
    {
        drum.StopSpin();
    }

}