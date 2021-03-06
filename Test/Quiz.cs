﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Quiz
    {
        private Otazka[] otazky;

        public Quiz()
        {
            otazky = new Otazka[2];
            Random r = new Random();
            DBOtazek db = new DBOtazek();
            ArrayList vybranaCisla = new ArrayList();

            for(int i =0; i<2; i++)
            {
                int index;
                do
                {
                    index = r.Next(3);
                }
                while (vybranaCisla.Contains(index));
                otazky[i] = (Otazka) db.Otazky[index];
                vybranaCisla.Add(index);
            }


        }
        public void SpustQuiz()
        {
            foreach(Otazka o in otazky)
            {

                string uzivOdpoved;
                int[] poleUzivIndexu;

                o.VypisOtazku();
                do
                {
                    uzivOdpoved = Console.ReadLine();
                } while (!zkontrolujVstup(uzivOdpoved, o, out poleUzivIndexu) );

                o.Odpovedi = new Moznost[poleUzivIndexu.Length];
                for(int i = 0; i< poleUzivIndexu.Length; i++)
                {
                    o.Odpovedi[i] = o.Moznosti[poleUzivIndexu[i] - 1];
                }
            }
            int body = 0;
            foreach(Otazka o in otazky)
            {
               body += o.VyhodnotOtazku();
            }
            Console.WriteLine("Dostali ste {0} bodov", body);
            Console.ReadKey();

        }
        private bool zkontrolujVstup(string uzivVstup,Otazka otazka, out int[] poleIndexu)
        {
            
            int index;
            if(otazka is SingleOtazka)
            {
                bool res = jeCisloAJeVindexu(uzivVstup, otazka,out index);
                poleIndexu = new int[] { index };
                if (!res) Console.WriteLine("zly vstup");
                return res;

            }
            else
            {
               string[] poleOdpovediUziv = uzivVstup.Split(' ');
                poleIndexu = new int[poleOdpovediUziv.Length];
                for (int i=0; i< poleOdpovediUziv.Length; i++ )
                {
                    if (!jeCisloAJeVindexu(poleOdpovediUziv[i], otazka, out index)) return false;
                    poleIndexu[i] = index;
                }
                return true;
            }
        }
        private bool jeCisloAJeVindexu(string uzivatelskeCislo,Otazka otazka, out int index)
        {
            
            bool jeCislo = int.TryParse(uzivatelskeCislo, out index);
            if (!jeCislo)
            {
                Console.WriteLine("zly vstup");
                return false;
            }
            else
            {
                return (index > 0 && index < otazka.Moznosti.Length+1);
            }
        }

    }
}
