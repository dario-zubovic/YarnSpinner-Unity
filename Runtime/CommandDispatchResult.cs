/*
Yarn Spinner is licensed to you under the terms found in the file LICENSE.md.
*/

using System;

#nullable enable

#if USE_UNITASK
    using Cysharp.Threading.Tasks;
    using YarnTask = Cysharp.Threading.Tasks.UniTask;
    using YarnObjectTask = Cysharp.Threading.Tasks.UniTask<UnityEngine.Object?>;
#else
    using YarnTask = System.Threading.Tasks.Task;
    using YarnObjectTask = System.Threading.Tasks.Task<UnityEngine.Object?>;
    using System.Threading.Tasks;
#endif

namespace Yarn.Unity
{
    /// <summary>
    /// Represents the result of attempting to locate and call a command.
    /// </summary>
    /// <seealso cref="DispatchCommandToGameObject(Command, Action)"/>
    /// <seealso cref="DispatchCommandToRegisteredHandlers(Command, Action)"/>
    internal struct CommandDispatchResult
    {

        internal enum StatusType
        {

            Succeeded,

            NoTargetFound,

            TargetMissingComponent,

            InvalidParameterCount,

            /// <summary>
            /// The command could not be found.
            /// </summary>
            CommandUnknown,
        };

        internal StatusType Status;

        internal string? Message;

        internal YarnTask Task;

        public CommandDispatchResult(StatusType status)
        {
            Status = status;
            Task = YarnTask.CompletedTask;;
            Message = null;
        }
        public CommandDispatchResult(StatusType status, YarnTask task)
        {
            Status = status;
            Task = task;
            Message = null;
        }
    }
}
