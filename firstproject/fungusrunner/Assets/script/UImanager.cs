using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject gameoverpanel;
     [SerializeField] Text scoretxt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setScoretext(string text)
    {
        if (scoretxt)
        { scoretxt.text = text; }

    }
    public void setgameoverpanel(bool isshow)
    {
        if (gameoverpanel)
        { gameoverpanel.SetActive(isshow); }
    }    
}
