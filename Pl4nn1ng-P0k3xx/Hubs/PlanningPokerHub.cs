using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Pl4nn1ng_P0k3xx.Hubs
{
    public class PlanningPokerHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.Caller.SendAsync("Message", "Conexão criada com sucesso!");
        }

        public async Task SubscribeToBoard(Guid boardId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, boardId.ToString());
            await Clients.Caller.SendAsync("Message", "Adicionado a uma sala com sucesso!");
        }

        public async Task RemoveFromBoard(Guid boardId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, boardId.ToString());
            await Clients.Caller.SendAsync("Message", "Removido de uma sala com sucesso!");
        }
    }
}
