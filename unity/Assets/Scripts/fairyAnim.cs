using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fairyAnim : MonoBehaviour
{
    public Animation anim;

    void Start()
    {

        anim = GetComponent<Animation>();
        StartCoroutine(animCoroutine());
        /*
        foreach (AnimationState state in anim)
        {
            state.speed = 0.0F;
        }*/

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





}
