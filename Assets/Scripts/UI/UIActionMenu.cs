using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionMenu : MonoBehaviour
{
    public Button btnPractice;
    public Button btnHealing;
    public Button btnBattle;

    void Start()
    {
        btnBattle.onClick.AddListener(OnClickBattle); // 전투 버튼을 누르면 배틀 씬으로 넘어간다.
        
    }

    void OnClickBattle()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Battle); // 배틀씬으로 넘어가게 한다.
    }
}
