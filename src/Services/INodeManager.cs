using ESPresense.Models;

namespace ESPresense.Services
{
    public interface INodeManager
    {
        IEnumerable<Node> Nodes { get; }
    }
}
