using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using UtilityBot_11_6.Services;
using UtilityBot_11_6.Models;

namespace UtilityBot_11_6.Controllers
{
    public class InlineKeyboardController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;
        public InlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;
            var session = _memoryStorage.GetSession(callbackQuery.From.Id);
            session.ChosenOption = callbackQuery.Data;

            if (session.ChosenOption == "option1")
            {
                await _telegramClient.SendMessage(
                chatId: callbackQuery.From.Id,
                text: $"Вы выбрали опцию: Считаем буквы. Напишите что нибудь боту!",
                cancellationToken: ct
            );
            }
            if(session.ChosenOption == "option2")
            {
                await _telegramClient.SendMessage(
                chatId: callbackQuery.From.Id,
                text: $"Вы выбрали опцию: Считаем цифры. Напишите что нибудь боту!",
                cancellationToken: ct
            );
            }



        }




    }


    
}
