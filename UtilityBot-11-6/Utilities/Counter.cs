using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;
using System.Threading.Tasks;

namespace UtilityBot_11_6.Utilities
{
    public class Counter
    {
        private readonly ITelegramBotClient _telegramClient;

        public Counter(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }

        

        public async Task CountLetters(string text, long chatId, CancellationToken ct)
        {
            int count = text.Length; // или text.Count(char.IsLetter), если только буквы
            await _telegramClient.SendMessage(chatId, $"В вашем сообщении {count} символов", cancellationToken: ct);
        }


        public async Task SumNumbers(string text, long chatId, CancellationToken ct)
        {
            var numbers = text.Split(' ')
                              .Where(x => int.TryParse(x, out _))
                              .Select(int.Parse);

            int sum = numbers.Sum();

            await _telegramClient.SendMessage(chatId, $"Сумма чисел: {sum}", cancellationToken: ct);
        }
    }
}
