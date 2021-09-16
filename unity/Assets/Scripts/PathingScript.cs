using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathingScript : MonoBehaviour
{
    public enum pathType {NORMAL = 0, BLOCKED = 1, SHOP = 2, CAMP = 3, MINI = 4, BOSS= 5};

    [SerializeField] private GameObject[] pathList;
    [SerializeField] public pathType[] pathTypeList;
    [SerializeField] private GameObject Player;
    public int currentLocation = 0;
    public bool playerStop = false;

    public float PLAYER_SPEED = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerStop)
        {
            Vector3 playerMovement = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - PLAYER_SPEED * Time.deltaTime);
            Player.transform.position = playerMovement;
        }

        

        /*for (int i = 0; i < pathList.Length; i++)
        {
            if (i < currentLocation - 2 && i > currentLocation + 3)
            {
                pathList[i].SetActive(false);
            }
            
        }*/


    }


}
