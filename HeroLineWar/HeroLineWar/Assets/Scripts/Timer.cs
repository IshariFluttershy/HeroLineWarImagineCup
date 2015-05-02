using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    [SerializeField]
    private float duration = 0;
    [SerializeField]
    private bool active = false;
    private bool done = false;

    private float currentTime = 0;

    public bool IsDone() { return done; }
    public float GetDuration() { return duration; }
    public void SetTime(float _time) { if (_time < 0) duration = 0; duration = _time; }
    public void Active(bool _on) { active = _on; }
	
	// Update is called once per frame
	void Update () 
    {
        if (active && !done)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= duration)
                done = true;
        }
	}

    public void Launch()
    {
        active = true;
        done = false;
    }

    public void Restart()
    {
        currentTime = 0.0f;
        active = true;
        done = false;
    }

    public void Reset()
    {
        currentTime = 0.0f;
        active = false;
        done = false;
    }

    public void Pause()
    {
        active = false;
    }
}
