using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawntime;
     private float m_spawntime;
    int score;
    bool isGameOverState;
    Uimanager ui;
    // Start is called before the first frame update
    void Start()
    {

        m_spawntime = 0;
        ui = FindObjectOfType<Uimanager>();
        ui.setScoreTXT("Score :" + 0);
    }

    // Update is called once per frame
    void Update()
    { if(isGameOverState)
        {
            ui.setgameoverpanel(true);
            m_spawntime = 0;
            return;
        }    
        
        m_spawntime -= Time.deltaTime;
        if(m_spawntime<=0)
        {
            SpawwnEnemy();
            m_spawntime = spawntime;
        }    
       
    }
    void SpawwnEnemy()
    {
        float randXpos = Random.Range(-10, 10);
        Vector2 spawnPos = new Vector2(randXpos,6);
        if(enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }    
    } 
    public void ScoreIncreament()
    {
        score++;
        ui.setScoreTXT("Score :" + score);
    }    
    public void setScore(int value)
    {
        score = value;
    }    
    public int getScore()
    {
        return score;
    }  
    
   
    public void setIsGameOverState(bool state)
    {
        isGameOverState = state;
    }    
    public bool isgameover()
    {
        return isGameOverState;
    }   
    public void replay()
    {
        SceneManager.LoadScene("SampleScene");
    }    
}
