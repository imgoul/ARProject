using System.Collections.Generic;
using System.Collections.Specialized;
using Assets.Script.StrangeIoc.model.Chapters;
using Assets.Script.StrangeIoc.service.ChapterServices;
using Assets.Script.StrangeIoc.signal.ChapterSignal;
using Assets.Script.StrangeIoc.Scripts.signal.SectionSignal;
using strange.extensions.command.impl;

namespace Assets.Script.StrangeIoc.controller.ChapterCommands
{
    class ChapterCommand:Command
    {
        [Inject]
        public IChapterService chapterService { get; set; }

        [Inject] 
        public OnGetAllChapterFromCommandToMediator signal { get; set; }
        public override void Execute()
        {
            Retain();
            //Debug.Log("command收到请求");
            (chapterService as ChapterService).signal.AddListener(OnGetAllChapters);
            (chapterService as ChapterService).GetAllSections();

        }

        private void OnGetAllChapters(List<Chapter> chapterList)
        {
            signal.Dispatch(chapterList);
            (chapterService as ChapterService).signal.RemoveListener(OnGetAllChapters);
            Release();
        }
    }
}
