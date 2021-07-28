using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fairyAnim : MonoBehaviour
{
    public Animation anim;
    private bool isDead = false;

    void Start()
    {
        //EventBroadcaster.Instance.AddObserver(EventNames.TapEvents.ON_FAIRY_TAP, this.animDead);
        this.anim = GetComponent<Animation>();
        StartCoroutine(animCoroutine());
        /*
        foreach (AnimationState state in anim)
        {
            state.speed = 0.0F;
        }*/
        
    }

    private void OnDestroy()
    {
        //EventBroadcaster.Instance.RemoveObserver(EventNames.TapEvents.ON_FAIRY_TAP);
    }

    IEnumerator animCoroutine()
    {
        if (!isDead)
        {
            yield return new WaitForSeconds(5);
            this.anim.Play("Attack1");
            //anim.PlayQueued("Attack2", QueueMode.CompleteOthers);
            // anim.PlayQueued("Attack3", QueueMode.CompleteOthers);
            this.anim.PlayQueued("Idle", QueueMode.CompleteOthers);
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            StartCoroutine(animCoroutine());
        }
    }

    public void animDead()
    {
        this.isDead = true;
        this.anim = GetComponent<Animation>();
        this.anim.Play("Death");
        Debug.Log("Dead anime played");
        
    }




}
