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
    //�̰��� �̱����� ������Ƽ�̴�?
    public static ScenesManager instance = null;

    public static ScenesManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ScenesManager"); //@�� �ִ� ������ �ý������� ���̶�� ǥ���̴�.
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
        //�����ϰ� �� ��ũ��Ʈ���� ���� �ٲ��ִ°��� �Է����� �ʾƵ� ���Ŵ��� �ȿ��� ü�������� �־ �ذ��Ѵ�.

        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());
    }

    #endregion


}
