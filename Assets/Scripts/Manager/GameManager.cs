using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    #region Singletone
    //�̰��� �̱����� ������Ƽ�̴�?
    public static GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager"); //@�� �ִ� ������ �ý������� ���̶�� ǥ���̴�.
            instance = go.AddComponent<GameManager>();
        }

        return instance;
    }

    #endregion

    public string playerName = "ho"; // �̸�

    public int levle = 99; // ����

    public int gold = 1000; // ��

    public int totalHP = 100; // �ִ�HP
    public int curHp = 100;

    public void AddGold(int gold) // ��尡 �߰� �����ǰ�, HP�� �����ϰų� �����ϰ� ������̴�.
    {
        this.gold += gold;
    }
    public bool SpenGold(int gold)
    {
        if(this.gold >= gold) // �������� ��
        {
            this.gold -= gold;
            return true;
        }

        return false; // ������������ ������ �ǰ� �����.
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalHP += addHp; // this�� ��� �ȴ�. 
    }

    public void SetCurrentHP(int hp)
    {
        curHp += hp;

        // 100   >  100
        if(curHp > totalHP)
        {
            curHp = totalHP; // cur -> 100
        }

        // -20 < 0
        if (curHp < 0)
        {
            curHp = 0; // cur -> 0
        }

        Mathf.Clamp(curHp, 0, 100);
        // 0���ٴ� ũ�� 100���ٴ� �۾����� ������ �ֹ��ϴ� ���̴�.
        //Clamp ����� ���� �����غ���. �ǹ������� �̷��� ����.
    }
}
