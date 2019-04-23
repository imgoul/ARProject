using System.Collections.Generic;
using Assets.Script.StrangeIoc.controller.ChapterCommands;
using Assets.Script.StrangeIoc.model.Chapters;
using Assets.Script.StrangeIoc.signal.ChapterSignal;
using strange.extensions.mediation.impl;

namespace Assets.Script.StrangeIoc.view.ChapterViews
{
    class ChapterMediator:Mediator
    {
        [Inject] 
        public ChapterView ChaptersView { get; set; }
        [Inject]
        public ChapterSignal Signal { get; set; }
        [Inject]
        public ReturnFromCommandSignal ReturnFromCommandSignal { get; set; }

        public override void OnRegister()
        {
            ChaptersView.signal.AddListener(HandleRequest);
            ReturnFromCommandSignal.AddListener(HandleResponse);
        }

        private void HandleRequest(string requestCode, string requestData)
        {
            Signal.Dispatch(requestCode+"|"+requestCode);
        }


        private void HandleResponse(string requestCode,List<Chapter> responseData)
        {
            if (requestCode == ChapterEvent.GetAllChapters)
            {
                OnGetAllChapters(responseData);
            }
        }
        public override void OnRemove()
        {
            ReturnFromCommandSignal.RemoveListener(HandleResponse);
        }

        private void OnGetAllChapters(List<Chapter> chapterList)
        {
            ChaptersView.OnLoadChapters(chapterList);
        }
    }
}
