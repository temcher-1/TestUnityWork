public interface IDrumMotor
{
    void StartSpin();
    void Stop();
    void SetSpeed(float speed);
    float Tick(float deltaTime);
    bool IsSpinning { get; }
}