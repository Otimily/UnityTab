using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainScene : MonoBehaviour
{
    void Start()
    {
        ObjectManager.GetInstance().CreatCharacter();

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");
        UIManager.GetInstance().OpenUI("UIActionMenu");

    }

    void Update()
    {
        
    }
}
