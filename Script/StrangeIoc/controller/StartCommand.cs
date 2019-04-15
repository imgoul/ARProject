using strange.extensions.command.impl;
using Debug = UnityEngine.Debug;

namespace Assets.Script.StrangeIoc.controller
{
    class StartCommand:Command
    {
        public override void Execute()
        {
            Debug.Log("启动框架");
        }
    }
}
