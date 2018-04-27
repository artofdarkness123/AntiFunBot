using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace AntiFun
{
    class Utilities
    {
        static Utilities()
        {
        }

        public static string FormatMessage(string message)
        {
            string finalReturn = String.Format($"`{message}`");
            return finalReturn;
        }

        public static EmbedBuilder FormatEmbed(string title = null, string body = null)
        {
            EmbedBuilder embed = new EmbedBuilder();
            embed.WithTitle(title);
            embed.WithDescription(body);

            return embed;
        }
    }
}
