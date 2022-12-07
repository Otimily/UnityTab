using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour
{
    #region Singletone
    //이것이 싱글톤의 프로포티이다?
    public static UIManager instance = null;

    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@UIManager"); //@를 넣는 이유는 시스템적인 것이라는 표시이다.
            instance = go.AddComponent<UIManager>();
        }

        return instance;
    }

    #endregion

    #region UI Control

    public void SetEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == false)
        {
            GameObject go = new GameObject("@EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }
    }

    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false)
        {
            Object uiObj = Resources.Load("UI/" + uiName);          // 1. 리소스를 로드
            GameObject go = (GameObject)Instantiate(uiObj); // 2. 실제로 생성
            
            uiList.Add(uiName, go);

        }
        else
        {
            uiList[uiName].SetActive(true);
        }
    }

    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
        {
            uiList[uiName].SetActive(false);
        }
    }

    #endregion


}
