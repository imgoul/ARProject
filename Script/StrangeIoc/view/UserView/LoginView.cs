using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : View
{
    //触发点击事件
    public  Signal loginBtnClickSignal=new Signal();
    public  InputField user;
    public InputField password;
    public Text hintText;
    private bool isShowHintInfo = false;
    private string hintInfo = null;
    public string GetUserInfo()
    {
        string str=user.text + "," + password.text;
        return str;
    }

    public void OnLoginButtonClick()
    {
        Debug.Log("点击登录");
        loginBtnClickSignal.Dispatch();
    }

    void Update()
    {
        if (isShowHintInfo)
        {
            SetHintText(hintInfo);
        }
    }

    private void SetHintText(string hintInfo)
    {
        hintText.text = hintInfo;
    }

    public void OnLoginResponse(string hintInfo)
    {
        isShowHintInfo = true;
        this.hintInfo = hintInfo;
    }
}
