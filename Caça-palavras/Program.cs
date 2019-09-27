using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caça_palavras
{
    //Nome da programadora: Nayla Cristina Gomes Carvalho da Silva

    class Program
    {
        //Variáveis para acesso as localizações da segunda letra
        static int[] x = new int[8] { -1, 0, 1, 1, 1, 0, -1, -1 };
        static int[] y = new int[8] { 1, 1, 1, 0, -1, -1, -1, 0 };

        //Matriz que guarda o caça-palavras
        static char[,] matriz = new char[15, 15] { { 'Y', 'C', 'Y', 'G', 'W', 'R', 'P', 'K', 'H', 'O', 'A', 'B', 'U', 'V', 'H' },
            { 'S', 'C', 'I', 'R', 'F', 'Z', 'B', 'M', 'C', 'P', 'M', 'Y', 'C', 'F', 'P'},
            {'U', 'A', 'F', 'R', 'X', 'T', 'W', 'L', 'O', 'T', 'A', 'S', 'M', 'X', 'C' },
            { 'E', 'J', 'R', 'A', 'G', 'S', 'A', 'V', 'H', 'G', 'L', 'R', 'X', 'G', 'F' },
            { 'K', 'X', 'Z', 'T', 'A', 'P', 'C', 'V', 'J', 'Q', 'M', 'J', 'Y', 'M', 'G'},
            { 'G', 'C', 'X', 'Q', 'E', 'W', 'S', 'I', 'A', 'L', 'A', 'E', 'O', 'I', 'V'},
            {'I', 'F', 'Y', 'F', 'X', 'V', 'A', 'L', 'P', 'A', 'L', 'H', 'E', 'T', 'A' },
            {'L', 'E', 'K', 'O', 'U', 'U', 'T', 'I', 'G', 'U', 'A', 'N', 'C', 'O', 'I' },
            {'V', 'H', 'I', 'H', 'Z', 'U', 'A', 'I', 'F', 'R', 'D', 'B', 'A', 'L', 'U'},
            {'A', 'R', 'Z', 'H', 'X', 'C', 'L', 'C', 'O', 'G', 'E', 'E', 'X', 'V', 'R'},
            {'U', 'N', 'B', 'S', 'T', 'M', 'U', 'S', 'I', 'C', 'A', 'T', 'L', 'A', 'A'},
            {'W', 'R', 'A', 'U', 'J', 'A', 'B', 'I', 'S', 'S', 'N', 'O', 'R', 'I', 'S'},
            {'C', 'M', 'P', 'L', 'E', 'N', 'P', 'A', 'L', 'C', 'O', 'A', 'H', 'B', 'E'},
            {'T', 'M', 'F', 'O', 'T', 'Z', 'M', 'P', 'T', 'R', 'E', 'S', 'J', 'R', 'L'},
            {'F', 'S', 'I', 'K', 'U', 'F', 'P', 'E', 'Q', 'T', 'A', 'M', 'L', 'O', 'J' } };

        //Matriz que guarda os '*' e as letras encontradas
        static char[,] achados = new char[matriz.GetUpperBound(0) + 1, matriz.GetUpperBound(1) + 1];

        //Cabeçalho do jogo
        static public void Cabecalho()
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("**************** CAÇA-PALAVRAS ***************");
            Console.WriteLine("**********************************************");
        }

        //Imprime o caça-palavras
        static void Mapa()
        {
            for (int i = 0; i < matriz.GetUpperBound(0) + 1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matriz.GetUpperBound(1) + 1; j++)
                {
                    Console.Write($" {matriz[i, j]} ");
                }
            }
        }

        //Preenche a matriz 'achados' com '*'
        static void LimpaMapa()
        {
            for (int i = 0; i < matriz.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matriz.GetUpperBound(1) + 1; j++)
                {
                    achados[i, j] = '*';
                }
            }
        }

        //Substitui os '*' pelas letras encontradas
        static void MapaDeAchados(int Xinicial, int Yinicial, int movimentacao, string palavra)
        {
            //recebem as "regras" do 'i' e o 'j' que foram utilizadas para encontrar as palavras
            int movimentoX = x[movimentacao];
            int movimentoY = y[movimentacao];

            //variáveis que guardam o valor depois da localização receber o "movimento"
            int moverX, moverY;

            for (int i = 0; i < matriz.GetUpperBound(0) + 1; i++)//para cada linha 
            {
                for (int j = 0; j < matriz.GetUpperBound(1) + 1; j++)//para cada coluna
                {
                    for (int k = 0; k < palavra.Length; k++)//percorre a palavra
                    {
                        if (i == Xinicial && j == Yinicial)
                        {
                            moverX = Xinicial + (movimentoX * k);
                            moverY = Yinicial + (movimentoY * k);

                            if (PodeMover(moverX, moverY))
                                achados[moverX, moverY] = matriz[moverX, moverY];
                        }
                    }
                }
            }
        }

        //Imprime a matriz com as letras encontradas
        static void ImprimeMapaAchados()
        {
            for (int i = 0; i < matriz.GetUpperBound(0) + 1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matriz.GetUpperBound(1) + 1; j++)
                {
                    Console.Write($" {achados[i, j]} ");
                }
            }
        }

        //Impede que algo ultrapasse as bordas da matriz
        static bool PodeMover(int i, int j)
        {
            if (i >= 0 && i <= 14 && j >= 0 && j <= 14)
                return true;

            return false;
        }

        //Encontra a primeira letra da palavra na matriz
        static bool PrimeiraLetra(int i, int j, string palavra, char[,] matriz, ref string texto)
        {
            if (PodeMover(i, j))
            {
                if (palavra[0] == matriz[i, j])
                {
                    texto += matriz[i, j];
                    return true;
                }
            }
            return false;
        }

        //Encontra a segunda letra a partir da primeira
        static bool SegundaLetra(int i, int j, string palavra, out int movimentacao)
        {
            int movimentoX, movimentoY;
            int Xinicial = i, Yinicial = j;

            //percorre os vetores estáticos 'x' e 'y', que guardam os valores que serão utilizados nas "regras"
            for (int k = 0; k < 8; k++)
            {
                movimentoX = x[k];
                movimentoY = y[k];

                //soma a regra aos valores inicias, obtendo a posição onde a segunda letra pode estar
                int moverX = i + movimentoX;
                int moverY = j + movimentoY;

                //se após a 'movimentação' tudo ainda estiver dentro da matriz
                if (PodeMover(moverX, moverY))
                {
                    if (palavra[1] == matriz[moverX, moverY])
                    {
                        movimentacao = k;//guarda a "regra" usada
                        return true;
                    }
                }
            }

            movimentacao = 0;
            return false;
        }

        //Encontra o resto das letras a partir da "regra" utilizada para encontrar a segunda
        static bool OutrasLetras(int i, int j, int movimentacao, string palavra, int posicao, ref string texto)
        {
            int movimentoX, movimentoY;

            movimentoX = x[movimentacao];
            movimentoY = y[movimentacao];

            //soma dos valores iniciais ao produto da "regra" com a posição da letra que esta sendo analisada
            int moverX = i + (movimentoX * posicao);
            int moverY = j + (movimentoY * posicao);

            //se após a 'movimentação' tudo ainda estiver dentro da matriz
            if (PodeMover(moverX, moverY))
            {
                if (palavra[posicao] == matriz[moverX, moverY])
                    return true;
            }
            return false;
        }

        //Analisa se o a string 'texto' é igual a palavra inserida e determina se esta foi encontrada
        //Envia os valores iniciais da palavra encontrada ao MapaDeAchados
        static bool EncontrarPalavra(int Xinicial, int Yinicial, int movimentacao, string texto, string palavra, ref int vezesEncontradas)
        {
            if (texto == palavra)
            {
                MapaDeAchados(Xinicial, Yinicial, movimentacao, palavra);
                vezesEncontradas++;
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                LimpaMapa();

                Cabecalho();
                Mapa();
                Console.WriteLine();

                Console.Write("\nDigite uma palavra para caçarmos no caça-palavras: ");
                string palavra = Console.ReadLine().ToUpper(); //recebendo a palavra

                //zerando variáveis para serem utilizadas novamente                
                int movimentacao = 0, vezesEncontradas = 0;
                //variável que recebe as letras encontradas para depois ser comparada com a palavra inserida
                string texto = "";

                for (int i = 0; i < matriz.GetUpperBound(0) + 1; i++) //para cada linha da matriz
                {
                    for (int j = 0; j < matriz.GetUpperBound(1) + 1; j++) //para cada coluna da matriz
                    {
                        if (PodeMover(i, j))//se tudo estiver dentro da matriz
                        {
                            if (PrimeiraLetra(i, j, palavra, matriz, ref texto))
                            {
                                EncontrarPalavra(i, j, movimentacao, texto, palavra, ref vezesEncontradas);

                                if (palavra.Length > 1 && SegundaLetra(i, j, palavra, out movimentacao))
                                {
                                    texto += palavra[1];
                                    EncontrarPalavra(i, j, movimentacao, texto, palavra, ref vezesEncontradas);

                                    //percorre da terceira letra em diante já que as duas primeiras já foram encontradas
                                    for (int k = 2; k < palavra.Length; k++)
                                    {
                                        if (OutrasLetras(i, j, movimentacao, palavra, k, ref texto))
                                        {
                                            texto += palavra[k];
                                            EncontrarPalavra(i, j, movimentacao, texto, palavra, ref vezesEncontradas);

                                        }
                                    }
                                }
                            }
                        }

                        texto = ""; //zerando variável para ser utilizada na próxima linha
                    }

                }

                Console.Clear();

                Cabecalho();
                ImprimeMapaAchados();
                Console.WriteLine("\n");

                if (vezesEncontradas > 0)//se algo foi somado a variável, a palavra foi encontrada
                {
                    if (palavra.Length == 1)
                        Console.WriteLine("Você digitou somente uma letra! Mas, se quer saber, ela aparece " + vezesEncontradas + " vezes");
                    else
                        Console.WriteLine("A palavra foi encontrada " + vezesEncontradas + " vez(es)!");
                }
                else //se não, a palavra não foi encontrada
                    Console.WriteLine("Nenhuma ocorrência para a palavra '" + palavra + "'");

                Console.WriteLine("\n");
                Console.Write("Pressione qualquer tecla para continuar inserindo palavras...");
                Console.ReadKey();
            }
        }
    }
}
