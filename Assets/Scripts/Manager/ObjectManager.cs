using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Singletone
    //이것이 싱글톤의 프로포티이다?
    public static ObjectManager instance = null;

    public static ObjectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ObjectManager"); //@를 넣는 이유는 시스템적인 것이라는 표시이다.
            instance = go.AddComponent<ObjectManager>();
        }

        return instance;
    }

    #endregion

    public GameObject CreatCharacter() // 캐릭터를 생성한다.
    {
        Object characterObj = Resources.Load("Sprite/character");
        GameObject character = (GameObject)Instantiate(characterObj);

        return character;
    }

    public GameObject CreateMonster() // 몬스터를 생성한다.
    {
        Object monsterObj = Resources.Load("Sprite/monster");
        GameObject monster = (GameObject)Instantiate(monsterObj);

        return monster;
    }

    public ParticleSystem CreateHItEffect()
    {
        Object effectObj = Resources.Load("Effect/Destruction_air_purple");
        GameObject effect = (GameObject)Instantiate(effectObj);

        return effect.GetComponent<ParticleSystem>();
    }

}
