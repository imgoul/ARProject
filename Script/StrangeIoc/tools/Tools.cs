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
        public static void ParseRequestStr(string requestStr,ref string requestCode,ref string requestData)
        {
            string[] str = requestStr.Split('|');
            requestCode = str[0];
            requestData = str[1];
        }

    }
}
