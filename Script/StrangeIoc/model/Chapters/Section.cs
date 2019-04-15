namespace Assets.Script.StrangeIoc.model.Chapters
{
    public class Chapter:IChapter
    {
        public int Id { get; set;}
        public string ChapterName { get; set; }
        public int ChapterId { get; set; }

        public Chapter(int id, string chapterName, int chapterId)
        {
            Id = id;
            ChapterName = chapterName;
            ChapterId = chapterId;
        }
    }
}
