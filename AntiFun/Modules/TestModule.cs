using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;

namespace AntiFun.Modules
{
    public class TestModule : ModuleBase<SocketCommandContext>
    {

        [Command("test")]
        public async Task Test()
        {
            
        }
    }
}
