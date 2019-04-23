using Assets.Script.StrangeIoc.controller;
using Assets.Script.StrangeIoc.controller.UserCommands;
using Assets.Script.StrangeIoc.model.Users;
using Assets.Script.StrangeIoc.signal;
using Assets.Script.StrangeIoc.Scripts.service.UserServices;
using Assets.Script.StrangeIoc.Scripts.signal.UserSignal;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.Script.StrangeIoc.context.Users
{
    public class UserSignalsContext : MVCSContext {
        public UserSignalsContext(MonoBehaviour view) : base(view)
        {
        }

    
        //解除默认的EventCommandBinder，重新绑定为SignalCommandBinder
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        protected override void mapBindings()
        {
            injectionBinder.Bind<IUser>().To<User>().ToSingleton();
            injectionBinder.Bind<IUserService>().To<UserService>().ToSingleton();
            

            mediationBinder.Bind<LoginView>().To<LoginMediator>();
            
        
            commandBinder.Bind<LoginSignal>().To<UserCommand>();

            commandBinder.Bind<StartSignal>().To<StartCommand>().Once();


            //将信号绑定，才可以在注入的类中使用
            injectionBinder.Bind<OnLoginResFromServiceToControllerSignal>().ToSingleton();
            injectionBinder.Bind<OnLoginResFromControllerToMediatorSignal>().ToSingleton();
        }

        public override IContext Start()
        {
            base.Start();
            StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
            startSignal.Dispatch();
            return this;
        }
    }
}
