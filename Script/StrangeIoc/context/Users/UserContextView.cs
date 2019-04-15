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
