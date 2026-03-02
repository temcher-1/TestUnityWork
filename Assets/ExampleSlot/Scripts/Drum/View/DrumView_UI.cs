using UnityEngine;

public class DrumView_UI : IDrumView
{
    private ParticleSystem[] _particles;

    public DrumView_UI(ParticleSystem[] particles)
    {
        this._particles = particles;
    }

    public void PlaySpin() { /* звук, эффекты */ }
    public void PlayStop(int index) { _particles[index].Play(); }
}
