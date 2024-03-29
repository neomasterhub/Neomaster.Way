# Neomaster Way

1. [Research](#research)
2. [Notes](#notes)

## Research <a name="research"></a>

* [*Console*](#console)
* [*Threads*](#threads)
* [*Threads.Sync*](#threads.sync)
* [*Threads.Pool*](#threads.pool)
* [*Tasks*](#tasks)
* [*xUnitTest Tools*](#tests)
* [*WinForms*](#win-forms)  
* [*Redis (StackExchange)*](#redis-se)

### Console <a name="console"></a>
1. [Host][console-1]
2. [Scoped vs transient][console-2]

[console-1]:.Net/Research/Console.Host/Program.cs
[console-2]:.Net/Research/Console.ScopedVsTransient/Program.cs

### Threads <a name="threads"></a>
1. [Creation, Start, Parallel writing][threads-1]
2. [Background][threads-2]
3. [Foreground][threads-3]
4. [Thread info: id, name, culture, is background][threads-4]
5. [`IsAlive` in different thread life states][threads-5]
6. [`Join()`, Sequential writing by joined threads][threads-6]
7. [`Join(timeout)`, Joining a thread after timeout][threads-7]
8. [`Abort()`][threads-8]
9. [`Abort(stateInfo)`, `ThreadAbortException`][threads-9]
10. [`ThreadPriority`][threads-10]
11. [Affinity parameterized][threads-11]
12. [Affinity programmed][threads-12]
13. [`Suspend()`, `Resume()`, Sequential cycles][threads-13]
    - [Tick tock][threads-13.1]

[threads-1]:.Net/Research/Threads/CreationStartParallelWritingUnitDemo.cs
[threads-2]:.Net/Research/Threads.Background/Program.cs
[threads-3]:.Net/Research/Threads.Foreground/Program.cs
[threads-4]:.Net/Research/Threads/InfoUnitDemo.cs
[threads-5]:.Net/Research/Threads/IsAliveUnitDemo.cs
[threads-6]:.Net/Research/Threads/JoinUnitDemo.cs
[threads-7]:.Net/Research/Threads/JoinTimeoutUnitDemo.cs
[threads-8]:.Net/Research/Threads.Abort/Program.cs
[threads-9]:.Net/Research/Threads.AbortArg/Program.cs
[threads-10]:.Net/Research/Threads.Priority/Program.cs
[threads-11]:.Net/Research/Threads.AffinityParameterized
[threads-12]:.Net/Research/Threads.AffinityProgrammed/Program.cs
[threads-13]:.Net/Research/Threads.SuspendResume/Program.cs
[threads-13.1]:.Net/Research/Threads.SuspendResume.TickTock/Program.cs

### Threads.Sync <a name="threads.sync"></a>
1. [`lock`][threads.sync-1]
2. `Monitor`
    - [`Enter()`, `Exit()`, Sequential writing to a single resource][threads.sync-2.1]
    - [`IsEntered()` before/in/after `lock`][threads.sync-2.2]
    - [`Wait(timeout)` with thread state logging][threads.sync-2.3]
    - [`PulseAll()`][threads.sync-2.4]
    - [`Pulse()`, `Wait()`, Tick tock][threads.sync-2.5]
    - [`Pulse()`, `Wait()`, Tick tock with noise][threads.sync-2.6]
3. Method Attributes
    - [`MethodImpl(MethodImplOptions.Synchronized)`][threads.sync-3.1]

[threads.sync-1]:.Net/Research/Threads.Sync/LockUnitDemo.cs
[threads.sync-2.1]:.Net/Research/Threads.Sync/Monitors/EnterExitUnitDemo.cs
[threads.sync-2.2]:.Net/Research/Threads.Sync/Monitors/IsEnteredUnitDemo.cs
[threads.sync-2.3]:.Net/Research/Threads.Sync/Monitors/WaitUnitDemo.cs
[threads.sync-2.4]:.Net/Research/Threads.Sync/Monitors/PulseAllUnitDemo.cs
[threads.sync-2.5]:.Net/Research/Threads.Sync/Monitors/PulseWaitTickTockUnitDemo.cs
[threads.sync-2.6]:.Net/Research/Threads.Sync/Monitors/PulseWaitTickTockWithNoiseUnitDemo.cs
[threads.sync-3.1]:.Net/Research/Threads.Sync/MethodAttributes/SynchronizedUnitDemo.cs

### Threads.Pool <a name="threads.pool"></a>
1. [Background][threads.pool-1]
2. [Try set foreground][threads.pool-2]
3. [`Cancel()`, Cancellation of an infinite asynchronous loop][threads.pool-3]
4. [`CancelAfter(timeout)`, Deferred cancellation of an infinite asynchronous loop][threads.pool-4]
5. [`CancellationToken.None`, Cancel cancellation][threads.pool-5]
6. [Registration of cancel event delegates][threads.pool-6]
7. [`Cancel(true)`, Calling registered delegates before an exception occurs][threads.pool-7]
8. [`Cancel(false)`, Calling registered delegates after an exception occurs][threads.pool-8]
9. [Thread context][threads.pool-9]
10. [Thread context flow][threads.pool-10]

[threads.pool-1]:.Net/Research/Threads.Pool/BackgroundUnitDemo.cs
[threads.pool-2]:.Net/Research/Threads.Pool/TrySetForegroundUnitDemo.cs
[threads.pool-3]:.Net/Research/Threads.Pool/CancelUnitDemo.cs
[threads.pool-4]:.Net/Research/Threads.Pool/CancelAfterUnitDemo.cs
[threads.pool-5]:.Net/Research/Threads.Pool/CancelCancellationUnitDemo.cs
[threads.pool-6]:.Net/Research/Threads.Pool/CancelEventDelegateUnitDemo.cs
[threads.pool-7]:.Net/Research/Threads.Pool/CancelTrueUnitDemo.cs
[threads.pool-8]:.Net/Research/Threads.Pool/CancelFalseUnitDemo.cs
[threads.pool-9]:.Net/Research/Threads.Pool/ThreadContextUnitDemo.cs
[threads.pool-10]:.Net/Research/Threads.Pool/ThreadContextFlowUnitDemo.cs

### Tasks <a name="tasks"></a>
1. [Create][tasks-1]
2. [Executing on a thread pool thread][tasks-2]
3. [`Wait()`][tasks-3]
4. [`Exception`][tasks-4]
5. [Throwing a task exception][tasks-5]
6. [`Handle()`][tasks-6]
7. [`Handle()` throws an aggregate of unhandled exceptions][tasks-7]
8. [`Result`][tasks-8]
9. [`Delay()`][tasks-9]
10. [`async`-`await`][tasks-10]
11. [Parallel tasks][tasks-11]
12. [Parallel voids][tasks-12]
13. [Async task vs async void][tasks-13]
14. [Try-catch with await][tasks-14]
15. [`lock` within task][tasks-15]
16. [`SemaphoreSlim` within task (`lock` with async-await)][tasks-16]

[tasks-1]:.Net/Research/Tasks/TaskCreateUnitDemo.cs
[tasks-2]:.Net/Research/Tasks/TaskExecutingOnThreadPoolThreadUnitDemo.cs
[tasks-3]:.Net/Research/Tasks/TaskWaitUnitDemo.cs
[tasks-4]:.Net/Research/Tasks/TaskExceptionUnitDemo.cs
[tasks-5]:.Net/Research/Tasks/TaskExceptionThrowingUnitDemo.cs
[tasks-6]:.Net/Research/Tasks/TaskExceptionHandleUnitDemo.cs
[tasks-7]:.Net/Research/Tasks/TaskExceptionUnhandledAggregateUnitDemo.cs
[tasks-8]:.Net/Research/Tasks/TaskResultUnitDemo.cs
[tasks-9]:.Net/Research/Tasks/TaskDelayUnitDemo.cs
[tasks-10]:.Net/Research/Tasks/AsyncAwaitUnitDemo.cs
[tasks-11]:.Net/Research/Tasks/AsyncParallelTasksUnitDemo.cs
[tasks-12]:.Net/Research/Tasks/AsyncParallelVoidsUnitDemo.cs
[tasks-13]:.Net/Research/Tasks/AsyncTaskVsVoidExceptionUnitDemo.cs
[tasks-14]:.Net/Research/Tasks/AsyncAwaitInTryCatchUnitDemo.cs
[tasks-15]:.Net/Research/Tasks/AsyncAwaitLockUnitDemo.cs
[tasks-16]:.Net/Research/Tasks/AsyncAwaitSemaphoreSlimUnitDemo.cs

### xUnitTest Tools <a name="tests"></a>
1. [`Assert.Same()`][tests-1]
2. [`Assert.Equal()`][tests-2]
101. [`MockBehavior.Loose` vs `MockBehavior.Strict`][tests-101]
102. [`AutoMock`][tests-102]
201. [`IAsyncLifetime`][tests-201]
202. [`IClassFixture<>`][tests-202]
203. [`Tests : IDisposable`][tests-203]
301. [`It.IsAny()`][tests-301]
302. [`It.IsNotNull()`][tests-302]
303. [`It.Is()`][tests-303]
10001. [Tests class template][tests-10001]

[tests-1]:.Net/Research/XUnitTools/Asserts/SameUnitTests.cs
[tests-2]:.Net/Research/XUnitTools/Asserts/EqualUnitTests.cs
[tests-101]:.Net/Research/XUnitTools/LooseVsStrictUnitTests.cs
[tests-102]:.Net/Research/XUnitTools/AutoMockUnitTests.cs
[tests-201]:.Net/Research/XUnitTools/ActivityTypes/AsyncLifetimeFixture.cs
[tests-202]:.Net/Research/XUnitTools/FixtureUnitTests.cs
[tests-203]:.Net/Research/XUnitTools/DisposableTestingUnitTests.cs
[tests-301]:.Net/Research/XUnitTools/ItMethods/IsAnyUnitTests.cs
[tests-302]:.Net/Research/XUnitTools/ItMethods/IsNotNullUnitTests.cs
[tests-303]:.Net/Research/XUnitTools/ItMethods/IsUnitTests.cs
[tests-10001]:.Net/Research/XUnitTools/UnitTestsTemplate.cs

### WinForms <a name="win-forms"></a>
1. [Host][win-forms-1]
2. [Scoped vs transient][win-forms-2]

![WinForms/Scoped vs transient](Docs/img/demos/WinForms.ScopedVsTransient.png "Scoped vs transient")

[win-forms-1]:.Net/Research/WinForms.Host/Program.cs
[win-forms-2]:.Net/Research/WinForms.ScopedVsTransient/Program.cs

### Redis (StackExchange) <a name="redis-se"></a>
1. [Connection exception][redis-se-1]
2. [Connection instance][redis-se-2]
3. [Set/get value][redis-se-3]
4. [Fire and forget][redis-se-4]

[redis-se-1]:.Net/Research/RedisSE/ConnectionExceptionUnitDemo.cs
[redis-se-2]:.Net/Research/RedisSE/ConnectionInstanceUnitDemo.cs
[redis-se-3]:.Net/Research/RedisSE/SetGetUnitDemo.cs
[redis-se-4]:.Net/Research/RedisSE/FireAndForgetUnitDemo.cs

---

## Notes for Visual Studio <a name="notes"></a>

### Find and Replace

`Ctrl + Shift + F`

File types: `!*\bin\*;!*\obj\*;`

### Configurations

|Configuration|Additional files|
|-|-|
|Debug|`**\*UnitTests.cs`|
|Demo|`**\*UnitDemo.cs`|

> :warning: **If the files were not rendered after opening the project in VS**:  
> try selecting Release and then selecting Demo or Debug again.
