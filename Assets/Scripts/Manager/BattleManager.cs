using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone
    //이것이 싱글톤의 프로포티이다?
    public static BattleManager instance = null;

    public static BattleManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@BattleManager"); //@를 넣는 이유는 시스템적인 것이라는 표시이다.
            instance = go.AddComponent<BattleManager>();
        }

        return instance;
    }

    #endregion

    public Monster monsterData;

    GameObject uiTab;

    public void BattleStart(Monster monster)
    {
        monsterData = monster;

        UIManager.GetInstance().OpenUI("UITab");
        //uiTab = UIManager.GetInstance().GetUI("UITab");

        // 이제 특정시간마다 몬스터가 플레이어를 공격하게 할 것이다.
        // coroutine을 사용할 것이다.
        StartCoroutine("BattleProgress");
    }

    // 2~3초 시간을 가지고 몬스터가 플레이어를 공격
    IEnumerator BattleProgress()
    {
        while (GameManager.GetInstance().curHp > 0) // curHP가 0보다 크다면 이기게 할 것이다.
        {
            yield return new WaitForSeconds(monsterData.delay); //시간마다 한다

            int damage = monsterData.atk;
            GameManager.GetInstance().SetCurrentHP(-damage);
            // 몬스터의 atk와 연결해 준 것이다. 그래서 공격으로 인해 체력감소가 일어난다.

            GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
            if (ui != null)
            {
                ui.GetComponent<UIProfile>().RefreshState();
            }

            Debug.Log($"몬스터가 플레이어에게 공격을 했습니다. - 데미지 {damage}    남은 체력 : {GameManager.GetInstance().curHp}");
        }

        Lose();
    }

    public void AttackMonster()
    {
        float randX = Random.Range(-1.5f, 1.5f);
        float randY = Random.Range(-1.5f, 1.5f);

        var particle = ObjectManager.GetInstance().CreateHItEffect();
        particle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        particle.transform.localPosition = new Vector3(0 + randX, 0.7f + randY, -0.5f);

        monsterData.hp--;
        //터치할 때마다 몬스터의 hp를 1씩 줄여준다는 것이다. 너무해..

        if (monsterData.hp <= 0)
        {
            Victory();
        }
    }

    // 게임에서 이겼는지 졌는지
    void Victory()
    {
        Debug.Log("게임에서 승리했습니다! 보상을 가져가세요!.");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterData.gold);

        Invoke("MoveToMain", 2.5f);

    }

    void Lose()
    {
        Debug.Log("게임에서 패배했습니다.");
        UIManager.GetInstance().CloseUI("UITab");

        if (GameManager.GetInstance().SpenGold(500))
        {
            GameManager.GetInstance().SetCurrentHP(80);
        }

        else
        {
            GameManager.GetInstance().SetCurrentHP(10);
        }

        Invoke("MoveToMain", 2.5f);

    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
