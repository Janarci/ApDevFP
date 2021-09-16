using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fairyAnim : MonoBehaviour
{
    [SerializeField] private Animation anim;
    private HealthHandler damage;
    private Transform player;
    private bool reachAgent = false;
    private bool isDead = false;
    Transform interactionTransform;
    private NavMeshAgent agent;
    public float attackRadius = 3f;


	private void Awake()
	{
        player = GameObject.Find("Player").GetComponent<Transform>();
        damage = GameObject.Find("HealthManager").GetComponent<HealthHandler>();

    }

    void Start()
    {
        interactionTransform = this.gameObject.transform;
        agent = this.GetComponent<NavMeshAgent>();
        destination();
        this.anim = GetComponent<Animation>();
        anim.Play("Run");
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
        Vector3 TargetVec = player.transform.position;
        agent.SetDestination(TargetVec);
    }

    public bool canInteract(Transform playerPos, Transform objectPos)
    {
        float distance = Vector3.Distance(playerPos.position, objectPos.position);
        if (distance < attackRadius)
        {
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
