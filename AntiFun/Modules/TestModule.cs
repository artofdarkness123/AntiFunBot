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
        [Command("square"), Summary("Squares a Number!")]
        public async Task Square([Summary("The number to square.")] double num)
        {
            await ReplyAsync($"{Math.Pow(num, 2)}");
        }

        [Command("test")]
        public async Task Test()
        {
            
        }
    }
}
