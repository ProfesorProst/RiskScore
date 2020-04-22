using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace RiskScore.Controller
{
    class TelegramBotControlerSender
    {
       public TelegramBotControlerSender()
        {

        }

        internal void TextMessage(long userId, Message message)
        {
            throw new NotImplementedException();
        }

        internal void CallbackQuery(long userId, string data, Message message)
        {
            throw new NotImplementedException();
        }
    }
}
