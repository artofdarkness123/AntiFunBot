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
    public class UtilityModule : ModuleBase<SocketCommandContext>
    {
        [Command("say"), Alias("echo"), Summary("Echos a message.")]
        public async Task Say([Remainder, Summary("The text to echo")] string echo)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle($"Embed From: {Context.User.Username}");
            embed.WithDescription(echo);
            embed.WithCurrentTimestamp();
            embed.WithColor(Color.Green);

            await ReplyAsync("", false, embed);
        }

        [Command("embed"), Summary("Embed a message with your set title, message, etc")]
        public async Task Echo(string description = null, string title = null, bool timeStamp = false, bool author = false, string footer = null)
        {
            var embed = new EmbedBuilder();

            if (description == null && timeStamp == false && author == false && title == null && footer == null)
            {
                embed.WithTitle("Embed Builder: Parameters Missing!");
                embed.WithDescription("Parameters:   \"description\" \"title\" \"timeStamp: `true/false`\" \"author: `true/false`\" \"footer\"   `(PLEASE PUT A SPACE IN BETWEEN EACH PARAMETER)`");
                embed.WithColor(Color.Red);
                embed.WithCurrentTimestamp();
            }

            if (description != null)
                embed.WithDescription(description);

            if (title != null)
                embed.WithTitle(title);

            if (timeStamp)
                embed.WithCurrentTimestamp();

            if (author)
                embed.WithAuthor(Context.User.Username);

            if (footer != null)
                embed.WithFooter(footer);

            await ReplyAsync("", false, embed);
        }

    }
}
