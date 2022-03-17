// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Trucks.Caching;

public static class TruckCacheKey
{
    public const string GetAllCacheKey = "all-Trucks";
    public static string GetPagtionCacheKey(string parameters)
    {
        return $"TrucksWithPaginationQuery,{parameters}";
    }
    static TruckCacheKey()
    {
        SharedExpiryTokenSource = new CancellationTokenSource(new TimeSpan(3, 0, 0));
    }
    public static CancellationTokenSource SharedExpiryTokenSource { get; private set; }
    public static MemoryCacheEntryOptions MemoryCacheEntryOptions => new MemoryCacheEntryOptions().AddExpirationToken(new CancellationChangeToken(SharedExpiryTokenSource.Token));
}

