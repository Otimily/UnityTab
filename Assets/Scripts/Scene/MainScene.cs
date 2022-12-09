using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainScene : MonoBehaviour
{
    Animator characterAnimator;

    void Start()
    {
        

        GameObject go = ObjectManager.GetInstance().CreatCharacter();
        go.transform.localScale = new Vector3(2, 2, 2);
        go.transform.localPosition = new Vector3(0, 1.1f, 0);

        characterAnimator = go.GetComponent<Animator>();

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");
        UIManager.GetInstance().OpenUI("UIActionMenu");

        Invoke("PlayAnimation",2);
    }

    void PlayAnimation()
    {

        //characterAnimator.SetTrigger("Attack");
        characterAnimator.SetInteger("Move", 2);
        //characterAnimator.SetBool("Testbool",false);
    }
}
