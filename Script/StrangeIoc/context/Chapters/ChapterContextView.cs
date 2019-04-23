using Assets.Script.StrangeIoc.context.Chapters;
using strange.extensions.context.impl;

public class ChapterContextView : ContextView {
        void Awake()
        {
            this.context=new ChapterSignalsContext(this);
        }
}

