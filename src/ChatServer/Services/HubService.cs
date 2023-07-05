namespace TSN.ChatServer.Services;

public class HubService
{
    private static readonly string userConnectionMapLocker = string.Empty;
    private static readonly Dictionary<string, Guid> userConnectionMap = new();
    public void KeepUserConnection(string connectionId, Guid userId)
    {
        lock (userConnectionMapLocker)
        {
            userConnectionMap[connectionId] = userId;
        }
    }
    public void RemoveUserConnection(string connectionId)
    {
        //This method will remove the connectionId of user
        lock (userConnectionMapLocker)
        {
            if (userConnectionMap.ContainsKey(connectionId))
            {
                userConnectionMap.Remove(connectionId);
            }
        }
    }
    public Guid? GetUserId(string connectionId)
    {
        lock (userConnectionMapLocker)
        {
            if (userConnectionMap.TryGetValue(connectionId, out var conns))
                return conns;
        }
        return null;
    }
    public string[] GetConnectionId(Guid userId)
    {
        lock (userConnectionMapLocker)
        {
            return userConnectionMap
                .Where(x => x.Value == userId)
                .Select(c => c.Key)
                .ToArray();
        }
    }
}
