using System.Collections.Generic;
using Assets.Script.StrangeIoc.model.Chapters;
using strange.extensions.signal.impl;

namespace Assets.Script.StrangeIoc.signal.ChapterSignal
{
    public class ReturnFromServiceSignal:Signal<string,List<Chapter>>
    {
    }
}
