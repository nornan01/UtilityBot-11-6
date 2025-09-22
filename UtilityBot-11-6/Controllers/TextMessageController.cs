using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using UtilityBot_11_6.Services;
using UtilityBot_11_6.Models;
using UtilityBot_11_6.Utilities;

namespace UtilityBot_11_6.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _memoryStorage;
        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            var session = _memoryStorage.GetSession(message.Chat.Id);
            string option = session.ChosenOption;

            

            if (message.Text == "/start")
            {
                var buttons = new List<InlineKeyboardButton[]>();
                buttons.Add(new[]
                {
                    InlineKeyboardButton.WithCallbackData("Считаем буквы", "option1"),
                    InlineKeyboardButton.WithCallbackData("Считаем цифры", "option2"),
                });
                await _telegramClient.SendMessage(
                    message.Chat.Id,
                    $"Привет, {message.Chat.FirstName}! Я - бот, который может помочь посчитать буквы или сумму цифр в твоем сообщении. Пожалуйста, выбери опцию ниже:",
                    cancellationToken: ct,
                    parseMode: ParseMode.Html,
                    replyMarkup: new InlineKeyboardMarkup(buttons));
                return;

            }
            else
            {

                var counter = new Counter(_telegramClient);

                if (option == "option1")
                {
                    await counter.CountLetters(message.Text, message.Chat.Id, ct);
                }
                else if (option == "option2")
                {
                    await counter.SumNumbers(message.Text, message.Chat.Id, ct);
                }
            }
        }

    }
    }

