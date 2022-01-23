using UnityEngine;
// base class for all four behaviours: home, scatter, chase, frightened

[RequireComponent(typeof(Ghost))] // need ghost for ghost behavior
public abstract class GhostBehavior : MonoBehaviour
{
    // holds base functions for behaviors, all overridable
    public Ghost ghost { get; private set; }
    public float duration;

    private void Awake()
    {
        this.ghost = GetComponent<Ghost>();
    }

    public void Enable()
    {
        //  uses the default duration 
        Enable(this.duration);
    }

    public virtual void Enable(float duration)
    {
        // use duration specified, such as when power pellet is eaten
        this.enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration); // disable script after the specified duration
    }

    public virtual void Disable()
    {
        this.enabled = false;

        CancelInvoke();
    }

}
