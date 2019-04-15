using Assets.Script.StrangeIoc.model.Users;
using Assets.Script.StrangeIoc.Scripts.service.UserServices;
using Assets.Script.StrangeIoc.Scripts.signal.UserSignal;
using Assets.Script.StrangeIoc.tools;
using strange.extensions.command.impl;
using UnityEngine;

namespace Assets.Script.StrangeIoc.controller.UserCommands
{
    public class UserCommand : Command {
        [Inject]//注入userModel，与model层交互
        public IUser  userModel { get; set; }

        [Inject]//注入service，与service交互
        public IUserService userService { get; set; }

    
        [Inject] //接受mediator的数据
        public string  userInfo { get; set; }

        [Inject]
        public OnLoginResFromControllerToMediatorSignal loginResSignal { get; set; }

        public override void Execute()
        {
            Retain();
            Debug.Log("LoginCommand收到请求，调用UserService的RequestLogin方法");
            //向service层发起请求
            (userService as UserService).loginResSignal.AddListener(OnRequestLoginComplete);
            userService.RequestLogin(Tools.UserInfoStrToUser(userInfo));
        }


        private void OnRequestLoginComplete(bool isSuccess)
        {
            Debug.Log("LoginCommand收到登录请求结果，将登录请求结果发送给LoginMediator");
            (userService as UserService).loginResSignal.RemoveListener(OnRequestLoginComplete);
            loginResSignal.Dispatch(isSuccess);
            Release();
        }
        
    }
}
