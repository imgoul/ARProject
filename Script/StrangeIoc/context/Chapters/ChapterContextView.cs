using strange.extensions.context.impl;

namespace Assets.Script.StrangeIoc.context.Chapters
{
    public class ChapterContextView : ContextView {
        void Awake()
        {
            context=new ChapterSignalsContext(this);
        }
    }
}
