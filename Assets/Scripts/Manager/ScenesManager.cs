using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Battle,
    Menu,
    Main
}
public class ScenesManager : MonoBehaviour
{
    #region Singletone
    //이것이 싱글톤의 프로포티이다?
    public static ScenesManager instance = null;

    public static ScenesManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ScenesManager"); //@를 넣는 이유는 시스템적인 것이라는 표시이다.
            instance = go.AddComponent<ScenesManager>();
        }

        return instance;
    }

    #endregion

    #region Scene Control
    public Scene currentScene;

    public void ChangeScene(Scene scene) 
    {
        UIManager.GetInstance().ClearList();
        //복잡하게 각 스크립트마다 씬을 바꿔주는것을 입력하지 않아도 씬매니저 안에서 체인지씬을 넣어서 해결한다.

        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());
    }

    #endregion


}
