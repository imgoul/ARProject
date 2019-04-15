using Assets.Script.StrangeIoc.model.Users;

namespace Assets.Script.StrangeIoc.tools
{
    class Tools
    {
        public static User UserInfoStrToUser(string userInfo)
        {
            string[] str = userInfo.Split(',');
            return new User(str[0],str[1]);
        }

    }
}
