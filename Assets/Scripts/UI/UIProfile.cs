using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProfile : MonoBehaviour
{
    public Slider hpBar;
    public Image imgFill; // �̹��� ü�¹� �÷�

    public TMP_Text txtHp;

    public TMP_Text txtLevel;
    public TMP_Text txtName;
    public TMP_Text txtGold;

    void Start()
    {
        RefreshState();
    }

    public void RefreshState() //�Լ��� �����Ű���� �� ���̴�.
    {
        txtLevel.text = $"Lv.{GameManager.GetInstance().levle}";
        txtName.text = $"{GameManager.GetInstance().playerName}";
        txtGold.text = $"{GameManager.GetInstance().gold}g";
        // GetInstance() �� �����ϱ�

        hpBar.maxValue = GameManager.GetInstance().totalHP; //�̰��� float�̴�. �׷��� value��� int�� ���� ���� �ִ�.
        hpBar.value = GameManager.GetInstance().curHp;
        txtHp.text = $"{hpBar.value} / {hpBar.maxValue}";

    }
}
