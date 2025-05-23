﻿namespace PerfumeryStore.Infrastucture
{
    public static class UrlExtnsions
    {
        public static string PathAndQuery(this HttpRequest request) => request.QueryString.HasValue ? $"{request.Path}{request.QueryString}"
            : request.Path.ToString();

    }
}
