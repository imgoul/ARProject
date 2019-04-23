using System.Collections.Generic;
using System.Diagnostics;
using Assets.Script.StrangeIoc.model.Atoms;
using Assets.Script.StrangeIoc.service.AtomService;
using strange.extensions.command.impl;
using UnityEngine;
using Assets.Script.StrangeIoc.signal.AtomSignals;
using Assets.Script.StrangeIoc.tools;
using Debug = UnityEngine.Debug;

namespace Assets.Script.StrangeIoc.controller.AtomsCommands
{
    class AtomCommand :Command
    {
        [Inject]
        public IAtomService AtomService { get; set; }

        [Inject]
        public string RequestStr { get; set; }

        [Inject]
        public ReturnFromCommandSignal ReturnFromCommandSignal { get; set; }


        //请求类型
        private string requestCode = null;
        //请求的数据
        private string requestData = null;


        public override void Execute()
        {
            Retain();
            HandleRequest();
        }

        /// <summary>
        /// 处理来自Mediator的请求
        /// </summary>
        private void HandleRequest()
        {
            Tools.ParseRequestStr(RequestStr,ref requestCode,ref requestData);
            AtomService.ReturnFromServiceSignal.AddListener(HandleResponse);
            if (requestCode == AtomEvent.GetAllAtoms)
            {
                AtomService.GetAllAtoms();
            }
            else if (requestCode == AtomEvent.GetAtom)
            {
                string atomName = requestData;
                AtomService.GetAtomByAtomName(atomName);
            }
        }

        /// <summary>
        /// 处理响应请求
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="responseData"></param>
        private void HandleResponse(string requestCode, List<Atom> responseData)
        {
            AtomService.ReturnFromServiceSignal.RemoveListener(HandleResponse);
            ReturnFromCommandSignal.Dispatch(requestCode,responseData);
            Release();
        }


    }
}
