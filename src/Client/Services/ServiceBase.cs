namespace HykeIt.Services;

public class ServiceBase
{
    private readonly HttpClient _client;
    private readonly SiteState _state;

    public ServiceBase(
        HttpClient client,
        SiteState state)
    {
        _client = client;
        _state = state;
    }

    public string CreateApiUrl(
        string serviceName) => CreateApiUrl(serviceName, _state.Alias, ControllerRoutes.ApiRoute);

    public string CreateApiUrl(string serviceName, Alias alias) => CreateApiUrl(serviceName, alias, ControllerRoutes.ApiRoute);

    public string CreateApiUrl(string serviceName, Alias alias, string routeTemplate)
    {
        string url = "/";
        if (routeTemplate == ControllerRoutes.ApiRoute)
        {
            if (alias != null && !string.IsNullOrEmpty(alias.Path))
            {
                url += alias.Path + "/";
            }
        }
        url += $"api/{serviceName}";
        return url;
    }

    public string CreateAuthorizationPolicyUrl(string url, string entityName, int entityId)
    {
        return CreateAuthorizationPolicyUrl(url, new Dictionary<string, int>() { { entityName, entityId } });
    }

    public string CreateAuthorizationPolicyUrl(string url, Dictionary<string, int> authEntityId)
    {
        string qs = "";
        foreach (KeyValuePair<string, int> kvp in authEntityId)
        {
            qs += (qs != "") ? "&" : "";
            qs += "auth" + kvp.Key.ToLower() + "id=" + kvp.Value.ToString();
        }

        if (url.Contains('?'))
        {
            return url + "&" + qs;
        }
        else
        {
            return url + "?" + qs;
        }
    }

    protected void AddRequestHeader(string name, string value)
    {
        RemoveRequestHeader(name);
        _client.DefaultRequestHeaders.Add(name, value);
    }
    protected void RemoveRequestHeader(string name)
    {
        if (_client.DefaultRequestHeaders.Contains(name))
        {
            _client.DefaultRequestHeaders.Remove(name);
        }
    }

    protected async Task GetAsync(string uri)
    {
        var response = await _client.GetAsync(uri);
        CheckResponse(response);
    }

    protected async Task<string> GetStringAsync(string uri)
    {
        try
        {
            return await _client.GetStringAsync(uri);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return default;
    }

    protected async Task<byte[]> GetByteArrayAsync(string uri)
    {
        try
        {
            return await _client.GetByteArrayAsync(uri);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return default;
    }

    protected async Task<T> GetJsonAsync<T>(string uri)
    {
        var response = await _client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None);
        if (CheckResponse(response) && ValidateJsonContent(response.Content))
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }

        return default;
    }

    protected async Task PutAsync(string uri)
    {
        var response = await _client.PutAsync(uri, null);
        CheckResponse(response);
    }

    protected async Task<T> PutJsonAsync<T>(string uri, T value)
    {
        return await PutJsonAsync<T, T>(uri, value);
    }

    protected async Task<TResult> PutJsonAsync<TValue, TResult>(string uri, TValue value)
    {
        var response = await _client.PutAsJsonAsync(uri, value);
        if (CheckResponse(response) && ValidateJsonContent(response.Content))
        {
            var result = await response.Content.ReadFromJsonAsync<TResult>();
            return result;
        }
        return default;
    }

    protected async Task PostAsync(string uri)
    {
        var response = await _client.PostAsync(uri, null);
        CheckResponse(response);
    }

    protected async Task<T> PostJsonAsync<T>(string uri, T value)
    {
        return await PostJsonAsync<T, T>(uri, value);
    }

    protected async Task<TResult> PostJsonAsync<TValue, TResult>(string uri, TValue value)
    {
        var response = await _client.PostAsJsonAsync(uri, value);
        if (CheckResponse(response) && ValidateJsonContent(response.Content))
        {
            var result = await response.Content.ReadFromJsonAsync<TResult>();
            return result;
        }

        return default;
    }

    protected async Task DeleteAsync(string uri)
    {
        var response = await _client.DeleteAsync(uri);
        CheckResponse(response);
    }

    private bool CheckResponse(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode) return true;
        if (response.StatusCode != HttpStatusCode.NoContent && response.StatusCode != HttpStatusCode.NotFound)
        {
            Console.WriteLine($"Request: {response.RequestMessage.RequestUri}");
            Console.WriteLine($"Response status: {response.StatusCode} {response.ReasonPhrase}");
        }

        return false;
    }

    private static bool ValidateJsonContent(HttpContent content)
    {
        var mediaType = content?.Headers.ContentType?.MediaType;
        return mediaType != null && mediaType.Equals("application/json", StringComparison.OrdinalIgnoreCase);
    }
}
