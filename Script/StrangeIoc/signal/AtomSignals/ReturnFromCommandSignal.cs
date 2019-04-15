using System.Collections.Generic;
using Assets.Script.StrangeIoc.model.Atoms;
using strange.extensions.signal.impl;

namespace Assets.Script.StrangeIoc.signal.AtomSignals
{
    public class ReturnFromCommandSignal:Signal<string,List<Atom>>
    {
    }
}
