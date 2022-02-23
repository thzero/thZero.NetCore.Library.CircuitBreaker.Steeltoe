/* ------------------------------------------------------------------------- *
thZero.NetCore.Library.CircuitBreaker.Steeltoe
Copyright (C) 2016-2022 thZero.com

<development [at] thzero [dot] com>

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 * ------------------------------------------------------------------------- */

using Microsoft.Extensions.Logging;
using Steeltoe.CircuitBreaker;
using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.CircuitBreaker.Hystrix.Strategy.ExecutionHook;
using Steeltoe.CircuitBreaker.Hystrix.Strategy.Options;
using System;
using System.Threading;
using thZero.Instrumentation;

namespace thZero.Services
{
    public abstract class BaseHystrixCommand<TResult> : HystrixCommand<TResult>
    {
        public BaseHystrixCommand(IInstrumentationPacket instrumentation, string group, Func<TResult> run = null, Func<TResult> fallback = null, ILogger logger = null)
            : base(HystrixCommandGroupKeyDefault.AsKey(group), run, fallback, logger)
        {
            Instrumentation = instrumentation;
        }
        public BaseHystrixCommand(IInstrumentationPacket instrumentation, HystrixCommandGroupKeyDefault group, Func<TResult> run = null, Func<TResult> fallback = null, ILogger logger = null)
            : base(group, run, fallback, logger)
        {
            Instrumentation = instrumentation;
        }
        public BaseHystrixCommand(IInstrumentationPacket instrumentation, IHystrixCommandOptions commandOptions, Func<TResult> run = null, Func<TResult> fallback = null, ILogger logger = null)
            : base(commandOptions, run, fallback, logger)
        {
            Instrumentation = instrumentation;
        }
        public BaseHystrixCommand(IInstrumentationPacket instrumentation, string group, IHystrixThreadPoolKey threadPool, Func<TResult> run = null, Func<TResult> fallback = null, ILogger logger = null)
            : base(HystrixCommandGroupKeyDefault.AsKey(group), threadPool, run, fallback, logger)
        {
            Instrumentation = instrumentation;
        }
        public BaseHystrixCommand(IInstrumentationPacket instrumentation, HystrixCommandGroupKeyDefault group, IHystrixThreadPoolKey threadPool, Func<TResult> run = null, Func<TResult> fallback = null, ILogger logger = null)
            : base(group, threadPool, run, fallback, logger)
        {
            Instrumentation = instrumentation;
        }
        public BaseHystrixCommand(IInstrumentationPacket instrumentation, string group, int executionIsolationThreadTimeoutInMilliseconds, Func<TResult> run = null, Func<TResult> fallback = null, ILogger logger = null)
            : base(HystrixCommandGroupKeyDefault.AsKey(group), executionIsolationThreadTimeoutInMilliseconds, run, fallback, logger)
        {
            Instrumentation = instrumentation;
        }
        public BaseHystrixCommand(IInstrumentationPacket instrumentation, HystrixCommandGroupKeyDefault group, int executionIsolationThreadTimeoutInMilliseconds, Func<TResult> run = null, Func<TResult> fallback = null, ILogger logger = null)
            : base(group, executionIsolationThreadTimeoutInMilliseconds, run, fallback, logger)
        {
            Instrumentation = instrumentation;
        }
        public BaseHystrixCommand(IInstrumentationPacket instrumentation, IHystrixCommandGroupKey group, IHystrixCommandKey key, IHystrixThreadPoolKey threadPoolKey, ICircuitBreaker circuitBreaker, IHystrixThreadPool threadPool, IHystrixCommandOptions commandOptionsDefaults, IHystrixThreadPoolOptions threadPoolOptionsDefaults, HystrixCommandMetrics metrics, SemaphoreSlim fallbackSemaphore, SemaphoreSlim executionSemaphore, HystrixOptionsStrategy optionsStrategy, HystrixCommandExecutionHook executionHook, Func<TResult> run, Func<TResult> fallback, ILogger logger = null)
            : base(group, key, threadPoolKey, circuitBreaker, threadPool, commandOptionsDefaults, threadPoolOptionsDefaults, metrics, fallbackSemaphore, executionSemaphore, optionsStrategy, executionHook, run, fallback, logger)
        {
            Instrumentation = instrumentation;
        }

        #region Protected Properties
        protected IInstrumentationPacket Instrumentation { get; set; }
        #endregion
    }
}
