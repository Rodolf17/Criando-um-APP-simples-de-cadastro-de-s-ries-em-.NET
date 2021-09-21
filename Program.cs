using System;

namespace Dio.Animes
{
    class Program
    {
        static AnimesRepositorio repositorio = new AnimesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarAnimes();
                        break;
                    case "2":
                        InserirAnimes();
                        break;
                    case "3":
                        AtualizaAnimes();
                        break;
                    case "4":
                        ExcluirAnimes();
                        break;
                    case "5": 
                        VizualizarAnimes(); 
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    default:
                     throw new ArgumentOutOfRangeException();                      
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }   

        private static void ExcluirAnimes()
        {
            Console.WriteLine("Digite o id do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceAnime);
        } 

        private static void VizualizarAnimes()
        {
            Console.WriteLine("Digite o id do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            var Anime = repositorio.RetornaPorId(indiceAnime);
            Console.WriteLine(Anime);
        }

        private static void AtualizaAnimes()
        {
            Console.WriteLine("Digite o ID do Anime:");
            int indiceAnime = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i ,Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do Anime: ");
             string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio do Anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Anime: ");
            string entradaDescricao = Console.ReadLine();

                Anime atualizaAnime =  new Anime(id: indiceAnime,
                                        genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

                repositorio.Atualiza(indiceAnime,atualizaAnime);                            
        }

        
        private static void ListarAnimes()
        {
            Console.WriteLine("Listar Animes");

            var lista = repositorio.Lista();

             if(lista.Count == 0){
                 Console.WriteLine("Nenhuma serie cadastrada");
                 return ;
             }   
               foreach(var Anime in lista)
               {
                   var excluido = Anime.retornaExcluido();
                   Console.WriteLine("#ID {0}: - {1} {2} ",Anime.retornaId(),Anime.retornaTitulo(),(excluido ?"*Excluido*":""));
               } 
        }

        private static void InserirAnimes()
        {
            Console.WriteLine("Inserir novos Animes");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo do Anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio do Anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Anime: ");
            string entradaDescricao = Console.ReadLine();

                Anime novoAnime =  new Anime(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

                repositorio.Insere(novoAnime);                        
        }    


        private static string ObterOpcaoUsuario ()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Animes a seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Animes: ");
            Console.WriteLine("2- Inserir Novos Animes: ");
            Console.WriteLine("3-Atualizar Animes: ");
            Console.WriteLine("4-Excluir Animes: ");
            Console.WriteLine("5-Vizualizar Animes: ");
            Console.WriteLine("C-Limpar a tela: ");
            Console.WriteLine("x-Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario; 
        }
    }
}
