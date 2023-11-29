using System;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity
{
    interface ICommandDispatcher : IActionRegistration
    {
        CommandDispatchResult DispatchCommand(string command, MonoBehaviour coroutineHost, out Coroutine commandCoroutine);

        void SetupForProject(YarnProject yarnProject);

        IEnumerable<ICommand> Commands { get; }
    }
}
