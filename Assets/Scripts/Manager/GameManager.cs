using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    #region Singletone
    //이것이 싱글톤의 프로포티이다?
    public static GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager"); //@를 넣는 이유는 시스템적인 것이라는 표시이다.
            instance = go.AddComponent<GameManager>();
        }

        return instance;
    }

    #endregion

    public string playerName = "ho"; // 이름

    public int levle = 99; // 레벨

    public int gold = 1000; // 돈

    public int totalHP = 100; // 최대HP
    public int curHp = 100;

    public void AddGold(int gold) // 골드가 추가 삭제되고, HP가 증가하거나 감소하게 만들것이다.
    {
        this.gold += gold;
    }
    public bool SpenGold(int gold)
    {
        if(this.gold >= gold) // 성공했을 때
        {
            this.gold -= gold;
            return true;
        }

        return false; // 실패했을때는 거짓이 되게 만든다.
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalHP += addHp; // this가 없어도 된다. 
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
        // 0보다는 크고 100보다는 작아지게 해줘라고 주문하는 것이다.
        //Clamp 기능을 좀더 이해해보자. 실무에서는 이렇게 쓴다.
    }
}
