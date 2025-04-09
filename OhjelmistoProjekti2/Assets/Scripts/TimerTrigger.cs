using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public enum TriggerType { Start, Finish }
    public TriggerType triggerType;
    public TimerManager timerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerType == TriggerType.Start)
            {
                timerManager.StartTimer();
            }
            else if (triggerType == TriggerType.Finish)
            {
                timerManager.StopTimer();
            }
        }
    }
}
