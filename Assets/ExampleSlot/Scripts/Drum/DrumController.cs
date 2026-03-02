using AxGrid;
using AxGrid.Base;
using AxGrid.Path;
using UnityEngine;

public class DrumController : MonoBehaviourExtBind
{
    private IDrumMotor _motor;
    private IDrumLayout _layout;
    private IDrumView _view;
    public DrumConfig _config;

    private bool _isStopping;

    public void Construct(
        IDrumMotor motor,
        IDrumLayout layout,
        IDrumView view,
        DrumConfig config)
    {
        _motor = motor;
        _layout = layout;
        _view = view;
        _config = config;
    }

    [OnUpdate]
    private void update()
    {
        if (_motor == null || _layout == null)
            return;
        if (!_motor.IsSpinning)
            return;
        float offset = _motor.Tick(Time.deltaTime);
        _layout.UpdateLayout(offset);
    }

    public void StartSpin()
    {
        _isStopping = false;
        _motor.StartSpin();
        AnimateSpeed(_config.accelerationTime, 0f, _config.maxSpeed);
    }

    public void StopSpin()
    {
        _isStopping = true;
        AnimateSpeed(_config.decelerationTime, _config.maxSpeed, 0f);
    }

    public void AnimateSpeed(float lifeTime, float beginning, float ending)
    {
        Path
            .EasingCubicEaseOut(
                lifeTime,
                beginning,
                ending,
                v => _motor.SetSpeed(v)
            )
            .Action(() =>
            {
                if (ending == 0f)
                {
                    StopAction();
                }
            });
    }

    public void StopAction()
    {
        float distance = _layout.GetDistanceToCenter();
        int index = _layout.GetIndexCenterSlot();
        _view.PlayStop(index);
        float previousValue = distance;
        float deltaOffset = 0f;
        Path
            .Wait(_config.waitToCentring)
            .EasingLinear(
                _config.centeringTime,
                distance,
                0f,
                v =>
                {
                    deltaOffset = v - previousValue;
                    _layout.UpdateLayout(deltaOffset);
                    previousValue = v;
                }
            )
            .Action(() =>
            {
                _motor.Stop();
                OnStopCompleted();                
            });
    }

    private void OnStopCompleted()
    {
        Settings.Invoke("StopCompleted");
    }
}