public interface IDrumLayout
{
    void UpdateLayout(float offset);
    float GetDistanceToCenter();
    int GetIndexCenterSlot();
    //float GetCellY(int index);
    //float CenterY { get; }
}