using Assets.Script.StrangeIoc.signal.ChapterSignal;

namespace Assets.Script.StrangeIoc.service.ChapterServices
{
    public interface IChapterService
    {
        ReturnFromServiceSignal ReturnFromServiceSignal { get; set; }
        void GetAllChapters();
    }
}
