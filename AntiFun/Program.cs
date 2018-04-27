using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using AntiFun.Modules;

namespace AntiFun
{
    public class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;
        AntiSpamModule _antiSpam;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose,
                MessageCacheSize = 100
            });
            _handler = new CommandHandler();
            _antiSpam = new AntiSpamModule();
            _client.Log += Log;

            if (Config.bot.token == "" || Config.bot.token == null)
            {
                return; //TODO: Implement a feature to let the user set the token and prefix when the bot is started.
            }

            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            await _handler.InitializeAsync(_client);
            await _antiSpam.InitilizeAsync(_client);

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
