using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinHandler : MonoBehaviour
{
    private int coinTotal = 0;
    [SerializeField] private Text text;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Gold: {coinTotal}";
    }

    public void getCoin()
    {
        coinTotal += Random.Range(2,6) * 10;
    }

    public void getPathCompleteCoin(int value)
    {
        coinTotal += value;
    }

    public int getGoldTotal()
    {
        return coinTotal;
    }

    public void setGoldTotal(int value)
    {
        coinTotal = value;
    }
}
