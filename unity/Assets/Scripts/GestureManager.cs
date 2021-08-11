using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GestureManager : MonoBehaviour
{
    public EventHandler<TapEventArgs> onTap;
    public static GestureManager Instance;
    public TapProperty tapProperty;
    private Touch trackedFinger1;
    private Vector2 startPoint = Vector2.zero;
    private Vector2 endPoint = Vector2.zero;
    private float gestureTime = 0.0f;
    public sfxHandler sfx;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            trackedFinger1 = Input.GetTouch(0);
            if (trackedFinger1.phase == TouchPhase.Began)
            {
                this.gestureTime = 0.0f;
                this.startPoint = trackedFinger1.position;
            }
            else if (trackedFinger1.phase == TouchPhase.Ended)
            {
                this.endPoint = trackedFinger1.position;
                if (gestureTime <= tapProperty.tapTime && Vector2.Distance(startPoint,endPoint) < (Screen.dpi * tapProperty.tapDistance))
                {
                    FireTapEvent(startPoint);
                }
            }
            else
            {
                gestureTime += Time.deltaTime;
            }
        }
    }

    private void FireTapEvent(Vector2 pos)
    {
        Debug.Log("Tap!");
        if (onTap != null)
        {
            GameObject hitObj = null;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                hitObj = hit.collider.gameObject;
            }

            TapEventArgs args = new TapEventArgs(pos, hitObj);
            onTap(this, args);

            if (hitObj != null)
            {
                TapDestroy receive = hitObj.GetComponent<TapDestroy>();
                if(receive != null)
                {
                    sfx.play();
                    receive.destroyObj();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (Input.touchCount > 0)
        {
            Ray r = Camera.main.ScreenPointToRay(trackedFinger1.position);
            Gizmos.DrawIcon(r.GetPoint(10), "tazAmazing");
        }
    }

}
