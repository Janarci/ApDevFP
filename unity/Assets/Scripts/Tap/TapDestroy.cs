using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDestroy : MonoBehaviour
{

    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }

    public void destroyObj()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.TapEvents.ON_FAIRY_TAP);
        StartCoroutine(destroyDelay());
    }
}
