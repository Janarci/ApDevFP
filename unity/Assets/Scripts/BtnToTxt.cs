using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnToTxt : MonoBehaviour
{
    Text myTxt;
    // Start is called before the first frame update
    void Start()
    {
        myTxt = GameObject.Find("DismissibleText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TLBtn1()
    {
        myTxt.text = "Khalil Jan Davac Arcilla";
    }
    public void TLBtn2()
    {
        myTxt.text = "GDFUNDA";
    }
    public void TLBtn3()
    {
        myTxt.text = "Changing UI";
    }
    public void TLBtn4()
    {
        myTxt.text = "Hello World";
    }
    public void TLBtn5()
    {
        myTxt.text = "Hello Human";
    }
    public void Fairy1()
    {
        myTxt.text = "Fairy one";
    }
    public void Fairy2()
    {
        myTxt.text = "Fairy two";
    }
    public void Fairy3()
    {
        myTxt.text = "Fairy three";
    }

}
