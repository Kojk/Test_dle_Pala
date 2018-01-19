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

        public virtual void VypisOtazku()
        {
            Console.WriteLine(Text);
            Console.WriteLine("----------");
            foreach (Moznost m in moznosti)
            {
                Console.WriteLine(m.Text);
            }
        }

        public virtual int VyhodnotOtazku()
        {
            return 0;
        }
    }
    class SingleOtazka: Otazka
    {
        public override int VyhodnotOtazku()
        {
           
            for(int i=0; i<Odpovedi.Length; i++)
            {
                if (this.Odpovedi[i].Spravnost) return 1;
            }

            return 0;
        }
        public override void VypisOtazku()
        {
            Console.WriteLine("Single choice");
            base.VypisOtazku();
        }

    }

    class MultiOtazka: Otazka
    {
        public override int VyhodnotOtazku()
        {
            int body =0;
            for (int i = 0; i < Odpovedi.Length; i++)
            {
                if (this.Odpovedi[i].Spravnost) body++;
                else body--;
            }
            return body;

            
        }
        public override void VypisOtazku()
        {
            Console.WriteLine("Multiple choice");
            base.VypisOtazku();
        }
    }

}
