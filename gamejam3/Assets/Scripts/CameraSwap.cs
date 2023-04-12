using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    
    public GameObject player;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;


    
    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= 14f)
        {
            cam1.SetActive(false);
            cam2.SetActive(true); // Set CAM 2 active
            cam3.SetActive(false);

            if (player.transform.position.y >= 38f)
            {
                cam1.SetActive(false);
                cam2.SetActive(false);
                cam3.SetActive(true); // Set CAM 3 active
            }
        }

        

        else 
        {
            cam1.SetActive(true); // Set CAM 1 active
            cam2.SetActive(false);
            cam3.SetActive(false);
        }
    }
}
