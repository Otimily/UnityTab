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
        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());
    }

    #endregion


}
