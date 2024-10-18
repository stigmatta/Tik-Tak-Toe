using System;

namespace PlayerClass
{
    internal class Player
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
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public Player(char symb)
        {
            Symb = symb;
        }
    }
}
