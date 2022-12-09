using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Singletone
    //�̰��� �̱����� ������Ƽ�̴�?
    public static ObjectManager instance = null;

    public static ObjectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ObjectManager"); //@�� �ִ� ������ �ý������� ���̶�� ǥ���̴�.
            instance = go.AddComponent<ObjectManager>();
        }

        return instance;
    }

    #endregion

    public GameObject CreatCharacter() // ĳ���͸� �����Ѵ�.
    {
        Object characterObj = Resources.Load("Sprite/character");
        GameObject character = (GameObject)Instantiate(characterObj);

        return character;
    }

    public GameObject CreateMonster() // ���͸� �����Ѵ�.
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
