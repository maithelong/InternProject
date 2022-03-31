using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class skinmanager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedskin = 0;
    public GameObject playerskin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextoption()
    {
        selectedskin = selectedskin + 1;
        if(selectedskin==skins.Count)
        {
            selectedskin = 0;
        }
        sr.sprite = skins[selectedskin];
    }    
    public void backoption()
    {
        selectedskin = selectedskin - 1;
        if (selectedskin <0)
        {
            selectedskin = skins.Count-1;
        }
        sr.sprite = skins[selectedskin];
    }  
    public void playgame()
    {
      //  PrefabUtility.SaveAsPrefabAsset(playerskin,"Assets/selectedskin.prefab");
        SceneManager.LoadScene("SampleScene");
    }    
}
