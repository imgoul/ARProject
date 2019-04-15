using System.Collections.Generic;
using Assets.Script.StrangeIoc.model.Chapters;
using Assets.Script.StrangeIoc.signal.ChapterSignal;
using Assets.Script.StrangeIoc.Scripts.signal.SectionSignal;
using strange.extensions.mediation.impl;

namespace Assets.Script.StrangeIoc.view.ChapterViews
{
    class ChapterMediator:Mediator
    {
        [Inject] 
        public ChapterView ChaptersView { get; set; }
        [Inject]
        public GetAllChapterSignal Signal { get; set; }
        [Inject]
        public OnGetAllChapterFromCommandToMediator OnGetChapterSignal { get; set; }

        public override void OnRegister()
        {
            ChaptersView.getAllChaptersSignal.AddListener(GetAllChapters);
            OnGetChapterSignal.AddListener(OnGetAllChapter);
        }

        private void GetAllChapters()
        {
            //UnityEngine.Debug.Log("Mediator收到请求");
            Signal.Dispatch();
        }

        public override void OnRemove()
        {
            Signal.RemoveListener(GetAllChapters);
            OnGetChapterSignal.RemoveListener(OnGetAllChapter);
        }

        private void OnGetAllChapter(List<Chapter> chapterList)
        {
            ChaptersView.OnLoadChapters(chapterList);
            OnGetChapterSignal.RemoveListener(OnGetAllChapter);
        }
    }
}
