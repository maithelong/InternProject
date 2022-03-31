using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemng : MonoBehaviour
{
    public GameObject activecanva;
    public AudioSource aus;
    public AudioClip gameover;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        if(aus&&gameover)
        {
            aus.PlayOneShot(gameover);
        }    
        activecanva.SetActive(true);
        Time.timeScale = 0;
    }    
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
   public  void loadscene()
    {
        
            SceneManager.LoadScene("Changecharacter");
        //Debug.Log("ban vua bam vao cua hang");
    }
    public void exitgame()
    {
        Application.Quit();
    }    
}
