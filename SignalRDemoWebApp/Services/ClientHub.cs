using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRDemoWebApp.Services
{
    public class ClientHub:Hub
    {
        public async Task SendNotyf(string username)
        {
            await Clients.All.SendAsync("ReceiveUserInfo", username);
        }

        public async Task CheckOut(string username)
        {
            await Clients.All.SendAsync("CheckOutUser", username);
        }
        //public async Task LoadLog()
        //{
        //    await Clients.All.SendAsync("LoadLog");
        //}
    }
}
