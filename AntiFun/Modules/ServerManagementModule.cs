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
    public class ServerManagementModule : ModuleBase<SocketCommandContext>
    {
        [Command("createtextchannel"), Summary("Creates a basic text channel with your given name.")]
        public async Task CreateTextChannel([Remainder] string channelName)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Created Text Channel");
            embed.WithDescription($"Successfully created a channel with the name {Utilities.FormatMessage(channelName)}");

            await ReplyAsync("", false, embed);
            await Context.Guild.CreateTextChannelAsync(channelName);
        }

        [Command("createvoicechannel"), Summary("Creates a basic voice channel with your given name.")]
        public async Task CreateVoiceChannel([Remainder] string channelName)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Created Voice Channel");
            embed.WithDescription($"Successfully created a voice channel with the name {Utilities.FormatMessage(channelName)}");

            await ReplyAsync("", false, embed);
            await Context.Guild.CreateVoiceChannelAsync(channelName);
        }
    }
}
