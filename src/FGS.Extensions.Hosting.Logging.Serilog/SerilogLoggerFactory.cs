// Copyright 2017 Serilog Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using FGS.Extensions.Logging.Serilog;

using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.Debugging;

using ILogger = Serilog.ILogger;

namespace FGS.Extensions.Hosting.Logging.Serilog
{
    /// <summary>
    /// Implements <see cref="ILoggerFactory"/> so that we can inject Serilog Logger.
    /// </summary>
    /// <remarks>Registered with dependency injection as part of using <see cref="SerilogHostBuilderExtensions"/>.</remarks>
    public sealed class SerilogLoggerFactory : ILoggerFactory
    {
        private readonly SerilogLoggerProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLoggerFactory"/> class.
        /// </summary>
        /// <param name="logger">The Serilog logger; if not supplied, the static <see cref="Log"/> will be used.</param>
        /// <param name="dispose">When true, dispose <paramref name="logger"/> when the framework disposes the provider. If the
        /// logger is not specified but <paramref name="dispose"/> is true, the <see cref="Log.CloseAndFlush()"/> method will be
        /// called on the static <see cref="Log"/> class instead.</param>
        internal SerilogLoggerFactory(ILogger logger = null, bool dispose = false)
        {
            _provider = new SerilogLoggerProvider(logger, dispose);
        }

        /// <summary>
        /// Disposes the provider.
        /// </summary>
        public void Dispose()
        {
            _provider.Dispose();
        }

        /// <summary>
        /// Creates a new <see cref="Microsoft.Extensions.Logging.ILogger" /> instance.
        /// </summary>
        /// <param name="categoryName">The category name for messages produced by the logger.</param>
        /// <returns>
        /// The <see cref="Microsoft.Extensions.Logging.ILogger" />.
        /// </returns>
        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return _provider.CreateLogger(categoryName);
        }

        /// <summary>
        /// Adds an <see cref="Microsoft.Extensions.Logging.ILoggerProvider" /> to the logging system.
        /// </summary>
        /// <param name="provider">The <see cref="Microsoft.Extensions.Logging.ILoggerProvider" />.</param>
        public void AddProvider(ILoggerProvider provider)
        {
            SelfLog.WriteLine("Ignoring added logger provider {0}", provider);
        }
    }
}
