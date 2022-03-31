using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontroller : MonoBehaviour
{
    [SerializeField] public GameObject ball;
    [SerializeField] public float spawntime=5;
    float m_spawmtime;
    int mscore;
    bool isgameover;
    UImanager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawmtime = 5;
        m_ui = FindObjectOfType<UImanager>();
        m_ui.settxt("Score :" + mscore);
    }

    // Update is called once per frame
    void Update()
    {
        m_spawmtime -= Time.deltaTime;
        if(isgameover)
        {
            m_ui.showgamepanel(true);
            m_spawmtime = 0;
            return;
        }    
        if(m_spawmtime<=0)
        {
            spawnball();
            m_spawmtime = spawntime;
        }    
    }
    void spawnball()
    {
        Vector2 spawnpos = new Vector2(Random.Range(-9 , 9), 6);
        if(ball)
        {
            Instantiate(ball, spawnpos, Quaternion.identity);
        }    
    } 
    public void setscore(int value)
    {
        mscore = value;
    }   
    public int getscore()
    {
        return mscore;
    }    
    public void incrementscore()
    {
        mscore++;
        m_ui.settxt("Score :" + mscore);
    }    
    public bool Isgameover()
    {
        return isgameover;
    }  
    public void setgameover(bool state)
    {
        isgameover = state;
    }  
    public void replay()
    {
        mscore = 0;
        isgameover = false;
        m_ui.settxt("Score :" + mscore);

        m_ui.showgamepanel(false);
    }    
}
