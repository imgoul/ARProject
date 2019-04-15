using System.Collections;
using System.Collections.Generic;
using Assets.Script.StrangeIoc.Scripts.signal.UserSignal;
using strange.extensions.mediation.impl;
using UnityEngine;

public class LoginMediator : Mediator {
    [Inject]//与view层交互接口
    public LoginView loginView { get; set; }

    [Inject]//与controller层交互接口
    public LoginSignal LoginSignal { get; set; }

    [Inject]//请求登录响应回调信号
    public OnLoginResFromControllerToMediatorSignal onLoginSignal { get; set; }
    
    /// <summary>
    /// 实例化时调用
    /// </summary>
    public override void OnRegister()
    {
        loginView.loginBtnClickSignal.AddListener(OnLoginBtnClick);
        onLoginSignal.AddListener(OnLoginResponse);
    }

    public override void OnRemove()
    {
        loginView.loginBtnClickSignal.RemoveListener(OnLoginBtnClick);
        onLoginSignal.RemoveListener(OnLoginResponse);
    }

    //登录按钮点击响应事件
    private void OnLoginBtnClick()
    {
        Debug.Log("LoginMediator收到Login请求,将请求转发至LoginCommand");
        LoginSignal.Dispatch(loginView.GetUserInfo());
    }

    private void OnLoginResponse(bool isSuccess)
    {
        Debug.Log("LoginMediator收到登录请求结果，掉用LoginView中的方法，显示登录结果");
        if (isSuccess)
        {
            loginView.OnLoginResponse("登录成功");
        }
        else
        {
            loginView.OnLoginResponse("登录失败");
        }
    }
}
