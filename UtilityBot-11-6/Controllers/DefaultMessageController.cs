using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBot_11_6.Controllers
{
    public class DefaultMessageController
    {
        public async Task Handle(Telegram.Bot.Types.Message message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Данный вид сообщений не поддерживается ботом");
            
        }
    }
}
