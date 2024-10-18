using System;

namespace BotClass
{
    internal class Bot
    {
        char symb;
        public char Symb
        {
            get { return symb; }
            set
            {
                try
                {
                    if (value == 'X' || value == 'O')
                        symb = value;
                    else
                        throw new ArgumentException("Wrong argument");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public Bot(char symb)
        {
            Symb = symb;
        }
    }
}
