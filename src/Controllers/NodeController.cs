using ESPresense.Models;
using ESPresense.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESPresense.Controllers;

[Route("api/node")]
[ApiController]
public class NodeController(NodeSettingsStore nodeSettingsStore, State state) : ControllerBase
{
    [HttpGet("{id}/settings")]
    public NodeSettings Get(string id)
    {
        var nodeSettings = nodeSettingsStore.Get(id);
        return nodeSettings ?? new Models.NodeSettings(id);
    }

    [HttpGet("{id}/details")]
    public IList<KeyValuePair<string, string>> Details(string id)
    {
        var details = new List<KeyValuePair<string, string>>();
        if (state.Nodes.TryGetValue(id, out var node))
            details.AddRange(node.GetDetails());
        return details;
    }

    [HttpPut("{id}/settings")]
    public Task Set(string id, [FromBody] Models.NodeSettings ds)
    {
        return nodeSettingsStore.Set(id, ds);
    }

    [HttpPost("{id}/update")]
    public async Task Update(string id)
    {
        await nodeSettingsStore.Update(id);
    }

    [HttpPost("{id}/restart")]
    public async Task Restart(string id)
    {
        await nodeSettingsStore.Restart(id);
    }

    public readonly record struct NodeSettingsDetails(Models.NodeSettings? settings, IList<KeyValuePair<string, string>> details);
}