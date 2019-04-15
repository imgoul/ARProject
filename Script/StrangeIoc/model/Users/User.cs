namespace Assets.Script.StrangeIoc.model.Users
{
    public class User : IUser
    {
        public  string username { get; set; }
        public string password { get; set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

    }


}
