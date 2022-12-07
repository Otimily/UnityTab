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

    public GameObject CreatCharacter()
    {
        Object characterObj = Resources.Load("Sprite/Character");
        GameObject character = (GameObject)Instantiate(characterObj);

        return character;
    }
}
