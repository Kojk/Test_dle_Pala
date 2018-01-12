using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Otazka
    {
        public string Text;
        private Moznost[] moznosti;

        public Moznost[] Moznosti
        {
            get
            {
                return moznosti;
            }
            set
            {
                moznosti = value;
            }
        }
        public Moznost[] Odpovedi;

        public void VypisOtazku()
        {
            Console.WriteLine(Text);
            Console.WriteLine("----------");
            foreach (Moznost m in moznosti)
            {
                Console.WriteLine(m.Text);
            }
        }
    }
    class SingleOtazka: Otazka
    {

    }

    class MultiOtazka: Otazka
    {

    }

}
