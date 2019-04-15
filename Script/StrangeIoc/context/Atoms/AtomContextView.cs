using strange.extensions.context.impl;

namespace Assets.Script.StrangeIoc.context.Atoms
{
    public class AtomContextView : ContextView {
        void Awake()
        {
            this.context=new AtomSignalContext(this);
        }
    }
}
