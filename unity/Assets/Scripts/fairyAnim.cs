using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fairyAnim : MonoBehaviour
{
    [SerializeField] private Animation anim;
    private bool isDead = false;
    [SerializeField] private Transform target;
    [SerializeField] private Transform player;
    Transform interactionTransform;
    private NavMeshAgent agent;
    public float attackRadius = 3f;
    [SerializeField] private HealthHandler damage;




    void Start()
    {
        interactionTransform = this.gameObject.transform;
        agent = this.GetComponent<NavMeshAgent>();
        destination();
        this.anim = GetComponent<Animation>();
        StartCoroutine(animCoroutine());
        /*
        foreach (AnimationState state in anim)
        {
            state.speed = 0.0F;
        }*/
        
    }

	private void Update()
	{
        if (canInteract(player, interactionTransform))
        {
            damage.getHit();
            gameObject.SetActive(false);
        }
    }

	private void OnDestroy()
    {
        //EventBroadcaster.Instance.RemoveObserver(EventNames.TapEvents.ON_FAIRY_TAP);
    }

    IEnumerator animCoroutine()
    {
        if (isDead)
        {
            StopCoroutine(animCoroutine());
        }
        else
        {
            yield return new WaitForSeconds(5);
            this.anim.PlayQueued("Attack1", QueueMode.CompleteOthers);
            //anim.PlayQueued("Attack2", QueueMode.CompleteOthers);
            // anim.PlayQueued("Attack3", QueueMode.CompleteOthers);
            this.anim.PlayQueued("Idle", QueueMode.CompleteOthers);
            //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
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

    private void destination()
    {
        Vector3 TargetVec = target.transform.position;
        agent.SetDestination(TargetVec);
    }

    public bool canInteract(Transform playerPos, Transform objectPos)
    {
        float distance = Vector3.Distance(playerPos.position, objectPos.position);
        if (distance < attackRadius)
        {
            Debug.Log("Can Interact with this object!");
            return true;
        }
        else
            return false;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, attackRadius);
    }


}
