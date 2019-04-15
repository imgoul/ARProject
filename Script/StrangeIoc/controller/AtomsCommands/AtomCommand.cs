using System.Collections.Generic;
using System.Diagnostics;
using Assets.Script.StrangeIoc.model.Atoms;
using Assets.Script.StrangeIoc.service.AtomService;
using strange.extensions.command.impl;
using UnityEngine;
using Assets.Script.StrangeIoc.signal.AtomSignals;
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
        public ReturnFromCommandSignal ReturnSignal { get; set; }


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
            ParseRequestStr();
            (AtomService as AtomService).ReturnSignal.AddListener(HandleResponse);
            if (requestCode == AtomEvent.GetAllAtoms)
            {
                (AtomService as AtomService).GetAllAtoms();
            }
            else if (requestCode == AtomEvent.GetAtom)
            {
                string atomName = requestData;
                (AtomService as AtomService).GetAtomByAtomName(atomName);
            }
        }

        /// <summary>
        /// 处理响应请求
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="responseData"></param>
        private void HandleResponse(string requestCode, List<Atom> responseData)
        {
            Debug.Log("command获取到数据库结果");
            (AtomService as AtomService).ReturnSignal.RemoveListener(HandleResponse);
            ReturnSignal.Dispatch(requestCode,responseData);
        }


        /// <summary>
        /// 解析RequestStr，得到requestCode和requestData
        /// </summary>
        public void ParseRequestStr()
        {
            string[] str = RequestStr.Split('|');
            requestCode = str[0];
            requestData = str[1];
        }


    }
}
