
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotStrava
{
    internal class Telegrambothelper
    {
        private string token;
        Telegram.Bot.TelegramBotClient client; // локальная переменная клиент
        public Telegrambothelper(string token)
        {
            this.token = token;
        }

        internal void GetUpdates()
        {
            client = new Telegram.Bot.TelegramBotClient(token); // создаем объект и передаем токен
            var me = client.GetMeAsync().Result; // получим информацию о телеграм боте
            if (me != null && !string.IsNullOrEmpty(me.Username)) // проверяем что телеграм бот работает
            {
                int offset = 0;
                while (true)
                {
                    try
                    {
                        
                        var updates = client.GetUpdatesAsync(offset).Result; // получаем информацию что нам написали
                       if(updates != null && updates.Count() > 0 ) // проверка что у нас что-то есть
                        {
                            foreach (var update in updates)  // 
                            {
                                proccessUpdate(update); // для каждого апдейта делаеи процесс
                                offset = update.Id + 1;
                            }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); } // конструкция трай кеч для перехвата ексепшина и вывода на консоль.

                    Thread.Sleep(1000);
                }
            }
        }

        private void proccessUpdate(Update update)
        {
            switch (update.Type) // смотрим тип апдейта
            {
                case Telegram.Bot.Types.Enums.UpdateType.Message: // прием только сообщения
                    var text = update.Message.Text;
                    client.SendTextMessageAsync(update.Message.Chat.Id, "получил:" +  text);
                    break;
                default:
                    Console.WriteLine(update.Type + "не обрабатываем");
                    break;
            }
        }
    }
}