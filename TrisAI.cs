using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tris_AI
{
    class Program
    {
        public static int vittorie = 0,vittorie_bot=0;
        public static int[,] Campo = new int[3, 3];

        static void Main(string[] args)
        {
            Console.Title = "TRIS";
            Console.SetWindowSize(16, 8);
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Campo[i, j] = 0;
                }
            }
            bool fine = true;
            stampa();
            while (true)
            {
                
                Mossa();               
                stampa();
                fine = true;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[i, j] == 0) fine = false;
                    }
                }
                if (fine)
                {
                    Console.ReadKey();
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Campo[i, j] = 0;
                            stampa();
                        }
                    }
                }
                AI();
                stampa();
                fine = true;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[i, j] == 0) fine = false;
                    }
                }
                if (fine)
                {
                    Console.ReadKey();
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Campo[i, j] = 0;
                            stampa();
                        }
                    }
                }

            }
            

        }

        public static void Mossa()
        {
            Console.WriteLine();
            int x=-1, y=-1;
            while ((x < 0 || y < 0) || Campo[x,y] != 0)
            {
                stampa();
                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                
            }
            Campo[x, y] = 1;
            stampa();
            return;
        }        




        public static void AI()
        {
            bool punto_verticale=false, punto_orizzontale=false, punto_diagonale_principale=false,punto_diagonale_secondaria=false;
            bool segna_verticale = false, segna_orizzontale = false, segna_diagonale_principale= false, segna_diagonale_secondaria = false;
            bool verticale = false, orizzontale = false, diagonale_principale = false, diagonale_secondaria = false;


            //RICERCA VERTICALE
            int conta = 0;
            int indice = -1;

            for(int i = 0; i < 3; i++)
            {
                conta = 0;
                for(int j = 0; j < 3; j++)
                {
                    if (Campo[j,i] == 1)
                    {
                        conta++;
                    }
                    if (Campo[j, i] == 2)
                    {
                        conta--;
                    }
                }
                if (conta == 2) punto_verticale = true;
                if (conta == -2) segna_verticale = true;
                if (conta == -1) verticale = true;
            }
           


            //RICERCA ORIZZONTALE
            indice = -1;
            for (int i = 0; i < 3; i++)
            {
                conta = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (Campo[i,j] == 1)
                    {
                        conta++;
                    }
                    if (Campo[i,j] == 2)
                    {
                        conta--;
                    }
                }
                if (conta == 2) punto_orizzontale = true;
                if (conta == -2) segna_orizzontale = true;
                if (conta == -1) orizzontale = true;
            }


            //RICERCA DIAGONALE PRINCIPALE
            indice = -1;
            conta = 0;
            for (int i = 0; i < 3; i++)
            {                
                    if (Campo[i, i] == 1)
                    {
                        conta++;
                    }
                    if (Campo[i, i] == 2)
                    {
                        conta--;
                    }         
               
            }
            if(conta == 2) punto_diagonale_principale = true;
            if (conta == -2) segna_diagonale_principale = true;
            if (conta == -1) diagonale_principale = true;

            //RICERCA DIAGONALE SECONDARIA
            indice = -1;
            conta = 0;
            for(int j = 0; j < 3; j++)
            {
                    if (Campo[j, 2-j] == 1)
                    {
                        conta++;
                    }
                    if (Campo[j, 2 - j] == 2)
                    {
                        conta--;
                    }
                
            }
            if (conta == 2) punto_diagonale_secondaria = true;
            if (conta == -2) segna_diagonale_secondaria = true;
            if (conta == -1) diagonale_secondaria = true;

            if (segna_verticale)
            {
                indice = -1;
                for (int i = 0; i < 3; i++)
                {
                    conta = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[j, i] == 1)
                        {
                            conta++;
                        }
                        if (Campo[j, i] == 2)
                        {
                            conta--;
                        }
                    }
                    if (conta == -2) indice = i;
                }

                if (indice != -1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Campo[i, indice] != 2)
                        {
                            Campo[i, indice] = 2;
                            return;
                        }
                    }
                }
            }
            if (segna_orizzontale)
            {
                indice = -1;
                for (int i = 0; i < 3; i++)
                {
                    conta = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[i, j] == 1)
                        {
                            conta++;
                        }
                        if (Campo[i, j] == 2)
                        {
                            conta--;
                        }
                    }
                    if (conta == -2) indice = i;
                }

                if (indice != -1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Campo[indice, i] != 2)
                        {
                            Campo[indice, i] = 2;
                            return;
                        }

                    }
                }

            }
            if (segna_diagonale_principale)
            {

                indice = -1;
                conta = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (Campo[i, i] == 1)
                    {
                        conta++;
                    }
                    if (Campo[i, i] == 2)
                    {
                        conta--;
                    }

                }
                if (conta == -2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Campo[i, i] != 2)
                        {
                            Campo[i, i] = 2;
                            return;
                        }

                    }
                }
            }
            if (segna_diagonale_secondaria)
            {
                indice = -1;
                conta = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (Campo[j, 2 - j] == 1)
                    {
                        conta++;
                    }
                    if (Campo[j, 2 - j] == 2)
                    {
                        conta--;
                    }

                }


                if (conta == -2)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        if (Campo[j, 2 - j] != 2)
                        {
                            Campo[j, 2 - j] = 2;
                            return;
                        }

                    }
                }
            }


            if (!punto_orizzontale && !punto_verticale && !punto_diagonale_principale && !punto_diagonale_secondaria)
            {
                if (verticale)
                {
                    bool nemica = false;
                    indice = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        conta = 0;
                        nemica = false;
                        for (int j = 0; j < 3; j++)
                        {
                            
                            if (Campo[j, i] == 1)
                            {
                                conta++;
                                nemica = true;
                            }
                            if (Campo[j, i] == 2)
                            {
                                conta--;
                            }
                        }
                        if (conta == -1 && !nemica) indice = i;
                    }

                    if (indice != -1 && !nemica)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[i, indice] != 2)
                            {
                                Campo[i, indice] = 2;
                                return;
                            }
                        }
                    }
                }
                if (orizzontale)
                {
                    bool nemica = false;
                    indice = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        nemica = false;
                        conta = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (Campo[i, j] == 1)
                            {
                                conta++;
                                nemica = true;
                            }
                            if (Campo[i, j] == 2)
                            {
                                conta--;
                            }
                        }
                        if (conta == -1 && !nemica) indice = i;
                    }

                    if (indice != -1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[indice, i] != 2)
                            {
                                Campo[indice, i] = 2;
                                return;
                            }

                        }
                    }
                }
                if (diagonale_principale)
                {
                    bool nemica = false;
                    indice = -1;
                    conta = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        
                        if (Campo[i, i] == 1)
                        {
                            conta++;
                            nemica = true;
                        }
                        if (Campo[i, i] == 2)
                        {
                            conta--;
                        }

                    }
                    if (conta == -1 && !nemica)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[i, i] != 2)
                            {
                                Campo[i, i] = 2;
                                return;
                            }

                        }
                    }
                }
                if (diagonale_secondaria)
                {
                    bool nemica = false;
                    indice = -1;
                    conta = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[j, 2 - j] == 1)
                        {
                            conta++;
                            nemica = true;
                        }
                        if (Campo[j, 2 - j] == 2)
                        {
                            conta--;
                        }

                    }


                    if (conta == -1 && !nemica)
                    {
                        for (int j = 0; j < 3; j++)
                        {

                            if (Campo[j, 2 - j] != 2)
                            {
                                Campo[j, 2 - j] = 2;
                                return;
                            }

                        }
                    }
                }

                if(Campo[1,1]==0) Campo[1,1] = 2;
                else
                {
                    Random rnd = new Random();
                    int x = -1, y = -1;

                    while (x < 0 || y < 0 || Campo[x, y] != 0)
                    {
                        x = rnd.Next(0, 3);
                        y = rnd.Next(0, 3);
                    }

                    Campo[x, y] = 2;

                }

            }
            else
            {
                if (punto_verticale)
                {
                    indice = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        conta = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (Campo[j, i] == 1)
                            {
                                conta++;
                            }
                            if (Campo[j, i] == 2)
                            {
                                conta--;
                            }
                        }
                        if (conta == 2) indice = i;
                    }

                    if (indice != -1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[i, indice] != 1)
                            {
                                Campo[i, indice] = 2;
                                return;
                            }
                        }
                    }
                    
                }

                if (punto_orizzontale)
                {
                    indice = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        conta = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (Campo[i, j] == 1)
                            {
                                conta++;
                            }
                            if (Campo[i, j] == 2)
                            {
                                conta--;
                            }
                        }
                        if (conta == 2) indice = i;
                    }
                    
                    if (indice != -1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[indice,i] != 1)
                            {
                                Campo[indice,i] = 2;
                                return;
                            }

                        }
                    }
                    
                }

                if (punto_diagonale_principale)
                {
                    indice = -1;
                    conta = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (Campo[i, i] == 1)
                        {
                            conta++;
                        }
                        if (Campo[i, i] == 2)
                        {
                            conta--;
                        }

                    }
                    if (conta == 2)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[i, i] != 1)
                            {
                                Campo[i, i] = 2;
                                return;
                            }

                        }
                    }
                }

                if (punto_diagonale_secondaria)
                {
                    indice = -1;
                    conta = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[j, 2 - j] == 1)
                        {
                            conta++;
                        }
                        if (Campo[j, 2 - j] == 2)
                        {
                            conta--;
                        }

                    }
                    

                    if (conta == 2)
                    {
                        for (int j = 0; j < 3; j++)
                        {

                                if (Campo[j, 2 - j] != 1)
                                {
                                    Campo[j, 2 - j] = 2;
                                }                        

                        }
                    }
                    
                }
            }

            return;
            



        }



        public static void AI_2()
        {
            bool punto_verticale = false, punto_orizzontale = false, punto_diagonale_principale = false, punto_diagonale_secondaria = false;
            bool segna_verticale = false, segna_orizzontale = false, segna_diagonale_principale = false, segna_diagonale_secondaria = false;
            bool verticale = false, orizzontale = false, diagonale_principale = false, diagonale_secondaria = false;


            //RICERCA VERTICALE
            int conta = 0;
            int indice = -1;

            for (int i = 0; i < 3; i++)
            {
                conta = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (Campo[j, i] == 2)
                    {
                        conta++;
                    }
                    if (Campo[j, i] == 1)
                    {
                        conta--;
                    }
                }
                if (conta == 2) punto_verticale = true;
                if (conta == -2) segna_verticale = true;
                if (conta == -1) verticale = true;
            }



            //RICERCA ORIZZONTALE
            indice = -1;
            for (int i = 0; i < 3; i++)
            {
                conta = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (Campo[i, j] == 2)
                    {
                        conta++;
                    }
                    if (Campo[i, j] == 1)
                    {
                        conta--;
                    }
                }
                if (conta == 2) punto_orizzontale = true;
                if (conta == -2) segna_orizzontale = true;
                if (conta == -1) orizzontale = true;
            }


            //RICERCA DIAGONALE PRINCIPALE
            indice = -1;
            conta = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Campo[i, i] == 2)
                {
                    conta++;
                }
                if (Campo[i, i] == 1)
                {
                    conta--;
                }

            }
            if (conta == 2) punto_diagonale_principale = true;
            if (conta == -2) segna_diagonale_principale = true;
            if (conta == -1) diagonale_principale = true;

            //RICERCA DIAGONALE SECONDARIA
            indice = -1;
            conta = 0;
            for (int j = 0; j < 3; j++)
            {
                if (Campo[j, 2 - j] == 2)
                {
                    conta++;
                }
                if (Campo[j, 2 - j] == 1)
                {
                    conta--;
                }

            }
            if (conta == 2) punto_diagonale_secondaria = true;
            if (conta == -2) segna_diagonale_secondaria = true;
            if (conta == -1) diagonale_secondaria = true;

            if (segna_verticale)
            {
                indice = -1;
                for (int i = 0; i < 3; i++)
                {
                    conta = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[j, i] == 2)
                        {
                            conta++;
                        }
                        if (Campo[j, i] == 1)
                        {
                            conta--;
                        }
                    }
                    if (conta == -2) indice = i;
                }

                if (indice != -1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Campo[i, indice] != 1)
                        {
                            Campo[i, indice] = 1;
                            return;
                        }
                    }
                }
            }
            if (segna_orizzontale)
            {
                indice = -1;
                for (int i = 0; i < 3; i++)
                {
                    conta = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[i, j] == 2)
                        {
                            conta++;
                        }
                        if (Campo[i, j] == 1)
                        {
                            conta--;
                        }
                    }
                    if (conta == -2) indice = i;
                }

                if (indice != -1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Campo[indice, i] != 1)
                        {
                            Campo[indice, i] = 1;
                            return;
                        }

                    }
                }

            }
            if (segna_diagonale_principale)
            {

                indice = -1;
                conta = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (Campo[i, i] == 2)
                    {
                        conta++;
                    }
                    if (Campo[i, i] == 1)
                    {
                        conta--;
                    }

                }
                if (conta == -2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Campo[i, i] != 1)
                        {
                            Campo[i, i] = 1;
                            return;
                        }

                    }
                }
            }
            if (segna_diagonale_secondaria)
            {
                indice = -1;
                conta = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (Campo[j, 2 - j] == 2)
                    {
                        conta++;
                    }
                    if (Campo[j, 2 - j] == 1)
                    {
                        conta--;
                    }

                }


                if (conta == -2)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        if (Campo[j, 2 - j] != 1)
                        {
                            Campo[j, 2 - j] = 1;
                            return;
                        }

                    }
                }
            }


            if (!punto_orizzontale && !punto_verticale && !punto_diagonale_principale && !punto_diagonale_secondaria)
            {
                if (verticale)
                {
                    bool nemica = false;
                    indice = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        conta = 0;
                        nemica = false;
                        for (int j = 0; j < 3; j++)
                        {

                            if (Campo[j, i] == 2)
                            {
                                conta++;
                                nemica = true;
                            }
                            if (Campo[j, i] == 1)
                            {
                                conta--;
                            }
                        }
                        if (conta == -1 && !nemica) indice = i;
                    }

                    if (indice != -1 && !nemica)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[i, indice] != 1)
                            {
                                Campo[i, indice] = 1;
                                return;
                            }
                        }
                    }
                }
                if (orizzontale)
                {
                    bool nemica = false;
                    indice = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        nemica = false;
                        conta = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (Campo[i, j] == 2)
                            {
                                conta++;
                                nemica = true;
                            }
                            if (Campo[i, j] == 1)
                            {
                                conta--;
                            }
                        }
                        if (conta == -1 && !nemica) indice = i;
                    }

                    if (indice != -1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[indice, i] != 1)
                            {
                                Campo[indice, i] = 1;
                                return;
                            }

                        }
                    }
                }
                if (diagonale_principale)
                {
                    bool nemica = false;
                    indice = -1;
                    conta = 0;
                    for (int i = 0; i < 3; i++)
                    {

                        if (Campo[i, i] == 2)
                        {
                            conta++;
                            nemica = true;
                        }
                        if (Campo[i, i] == 1)
                        {
                            conta--;
                        }

                    }
                    if (conta == -1 && !nemica)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[i, i] != 1)
                            {
                                Campo[i, i] = 1;
                                return;
                            }

                        }
                    }
                }
                if (diagonale_secondaria)
                {
                    bool nemica = false;
                    indice = -1;
                    conta = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[j, 2 - j] == 2)
                        {
                            conta++;
                            nemica = true;
                        }
                        if (Campo[j, 2 - j] == 1)
                        {
                            conta--;
                        }

                    }


                    if (conta == -1 && !nemica)
                    {
                        for (int j = 0; j < 3; j++)
                        {

                            if (Campo[j, 2 - j] != 1)
                            {
                                Campo[j, 2 - j] = 1;
                                return;
                            }

                        }
                    }
                }

                Random rnd = new Random();
                int x = -1, y = -1;

                while (x < 0 || y < 0 || Campo[x, y] != 0)
                {
                    x = rnd.Next(0, 3);
                    y = rnd.Next(0, 3);
                }

                Campo[x, y] = 1;

            }
            else
            {
                if (punto_verticale)
                {
                    indice = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        conta = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (Campo[j, i] == 2)
                            {
                                conta++;
                            }
                            if (Campo[j, i] == 1)
                            {
                                conta--;
                            }
                        }
                        if (conta == 2) indice = i;
                    }

                    if (indice != -1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[i, indice] != 2)
                            {
                                Campo[i, indice] = 1;
                                return;
                            }
                        }
                    }

                }

                if (punto_orizzontale)
                {
                    indice = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        conta = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (Campo[i, j] == 2)
                            {
                                conta++;
                            }
                            if (Campo[i, j] == 1)
                            {
                                conta--;
                            }
                        }
                        if (conta == 2) indice = i;
                    }

                    if (indice != -1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[indice, i] != 2)
                            {
                                Campo[indice, i] = 1;
                                return;
                            }

                        }
                    }

                }

                if (punto_diagonale_principale)
                {
                    indice = -1;
                    conta = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (Campo[i, i] == 2)
                        {
                            conta++;
                        }
                        if (Campo[i, i] == 1)
                        {
                            conta--;
                        }

                    }
                    if (conta == 2)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (Campo[i, i] != 2)
                            {
                                Campo[i, i] = 1;
                                return;
                            }

                        }
                    }
                }

                if (punto_diagonale_secondaria)
                {
                    indice = -1;
                    conta = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (Campo[j, 2 - j] == 2)
                        {
                            conta++;
                        }
                        if (Campo[j, 2 - j] == 1)
                        {
                            conta--;
                        }

                    }


                    if (conta == 2)
                    {
                        for (int j = 0; j < 3; j++)
                        {

                            if (Campo[j, 2 - j] != 2)
                            {
                                Campo[j, 2 - j] = 1;
                            }

                        }
                    }

                }
            }

            return;




        }
        public static void stampa()
        {
            Console.Clear();
            Console.WriteLine();


            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
 
                        if (Campo[i, j] == 0)
                        {
                            
                            if (j == 0) Console.Write(" |   | ");
                            else Console.Write("  | ");
                        }
                        if (Campo[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (j == 0) Console.Write(" | X | ");
                            else Console.Write("X | ");
                        }
                        if (Campo[i, j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (j == 0) Console.Write(" | O | ");
                            else Console.Write("O | ");
                        }

                    
                    /*
                    if (Campo[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (j == 0) Console.Write(" | " + Campo[i, j] + " | ");
                        else Console.Write(Campo[i, j] + " | ");
                    }
                    if (Campo[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        if (j == 0) Console.Write(" | " + Campo[i, j] + " | ");
                        else Console.Write(Campo[i, j] + " | ");
                    }
                    */

                }
                Console.WriteLine();
            }

            //Console.WriteLine();
            //Console.WriteLine(vittorie + " - "+ vittorie_bot);
        }
        //public struct Punto {
        //    public int x, y;
        //    public int valore;
        //}

        //public static void Intelligenza_Artificiale(int[,] campo)
        //{
        //    int[,] campo_provvisorio = new int[3,3];
        //    List<Punto> Punti = new List<Punto>();
        //    for(int i = 0; i < 3; i++)
        //    {
        //        for(int j = 0; j < 3; j++)
        //        {
        //            campo_provvisorio = campo;
        //            if (campo_provvisorio[i, j] == 0) campo_provvisorio[i, j] = 2;

        //            //INIZIO STUDIO DEL POSSIBILE CAMPO

                    
                    
        //            bool punto = true;
        //            int pedine = 0, pedine_nemiche = 0;
        //            bool orizzontale, verticale, diagonale, diagonale_secondaria;

        //            //CONTROLLO LE COLONNE
        //            //CONTROLLO SE HO FATTO PUNTO
        //            for (int x = 0; x < 3; x++)
        //            {
        //                punto = true;
        //                for(int y = 0; y < 3; y++)
        //                {
        //                    if (campo_provvisorio[y, x] == 1) pedine_nemiche++;
        //                    if (campo_provvisorio[y, x] == 2) pedine++;
        //                    if (campo_provvisorio[y, x] != 2) punto = false;
        //                }
        //                if (pedine_nemiche == 2 && pedine == 0) verticale = true;
        //            }
        //            if (punto)
        //            {
        //                vittorie_bot++;
        //                Punto p;
        //                p.x = i;
        //                p.y = j;
        //                p.valore = 5;                        
        //                Punti.Add(p);
        //            }
        //            //CONTROLLO SE L'AVVERSARIO PUO FARE PUNTO
                    




        //            //CONTROLLO LE RIGHE
        //            pedine = 0;
        //            pedine_nemiche = 0;
        //            for (int x = 0; x < 3; x++)
        //            {
        //                punto = true;
        //                for (int y = 0; y < 3; y++)
        //                {
        //                    if (campo_provvisorio[x,y] == 1) pedine_nemiche++;
        //                    if (campo_provvisorio[x,y] == 2) pedine++;
        //                    if (campo_provvisorio[x,y] != 2) punto = false;
        //                }
        //            }
        //            if (punto)
        //            {
        //                vittorie_bot++;
        //                Punto p;
        //                p.x = i;
        //                p.y = j;
        //                p.valore = 5;
        //                Punti.Add(p);
        //            }
        //            //CONTROLLO DIAGONALE PRINCIPALE
        //            punto = true;
        //            pedine = 0;
        //            pedine_nemiche = 0;
        //            for (int x = 0; x < 3; x++)
        //            {
        //                if (campo_provvisorio[x, x] == 1) pedine_nemiche++;
        //                if (campo_provvisorio[x, x] == 2) pedine++;
        //                if (campo_provvisorio[x,x] != 2) punto = false;                        
        //            }
        //            if (punto)
        //            {
        //                vittorie_bot++;
        //                Punto p;
        //                p.x = i;
        //                p.y = j;
        //                p.valore = 5;
        //                Punti.Add(p);
        //            }
        //            //CONTROLLO DIAGONALE SECONDARIA
        //            punto = true;
        //            for (int x = 0; x < 3; x++)
        //            {
        //                if (campo_provvisorio[x,2-x] == 1) pedine_nemiche++;
        //                if (campo_provvisorio[x, 2 - x] == 2) pedine++;
        //                if (campo_provvisorio[x, 2-x] != 2) punto = false;
        //            }
        //            if (punto)
        //            {
        //                vittorie_bot++;
        //                Punto p;
        //                p.x = i;
        //                p.y = j;
        //                p.valore = 5;
        //                Punti.Add(p);
        //            }

                    

        //        }
        //    }
        //}
        //public static void reset()
        //{

        //}
    }

    
}
