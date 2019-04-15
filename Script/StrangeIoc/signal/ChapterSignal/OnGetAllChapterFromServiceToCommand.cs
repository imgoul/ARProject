using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Script.StrangeIoc.model.Chapters;
using strange.extensions.signal.impl;

namespace Assets.Script.StrangeIoc.Scripts.signal.SectionSignal
{
    class OnGetAllChapterFromServiceToCommand:Signal<List<Chapter>>
    {
    }
}
