using Assets.Script.StrangeIoc.controller.ChapterCommands;
using Assets.Script.StrangeIoc.signal.ChapterSignal;
using Assets.Script.StrangeIoc.Scripts.Dao;

namespace Assets.Script.StrangeIoc.service.ChapterServices
{
    class ChapterService:IChapterService
    {
        [Inject] 
        public ReturnFromServiceSignal ReturnFromServiceSignal { get; set; }
        private ChapterDao chapterDao=new ChapterDao();
        public void GetAllChapters()
        {
            string requestCode = ChapterEvent.GetAllChapters;
            ReturnFromServiceSignal.Dispatch(requestCode,chapterDao.SelectAllChapterItem());
        }
    }
}
