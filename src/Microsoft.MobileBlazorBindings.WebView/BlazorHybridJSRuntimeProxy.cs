// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.MobileBlazorBindings.WebView
{
    // TODO: Refactor
    internal class BlazorHybridJSRuntimeProxy : IJSRuntime
    {
        private static IJSRuntime _jSRuntime;
        
        public BlazorHybridJSRuntimeProxy()
        {
        }

        public void Initialize(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object[] args)
        {
            return _jSRuntime.InvokeAsync<TValue>(identifier, args);
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
        {
            return _jSRuntime.InvokeAsync<TValue>(identifier, cancellationToken, args);
        }
    }
}
