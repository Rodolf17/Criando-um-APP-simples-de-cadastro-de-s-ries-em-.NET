using System;
using System.Collections.Generic;
using Dio.Animes.Interfaces;


namespace Dio.Animes
{
    public class AnimesRepositorio : IRepositorio<Anime>
    {
        private List<Anime> listaAnimes = new List<Anime>();

        public void Atualiza(int id, Anime objeto)
        {
            listaAnimes[id] = objeto;
        }
        public void Exclui(int id)
        {
           listaAnimes[id].Excluir();
        }
        public void Insere(Anime objeto)
        {
            listaAnimes.Add(objeto);
        }
        public List<Anime> Lista()
        {
			return listaAnimes;
		}

		public int ProximoId()
		{
			return listaAnimes.Count;
		}

		public Anime RetornaPorId(int id)
		{
			return listaAnimes[id];
		}
    }
}