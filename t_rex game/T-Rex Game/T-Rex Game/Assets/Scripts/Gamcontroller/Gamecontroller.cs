using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamecontroller : MonoBehaviour
{
    public float spawntime;
    float m_spawntime;
    int score=0;
    [SerializeField] GameObject obstackle;
    bool isgameover;
    UImanager m_ui;
    obstacklemove catus;

    // Start is called before the first frame update
    void Start()
    {
        m_spawntime = 0;
        m_ui = FindObjectOfType<UImanager>();
        m_ui.setScoretext("SCORE :" +score);
    }

    // Update is called once per frame
    void Update()
    {  m_ui.setScoretext("SCORE :" + score);
        if (isgameover)
        {
            m_spawntime = 0;
            m_ui.setgameoverpanel(true);
            return;
        }
        m_spawntime -= Time.deltaTime;
        if (m_spawntime <= 0)
        {
            spawnobstackle();
            m_spawntime = spawntime;
        }
      
        // ScoreIncrement();
    }
    public void replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void spawnobstackle()
    {
        float randypos = Random.Range(-4.5f, -3.5f);
        Vector2 spawnpos = new Vector2(5.2f, randypos);
        if (obstackle)
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
        m_ui.setScoretext("SCORE :" + score);
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
