using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fairyAnim : MonoBehaviour
{
    [SerializeField] private Animation anim;
    [SerializeField] private HealthHandler damage;
    [SerializeField] private Transform target;
    [SerializeField] private Transform player;
    private bool reachAgent = false;
    private bool isDead = false;
    Transform interactionTransform;
    private NavMeshAgent agent;
    public float attackRadius = 3f;




    void Start()
    {
        interactionTransform = this.gameObject.transform;
        agent = this.GetComponent<NavMeshAgent>();
        destination();
        this.anim = GetComponent<Animation>();
        anim.Play("Run");
        //StartCoroutine(animCoroutine());
        /*
        foreach (AnimationState state in anim)
        {
            state.speed = 0.0F;
        }*/

    }

	private void Update()
	{
        if (canInteract(player, interactionTransform) && !reachAgent && !isDead)
        {
            reachAgent = true;
            agent.Stop();

            this.anim.Play("Attack1");
            StartCoroutine(attackCycle());
            
            
        }
    }

	private void OnDestroy()
    {
        //EventBroadcaster.Instance.RemoveObserver(EventNames.TapEvents.ON_FAIRY_TAP);
    }

    IEnumerator attackCycle()
    {
        this.anim.PlayQueued("Idle", QueueMode.CompleteOthers);
        // gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        if (!isDead) {
            this.anim.Play("Attack1");
            StartCoroutine(attackCycle());
        }
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
            this.anim.PlayQueued("Idle", QueueMode.CompleteOthers);
            //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            StartCoroutine(animCoroutine());
        }
    }

    public void animDead()
    {
        agent.Stop();
        this.isDead = true;
        this.anim.Play("Death");
        StopAllCoroutines();
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
    public void damagePlayer()
    {
        damage.getHit();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, attackRadius);
    }


}
