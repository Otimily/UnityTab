using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleScene : MonoBehaviour
{
    void Start()
    {
        GameObject go = ObjectManager.GetInstance().CreateMonster(); // 몬스터를 가져온다.
        go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        go.transform.localPosition = new Vector3(0, 0.6f, 0);

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile"); //UI를 가져온다.

        BattleManager.GetInstance().BattleStart(new Monster());

    }

}
