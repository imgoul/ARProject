using Assets.Script.StrangeIoc.context.Users;
using strange.extensions.context.impl;

namespace Assets.Script.StrangeIoc.context.Chapters
{
    public class UserContextView : ContextView {
        void Awake()
        {
            context=new UserSignalsContext(this);
        }
    }
}
