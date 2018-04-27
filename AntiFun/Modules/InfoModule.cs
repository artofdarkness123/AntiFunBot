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
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("userinfo"), Summary("Returns info about the current user, or the user parameter, if one is passed")]
        public async Task UserInfo([Summary("The (optional) user to get info for")] SocketGuildUser user = null)
        {
            if (user == null) return;

            var embed = new EmbedBuilder();
            var roles = new List<string>();
            
            foreach (var role in user.Roles)
            {
                roles.Add(role.ToString());
            }

            embed.WithThumbnailUrl(user.GetAvatarUrl());
            embed.WithColor(Color.Green);
            embed.AddInlineField("Name", user.Username + user.Discriminator);
            embed.AddInlineField("User ID", user.Id);
            embed.AddInlineField("Joined Server", $"{user.JoinedAt?.ToString("dd.MM.yyyy HH:mm") ?? "?"}");
            embed.AddInlineField("Joined Discord", user.CreatedAt.UtcDateTime);
            embed.AddInlineField("Status", user.Status);
            embed.AddInlineField("Roles", $"**({roles.Count - 1})** - {string.Join("\n", roles)}");

            await ReplyAsync("", false, embed);
        }

        [Command("serverinfo"), Summary("Gets info about the server.")]
        public async Task ServerInfo()
        {
            var embed = new EmbedBuilder();

            var emojis = new List<string>();

            foreach (var emote in Context.Guild.Emotes)
            {
                emojis.Add(emote.ToString());
            }

            embed.WithColor(Color.Green);
            embed.WithThumbnailUrl(Context.Guild.IconUrl);
            embed.WithTitle("Server Info");
            embed.AddInlineField("ID", Context.Guild.Id);
            embed.AddInlineField("Owner", Context.Guild.Owner);
            embed.AddInlineField("Members", Context.Guild.MemberCount);
            embed.AddInlineField("Text Channels", Context.Guild.TextChannels.Count);
            embed.AddInlineField("Voice Channels", Context.Guild.VoiceChannels.Count);
            embed.AddInlineField("Created At", Context.Guild.CreatedAt.UtcDateTime);
            embed.AddInlineField("Region", Context.Guild.VoiceRegionId);
            embed.AddInlineField("Roles", Context.Guild.Roles.Count);
            embed.AddInlineField("Amount Of Custom Emotes", $"({emojis.Count})");

            await ReplyAsync("", false, embed);
        }

        [Command("ping"), Summary("Gets latency!")]
        public async Task Ping()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Pong");
            embed.WithDescription($"The current latency is " + Context.Client.Latency + "ms.");
            embed.WithColor(Color.Green);
            embed.WithCurrentTimestamp();

            await ReplyAsync("", false, embed);
        }
    }
}
