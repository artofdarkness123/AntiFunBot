using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace AntiFun.Modules
{
    class AntiSpamModule
    {
        DiscordSocketClient _client;

        static AntiSpamModule()
        {
        }
        
        public Task InitilizeAsync(DiscordSocketClient client)
        {
            _client = client;
            _client.MessageReceived += HandleMessagesAsync;
            return Task.CompletedTask;
        }

        private async Task HandleMessagesAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            //Words to delete.
            List<string> badWords = new List<string>()
            {
            };
            //Servers to ignore.
            List<ulong> ignoreServers = new List<ulong>()
            {
            };

            var context = new SocketCommandContext(_client, msg);
            if (msg == null) return;
            
            //Checks if the server is ignored.
            for (int i = 0; i < ignoreServers.Count; i++)
            {
                if (context.Guild.Id == ignoreServers[i])
                {
                    return;
                }
            }

            //Checks if the message contains a bad word, and if it does it deletes it.
            for (int i = 0; i < badWords.Count; i++)
            {
                //Makes both words uppercase before comparing so you can't bypass through different captialization.
                if (msg.Content.ToUpperInvariant().Contains(badWords[i].ToUpperInvariant()))
                {
                    await msg.DeleteAsync();
                }
            }
        }
    }
}
