using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject castleObject;
    void Start()
    {   
        if (castleObject != null)
        {
            castleObject.SetActive(true);
        }
    }
   
}
