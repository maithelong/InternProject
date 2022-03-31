using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
  [SerializeField]  public Text scoretext;
    [SerializeField] public GameObject gameoverpanel;
   public  void settxt(string txt)
    {
      if(scoretext)
        {
            scoretext.text = txt;
        }
        
         }
    public void showgamepanel( bool isshow)
    {
        if(gameoverpanel)
        {
            gameoverpanel.SetActive(isshow);
        }
            
    }
}
