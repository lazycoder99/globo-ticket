using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace Payactiv.GatewaySvc.API.Common
{
    public class WebSocketManager
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new();

        public string AddSocket(WebSocket socket)
        {
            var connId = Guid.NewGuid().ToString();
            _sockets.TryAdd(connId, socket);
            return connId;
        }

        public async Task RemoveSocket(string id)
        {
            if (_sockets.TryRemove(id, out var socket))
            {
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by the ConnectionManager", CancellationToken.None);
            }
        }

        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        }

        public IEnumerable<WebSocket> GetAll()
        {
            return _sockets.Values;
        }

        public async Task SendNotificationToClient(string message, string clientId)
        {
            if (_sockets.TryGetValue(clientId, out var socket) || socket?.State == WebSocketState.Open)
            {
                var buffer = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            else
            {
                // Handle case where client is not connected
            }
        }
    }

}
