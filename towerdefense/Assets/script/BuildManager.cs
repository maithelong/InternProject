using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    // Start is called before the first frame update
    void Start()
    {
        turretToBuild = standardTurret;
    }
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than on buildManage in scene");
            return;
        }    
        instance = this;
    }
    public  GameObject standardTurret;

    // Update is called once per frame
    private GameObject turretToBuild;
   public  GameObject getTurretToBuild()
    {
        return turretToBuild;
    }    
}
