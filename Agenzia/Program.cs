using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Agenzia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Appartamento[] appartamenti = new Appartamento[19];
            Villa[] ville = new Villa[6];
            
            string line;
            StreamReader file=null;
            try
            {

                file = new StreamReader("../../Proprietari2.csv");

                
            }
            catch
            {
                Console.WriteLine("File non trovato!");
            }

            int i = 0;  //indice per array appartamenti
            int j = 0;  //indice per array ville 

            string[] colonne;
            line = file.ReadLine();    //riga di intestazione
            line = file.ReadLine();    //leggo la prima riga di dati
            while (line != null)
            {

                colonne = line.Split(';');
                if (colonne[7] == "")  //se immobile è un appartamento
                {
                    Appartamento a = new Appartamento(Int32.Parse(colonne[0]), colonne[1],
                        colonne[2], Int32.Parse(colonne[3]), Int32.Parse(colonne[4]),
                        false);
                    appartamenti[i] = a;
                    i++;
                }
                else  // se immobile è una villa
                {
                    Villa v = new Villa(Int32.Parse(colonne[0]), colonne[1],
                        colonne[2], Int32.Parse(colonne[3]), Int32.Parse(colonne[4]),
                        false, Int32.Parse(colonne[7]), Int32.Parse(colonne[8]));
                    ville[j] = v;
                    j++;
                }

                line = file.ReadLine();

            }

            file.Close();
            
            string risp;
            int id;
            Console.WriteLine("Scegli l'operazione:");
            Console.WriteLine("1 - Visualizza ");
            Console.WriteLine("2 - Vendi");
            Console.WriteLine("3 - Info Varie");
            risp = Console.ReadLine();
            if (risp == "1")
            {
                Console.WriteLine("Inserisci l'ID del proprietario:");
                risp = Console.ReadLine() ;
                id = Int32.Parse(risp);
                i = 0;
                while(id != appartamenti[i].GetId() & i<appartamenti.Length)
                {
                    i++;
                }
                if (i < appartamenti.Length) // se ho trovato il proprietario tra gli appartamenti
                {
                    Console.WriteLine(appartamenti[i].ToString());
                }
                else
                {
                    i = 0;
                    while (id != ville[i].GetId() & i < ville.Length)
                    {
                        i++;
                    }
                    if (i < ville.Length)
                    {
                        Console.WriteLine(ville[i].ToString());
                    }
                    else
                    {
                        Console.WriteLine("ID NON TROVATO !");
                    }
                }
                
            }
            else if (risp == "2")
            {
                Console.WriteLine("Inserisci l'ID del proprietario:");
                risp = Console.ReadLine();
                id = Int32.Parse(risp);
                i = 0;
                while ( i < appartamenti.Length && id != appartamenti[i].GetId() )
                {
                    i++;
                }
                if (i < appartamenti.Length) // se ho trovato il proprietario tra gli appartamenti
                {
                    appartamenti[i].Vendita();
                    Console.WriteLine("Appartamento venduto ! ");
                }
                else
                {
                    i = 0;
                    while (i < ville.Length && id != ville[i].GetId())
                    {
                        i++;
                    }
                    if (i < ville.Length)
                    {
                        ville[i].Vendita();
                        Console.WriteLine("Villa venduta ! ");
                    }
                    else
                    {
                        Console.WriteLine("ID NON TROVATO !");
                    }
                }

            }
            else if(risp == "3")
            {
                int min;
                int max;
                int immoblile=0;
                Console.Clear();
                Console.WriteLine("1 - Appartamento piu economico");
                Console.WriteLine("2 - Appartamento piu costoso");
                risp = Console.ReadLine();

                if (risp == "1")
                {
                    min= appartamenti[0].CostoImmobile();
                    for(i = 1; i < appartamenti.Length; i++)
                    {
                        if (appartamenti[i].CostoImmobile()< min)
                        {
                            min = appartamenti[i].CostoImmobile();
                            immoblile=i;
                        }
                    }
                    Console.WriteLine("L'appartamento più economico è : ");
                    Console.WriteLine(appartamenti[immoblile].ToString());

                }
                else if (risp == "2")
                {
                    max = appartamenti[0].CostoImmobile();
                    for (i = 1; i < appartamenti.Length; i++)
                    {
                        if (appartamenti[i].CostoImmobile() > max)
                        {
                            max = appartamenti[i].CostoImmobile();
                            immoblile = i;
                        }
                    }
                    Console.WriteLine("L'appartamento più costoso è : ");
                    Console.WriteLine(appartamenti[immoblile].ToString());

                }
            }
                
            

            Console.ReadKey();
        }

    }
}
