using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
   
    public Color hoverColor;
    private Color startColor;
    public GameObject turret;
    private Renderer rend;
    public Vector3 positionOffset;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor=rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnMouseDown()
    {
        //hàm tạo turret
        if (turret == null)
        {
            Debug.Log("can't build there - TODO: Display on screen.");
            return;
        }
        else
        {
            GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        }
    }
    private void OnMouseEnter()
    {
        //hover vào node node sẽ đổi màu 
        rend.material.color = hoverColor;
       
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
        //hover out vào node sẽ trả lại màu mặc định 
    }
    

}
