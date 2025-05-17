using UnityEngine;
using UnityEngine.Playables;

public class TimelineGameStarter : MonoBehaviour
{
    public PlayableDirector director;
    public float timelineSpeed = 1f;

    private bool isTimelinePlaying = false;

    void Start()
    {
   

        Time.timeScale = 0f; 
        director.playOnAwake = false;
        director.Stop();
        director.time = 0;

        isTimelinePlaying = true;
    }

    void Update()
    {
        if (!isTimelinePlaying) return;

        
        director.time += Time.unscaledDeltaTime * timelineSpeed;

        if (director.time >= director.duration)
        {
            TimelineFinished(); 
            return; 
        }

        director.Evaluate();
    }

    void TimelineFinished()
    {
        isTimelinePlaying = false;
        director.Stop();
        Time.timeScale = 1f; 
   
    }
}
