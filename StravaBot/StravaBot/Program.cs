using System;


namespace TelegramBotStrava
{
    class Program
    {
        static void Main(string[] args) 
        {
            try
            {
                Telegrambothelper hlp = new Telegrambothelper(token: "6986884722:AAFxbyUqJdOFWXbUlO3On5AO-82pn-szbrI");
                hlp.GetUpdates(); // update это все что пишут в бота
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); } // конструкция трай кеч для перехвата ексепшина и вывода на консоль.
        }
    }
}
