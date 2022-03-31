using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour
{
    public Text txt;
    public GameObject gameoverpanel;
  public void  setScoreTXT(string scoretxt)
    {
        if (txt)
        { txt.text = scoretxt; }
    }    
    public void setgameoverpanel(bool isshow)
    {
        if(gameoverpanel)
        gameoverpanel.SetActive(isshow);

    }    
}
