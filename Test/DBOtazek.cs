using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class DBOtazek
    {
        public DBOtazek()
        {
            SingleOtazka o = new SingleOtazka();
            o.Text = "Kolko je 1+1?";
            o.Moznosti = new Moznost[]
            {
                new Moznost("2", true),
                new Moznost("3", false),
                new Moznost("5",false)

            };
            Otazky.Add(o);

            o = new SingleOtazka();
            o.Text = "Kolko je 2+1?";
            o.Moznosti = new Moznost[]
            {
                new Moznost("2", false),
                new Moznost("3", true),
                new Moznost("5",false)

            };
            Otazky.Add(o);

            MultiOtazka m = new MultiOtazka();
            m.Text = "Ktory z moznosti je operacny system?";
            m.Moznosti = new Moznost[]
            {
                new Moznost("OS X", true),
                new Moznost("OS Z", false),
                new Moznost("Ubuntu",true)

            };
            Otazky.Add(m);

        }
        public ArrayList Otazky = new ArrayList();
        



    }
}
