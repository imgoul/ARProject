using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Assets.Script.StrangeIoc.controller.AtomsCommands;
using Assets.Script.StrangeIoc.model.Atoms;
using Assets.Script.StrangeIoc.signal.AtomSignals;
using strange.extensions.mediation.impl;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Script.StrangeIoc.view.AtomViews
{
    public class AtomMediator : Mediator {
        [Inject]
        public AtomView AtomView { get; set; }

        [Inject]
        public ReturnFromCommandSignal ReturnSignal { get; set; }

        [Inject]
        public AtomSignal AtomSignal { get; set; }
    
        public override void OnRegister()
        {
            AtomView.signal.AddListener(HandleRequest);
            ReturnSignal.AddListener(HandleResponse);

        }

        public override void OnRemove()
        {
            AtomView.signal.RemoveListener(HandleRequest);
            ReturnSignal.RemoveListener(HandleResponse);
        }

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="msg"></param>
        private void HandleRequest(string requestCode,string requestDate)
        {
            AtomSignal.Dispatch(requestCode+"|"+requestDate);
        }

        /// <summary>
        /// 处理响应
        /// </summary>
        /// <param name="requestCode">根据requestCode转换ResponseData</param>
        /// <param name="responseData">数据库返回的数据</param>
        private void HandleResponse(string requestCode, List<Atom> responseData)
        {
            //Debug.Log("mediator获取到数据库结果");
            if (requestCode == AtomEvent.GetAllAtoms)
            {
                OnGetAllAtom(responseData as List<Atom>);
            }else if (requestCode == AtomEvent.GetAtom)
            {
                OnGetTargetAtom(responseData as List<Atom>);
            }
        }



        private void OnGetAllAtom(List<Atom> atomList)
        {
            AtomView.OnLoadAtoms(atomList);
        }

        
        private void OnGetTargetAtom(List<Atom> atomList)
        {
            if (atomList!=null)
            {
                AtomView.OnAtomBtnClickResponse(atomList.First());
            }
        }
    }
}
