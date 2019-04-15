using Assets.Demo.Scripts.Dao;
using Assets.Script.StrangeIoc.model.Users;
using Assets.Script.StrangeIoc.Scripts.signal.UserSignal;
using UnityEngine;

namespace Assets.Script.StrangeIoc.Scripts.service.UserServices
{
    public class UserService : IUserService
    {
        [Inject]
        public OnLoginResFromServiceToControllerSignal loginResSignal { get; set; }

        [Inject] 
        public IUser userModel { get; set; }
        private UserDao userDao=new UserDao();
        public void RequestLogin(User user)
        {
            Debug.Log("UserService验证登录获取到登录请求结果，将登录请求结果发送给LoginCommand");
            bool isSuccess = userDao.VertifyUser(user);
            if (isSuccess)
                userModel = user;
            else
            {
                userModel = null;
            }
            loginResSignal.Dispatch(isSuccess==true);
        }

        public void RequestRegister(User user)
        {
        }
    }
}
