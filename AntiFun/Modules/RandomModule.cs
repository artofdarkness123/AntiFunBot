using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace AntiFun.Modules
{
    public class RandomModule : ModuleBase<SocketCommandContext>
    {
        [Command("square"), Summary("Squares a Number!")]
        public async Task Square([Summary("The number to square.")] double num)
        {
            var embed = new EmbedBuilder();

            embed.WithTitle("Square");
            embed.WithColor(Color.Green);
            embed.WithDescription($"{Math.Pow(num, 2)}");

            await ReplyAsync("", false, embed);
        }

        [Command("cube"), Summary("Cubes a number!")]
        public async Task Cube([Summary("The number to cube.")] double num)
        {
            var embed = new EmbedBuilder();

            embed.WithTitle("Cube");
            embed.WithColor(Color.Green);
            embed.WithDescription($"{Math.Pow(num, 3)}");

            await ReplyAsync("", false, embed);
        }
    }
}
