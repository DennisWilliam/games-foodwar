using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSomeTime
{
    public float currentTime;
    public float timeToWait;
    public bool releaseAction;

    public WaitSomeTime(float currentTime, float timeToWait, bool releaseAction)
    {
        this.currentTime = currentTime;
        this.timeToWait = timeToWait;
        this.releaseAction = releaseAction;
    }

    public bool Wait()
    {
        currentTime += Time.deltaTime;
        if (this.currentTime > this.timeToWait)
        {
          
            this.releaseAction = true;
            this.currentTime = 0;
        }
        return this.releaseAction;
    }

    public bool RedefineTime( float timeToWait, bool releaseAction)
    {
        this.timeToWait = timeToWait;
        this.releaseAction = releaseAction;
        return releaseAction;
    }
}
