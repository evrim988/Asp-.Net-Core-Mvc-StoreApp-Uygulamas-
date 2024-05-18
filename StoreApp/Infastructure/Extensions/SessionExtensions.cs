using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreApp.Infastructure.Extensions;

public static class SessionExtensions
{
    public static void SetSession(this ISession session, string key, string value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static void SetSession<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? GetJson<T>(this ISession session, string key)
    {
        var data = session.GetString(key);
        return data is null
            ? default
            : JsonSerializer.Deserialize<T>(data);
    }
}
