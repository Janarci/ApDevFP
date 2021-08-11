using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinHandler : MonoBehaviour
{
    private float coinTotal = 0;
    [SerializeField] private Text text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinTotal.ToString();
    }

    public void getCoin()
    {
        coinTotal += Random.Range(1,6);
    }
}
