using Assets.Script.StrangeIoc.Scripts.Dao;
using Assets.Script.StrangeIoc.Scripts.signal.SectionSignal;

namespace Assets.Script.StrangeIoc.service.ChapterServices
{
    class ChapterService:IChapterService
    {
        [Inject] 
        public OnGetAllChapterFromServiceToCommand signal { get; set; }
        private ChapterDao chapterDao=new ChapterDao();
        public void GetAllSections()
        {
            signal.Dispatch(chapterDao.SelectAllChapterItem());
        }
    }
}
