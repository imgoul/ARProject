
using Assets.Script.StrangeIoc.model.Users;

namespace Assets.Script.StrangeIoc.Scripts.service.UserServices
{
    public interface IUserService
    {
        void RequestRegister(User user);
        void RequestLogin(User user);
    }
}
