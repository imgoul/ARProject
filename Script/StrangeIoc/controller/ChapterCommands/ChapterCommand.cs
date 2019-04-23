using System.Collections.Generic;
using System.Collections.Specialized;
using Assets.Script.StrangeIoc.controller.AtomsCommands;
using Assets.Script.StrangeIoc.model.Chapters;
using Assets.Script.StrangeIoc.service.AtomService;
using Assets.Script.StrangeIoc.service.ChapterServices;
using Assets.Script.StrangeIoc.signal.ChapterSignal;
using Assets.Script.StrangeIoc.tools;
using strange.extensions.command.impl;

namespace Assets.Script.StrangeIoc.controller.ChapterCommands
{
    class ChapterCommand:Command
    {
        [Inject]
        public IChapterService ChapterService { get; set; }

        [Inject] 
        public ReturnFromCommandSignal ReturnFromCommandSignal { get; set; }

        [Inject]
        public string RequestStr { get; set; }


        //请求类型
        private string requestCode = null;
        //请求的数据
        private string requestData = null;

        public override void Execute()
        {
            Retain();
            HandleRequest();

        }

        private void HandleRequest()
        {
            Tools.ParseRequestStr(RequestStr,ref requestCode,ref requestData);
            ChapterService.ReturnFromServiceSignal.AddListener(HandleResponse);
            if (requestCode == ChapterEvent.GetAllChapters)
            {
                ChapterService.GetAllChapters();
            }
        }

        private void HandleResponse(string requestCode, List<Chapter> responseData)
        {
            ChapterService.ReturnFromServiceSignal.RemoveListener(HandleResponse);
            ReturnFromCommandSignal.Dispatch(requestCode,responseData);
            Release();
        }

    }
}
