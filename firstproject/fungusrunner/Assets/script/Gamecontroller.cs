using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamecontroller : MonoBehaviour
{
    public float spawntime;
    float m_spawntime;
    int score;
   [SerializeField] GameObject obstackle;
    bool isgameover;
    UImanager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawntime = 0;
        m_ui = FindObjectOfType<UImanager>();
        m_ui.setScoretext("Score :" + score);
    }

    // Update is called once per frame
    void Update()
    {
        if(isgameover)
        {
            m_spawntime = 0;
            m_ui.setgameoverpanel(true);
            return;
        }    
        m_spawntime -= Time.deltaTime;
        if(m_spawntime<=0)
        {
            spawnobstackle();
            m_spawntime = spawntime;
        }    
        
    }
    public void replay()
    {
        SceneManager.LoadScene("GamePlay");
    }    
    public void  spawnobstackle()
    {
        float randypos = Random.Range(-2.2f, -0.5f);
        Vector2 spawnpos = new Vector2(11, randypos);
        if(obstackle)
        {
            Instantiate(obstackle, spawnpos, Quaternion.identity);
        }    
    }
    public void setScore(int value)
    {
        score = value;
    }
    public int getScore()
    {
        return score;
    }
    public void ScoreIncrement()
    {
        if (isgameover)
            return;
        score++;
        m_ui.setScoretext("Score :" + score);
    }
    public bool Isgameover()
    {
        return isgameover;
    }
    public void setIsgameoverState(bool state)
    {
        isgameover = state;
    }
}
