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
        [RequireUserPermission(GuildPermission.ManageChannels), RequireBotPermission(GuildPermission.ManageChannels)]
        public async Task CreateTextChannel([Remainder] string channelName = null)
        {
            //TODO: Check perms
            var embed = new EmbedBuilder();
            embed.WithTitle("Created Text Channel");
            embed.WithColor(Color.Green);

            if (string.IsNullOrWhiteSpace(channelName))
            {
                embed.WithDescription($"Please provide a channel name.");
                embed.WithColor(Color.Red);

                await ReplyAsync("", false, embed);
                return;
            }

            embed.WithDescription($"Successfully created a channel with the name {Utilities.FormatMessage(channelName)}");

            await ReplyAsync("", false, embed);
            await Context.Guild.CreateTextChannelAsync(channelName);
        }

        [Command("createvoicechannel"), Summary("Creates a basic voice channel with your given name.")]
        [RequireUserPermission(GuildPermission.ManageChannels), RequireBotPermission(GuildPermission.ManageChannels)]
        public async Task CreateVoiceChannel([Remainder] string channelName = null)
        {
            //TODO: Check perms
            var embed = new EmbedBuilder();
            embed.WithTitle("Created Voice Channel");
            embed.WithColor(Color.Green);

            if (string.IsNullOrWhiteSpace(channelName))
            {
                embed.WithDescription($"Please provide a channel name.");
                embed.WithColor(Color.Red);

                await ReplyAsync("", false, embed);
                return;
            }

            embed.WithDescription($"Successfully created a voice channel with the name {Utilities.FormatMessage(channelName)}");

            await ReplyAsync("", false, embed);
            await Context.Guild.CreateVoiceChannelAsync(channelName);
        }

        [Command("createrole"), Summary("Creates a basic role with your given name")]
        [RequireUserPermission(GuildPermission.ManageChannels), RequireBotPermission(GuildPermission.ManageChannels)]
        public async Task CreateRole([Remainder] string roleName = null)
        {
            //TODO: Check perms
            var embed = new EmbedBuilder();
            embed.WithTitle($"Created Role");
            embed.WithDescription($"Successfully created a role with the name {Utilities.FormatMessage(roleName)}");
            embed.WithColor(Color.Green);

            if (string.IsNullOrWhiteSpace(roleName))
            {
                embed.WithDescription($"Please provide a role name.");
                embed.WithColor(Color.Red);

                await ReplyAsync("", false, embed);
                return;
            }

            await ReplyAsync("", false, embed);
            await Context.Guild.CreateRoleAsync(roleName);
        }
    }
}
