using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Script.StrangeIoc.controller.AtomsCommands;
using Assets.Script.StrangeIoc.Dao;
using Assets.Script.StrangeIoc.model.Atoms;
using Assets.Script.StrangeIoc.signal.AtomSignals;
using strange.extensions.signal.impl;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Script.StrangeIoc.service.AtomService
{
    public class AtomService : IAtomService
    {
        [Inject]
        public ReturnFromServiceSignal ReturnFromServiceSignal { get;set; }
        private AtomDao atomDao = new AtomDao();
        public void GetAllAtoms()
        {
            string requestCode = AtomEvent.GetAllAtoms;
            ReturnFromServiceSignal.Dispatch(requestCode,atomDao.SelectAllAtomItem()); 
        }

        public void GetAtomByAtomName(string atomName)
        {
            string requestCode = AtomEvent.GetAtom;
            ReturnFromServiceSignal.Dispatch(requestCode,atomDao.SelectAtomByAtomName(atomName)); 
        }
    }
}
