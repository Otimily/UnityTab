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

    public GameObject GetUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
        {
            return uiList[uiName];
            // 잘못적어서 공격 받자마자 uiprofile이 비활성화되었다.흑흑 꼭 잘 적어 넣어주자!
        }

        return null; // 함수가 void상태 아니면 return이 꼭 필요하다. 그리고 안에 데이터르 아직 안넣어서 null
        
    }

    public void ClearList() // 이것을 만든이유는
    {
        uiList.Clear(); // 안에 있는 내용을 다 삭제해 주는 것이다. 언제 호출할 것인가?

    }

    #endregion


}
