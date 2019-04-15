using Assets.Script.StrangeIoc.controller;
using Assets.Script.StrangeIoc.controller.AtomsCommands;
using Assets.Script.StrangeIoc.model.Atoms;
using Assets.Script.StrangeIoc.service.AtomService;
using Assets.Script.StrangeIoc.signal;
using Assets.Script.StrangeIoc.signal.AtomSignals;
using Assets.Script.StrangeIoc.view.AtomViews;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.Script.StrangeIoc.context.Atoms
{
    public class AtomSignalContext : MVCSContext {
        public AtomSignalContext(MonoBehaviour view) : base(view)
        {
        }

    
        //解除默认的EventCommandBinder，重新绑定为SignalCommandBinder
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override IContext Start()
        {
            base.Start();
            StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
            startSignal.Dispatch();
            return this;
        }

        protected override void mapBindings()
        {
            injectionBinder.Bind<IAtom>().To<Atom>().ToSingleton();
            injectionBinder.Bind<IAtomService>().To<AtomService>().ToSingleton();
            mediationBinder.Bind<AtomView>().To<AtomMediator>();

            commandBinder.Bind<StartSignal>().To<StartCommand>();
            commandBinder.Bind<AtomSignal>().To<AtomCommand>();

            injectionBinder.Bind<ReturnFromCommandSignal>().ToSingleton();
            injectionBinder.Bind<ReturnSignal>().ToSingleton();
        }
    }
}
