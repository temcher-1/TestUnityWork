using AxGrid;
using AxGrid.Base;
using AxGrid.Path;
using System.Collections;
using System.IO;
using UnityEngine;

public class DrumMotor_Linear : IDrumMotor
{
    private float _speed;
    private bool _isSpinning;
    public static DrumConfig _config;

    public bool IsSpinning => _isSpinning;

    public DrumMotor_Linear(DrumConfig config)
    {
        _config = config;
    }
    public void StartSpin()
    {    
        _isSpinning = true;
    }
    public void Stop()
    {
        _isSpinning = false;
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public float Tick(float deltaTime)
    {
        float offset = _speed * deltaTime;
        return offset;
    }
}