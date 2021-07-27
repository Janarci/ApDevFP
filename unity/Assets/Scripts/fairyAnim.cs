using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fairyAnim : MonoBehaviour
{
    public Animation anim;

    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.TapEvents.ON_FAIRY_TAP, this.animDead);
        anim = GetComponent<Animation>();
        StartCoroutine(animCoroutine());
        /*
        foreach (AnimationState state in anim)
        {
            state.speed = 0.0F;
        }*/
        
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.TapEvents.ON_FAIRY_TAP);
    }

    IEnumerator animCoroutine()
    {
        yield return new WaitForSeconds(5);
        anim.Play("Attack1");
        //anim.PlayQueued("Attack2", QueueMode.CompleteOthers);
       // anim.PlayQueued("Attack3", QueueMode.CompleteOthers);
        anim.PlayQueued("Idle", QueueMode.CompleteOthers);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        StartCoroutine(animCoroutine());
    }

    private void animDead()
    {
        anim = GetComponent<Animation>();
        anim.Play("Death");
        Debug.Log("Dead anime played");
    }




}
