using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProfile : MonoBehaviour
{
    public Slider hpBar;
    public Image imgFill; // 이미지 체력바 컬러

    public TMP_Text txtHp;

    public TMP_Text txtLevel;
    public TMP_Text txtName;
    public TMP_Text txtGold;

    void Start()
    {
        RefreshState();
    }

    public void RefreshState() //함수를 실행시키도록 할 것이다.
    {
        txtLevel.text = $"Lv.{GameManager.GetInstance().levle}";
        txtName.text = $"{GameManager.GetInstance().playerName}";
        txtGold.text = $"{GameManager.GetInstance().gold}g";
        // GetInstance() 란 무엇일까

        hpBar.maxValue = GameManager.GetInstance().totalHP; //이것은 float이다. 그래서 value대신 int를 넣을 수도 있다.
        hpBar.value = GameManager.GetInstance().curHp;
        txtHp.text = $"{hpBar.value} / {hpBar.maxValue}";

    }
}
