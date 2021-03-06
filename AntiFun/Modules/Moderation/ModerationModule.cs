﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;

namespace AntiFun.Modules
{
    public class ModerationModule : ModuleBase<SocketCommandContext>
    {
        //!kick
        [Command("kick"), Summary("Kick a user from the server."), RequireBotPermission(GuildPermission.KickMembers), RequireUserPermission(GuildPermission.KickMembers)]
        public async Task Kick(SocketGuildUser user = null, [Remainder, Summary("Reason for kicking the user.")] string reason = null)
        {
            //TODO: Try / Catch for when user is kicked.
            var embed = new EmbedBuilder();
            embed.WithTitle("Kick");
            embed.WithCurrentTimestamp();
            embed.WithColor(Color.Red);

            if (user == null)
            {gtrtyygt
                embed.WithTitle("Kick");
                embed.WithDescription("You didn't supply a user to kick!");
                await ReplyAsync("", false, embed);
                return;
            }

            if (Context.User == user)
            {
                embed.WithTitle("Kick");
                embed.WithDescription("You cant kick yourself!");
                await ReplyAsync("", false, embed);
                return;
            }

            if (!string.IsNullOrWhiteSpace(reason))
            {
                embed.WithColor(Color.Green);
                embed.WithDescription($"{user.Mention} has been kicked from the server for {Utilities.FormatMessage(reason)}");
                await ReplyAsync("", false, embed);
            }
            else
            {
                embed.WithColor(Color.Green);
                embed.WithDescription($"{user.Mention} has been kicked from the server.");
                await ReplyAsync("", false, embed);
            }

            await user.KickAsync(reason);
        }

        //!ban
        [Command("ban"), Summary("Ban a user from the server."), RequireBotPermission(GuildPermission.BanMembers), RequireUserPermission(GuildPermission.KickMembers)]
        public async Task Ban(IUser user = null, [Remainder] string reason = null)
        {
            //TODO: Try / Catch for when user is banned.
            //TODO: Implement a time'd ban system.
            var embed = new EmbedBuilder();
            embed.WithTitle("Ban");
            embed.WithCurrentTimestamp();
            embed.WithColor(Color.Red);

            if (user == null)
            {
                embed.WithDescription("You didnt supply a user to ban!");
                await ReplyAsync("", false, embed);
            }

            if (Context.User == user)
            {
                embed.WithTitle("Ban");
                embed.WithDescription("You cant ban yourself!");
                await ReplyAsync("", false, embed);
                return;
            }

            if (!string.IsNullOrWhiteSpace(reason))
            {
                embed.WithDescription($"{user.Mention} has been banned from the server for {Utilities.FormatMessage(reason)}");
                embed.WithColor(Color.Green);
                await ReplyAsync("", false, embed);
            }
            else
            {
                embed.WithDescription($"{user.Mention} has been banned from the server.");
                embed.WithColor(Color.Green);
                await ReplyAsync("", false, embed);
            }

            await Context.Guild.AddBanAsync(user, 0, reason);
        }

        //TODO: Make this work.
        [Command("unban"), Summary("Unbans a user from the channel."), RequireBotPermission(GuildPermission.BanMembers), RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Unban(IUser user)
        {
            await Context.Guild.RemoveBanAsync(user);
        }

        [Command("clear"), Summary("Clear messages from the channel."), RequireBotPermission(GuildPermission.ManageMessages), RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Clear(int amount = 0)
        {
            //TODO: Try / Catch for when channel is empty etc..
            var embed = new EmbedBuilder();
            embed.WithTitle("Clear");
            embed.WithCurrentTimestamp();
            embed.WithColor(Color.Red);

            if (amount == 0)
            {
                embed.WithDescription("You didnt supply a number of messages to be cleared!");
                await ReplyAsync("", false, embed);
                return;
            }

            var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();

            if (amount == 1)
            {
                embed.WithDescription($"{amount} message has been cleared.");
                embed.WithColor(Color.Green);
            }
            else
            {
                embed.WithDescription($"{amount} messages have been cleared.");
                embed.WithColor(Color.Green);
            }

            await Context.Channel.DeleteMessagesAsync(messages);
            await ReplyAsync("", false, embed);
        }


    }
}
