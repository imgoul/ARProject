using System.Collections.Generic;
using Assets.Script.StrangeIoc.model.Atoms;
using Assets.Script.StrangeIoc.signal.AtomSignals;
using strange.extensions.signal.impl;

namespace Assets.Script.StrangeIoc.service.AtomService
{
    public interface IAtomService
    {
        ReturnFromServiceSignal ReturnFromServiceSignal { get;set; }
        void GetAllAtoms();
        void GetAtomByAtomName(string  atomName);
    }
}
