
using Assets.Script.StrangeIoc.model.Users;
using Assets.Script.StrangeIoc.Scripts.signal.UserSignal;

namespace Assets.Script.StrangeIoc.Scripts.service.UserServices
{
    public interface IUserService
    {
        IUser UserModel { get; set; }
        OnLoginResFromServiceToControllerSignal LoginResSignal { get; set; }
        void RequestRegister(User user);
        void RequestLogin(User user);
    }
}
