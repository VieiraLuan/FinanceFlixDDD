﻿using FinanceFlix.Domain.Entities;


namespace FinanceFlix.API.Entities
{
    public class Curso:Entity
    {
        public Curso(Guid id, string nome, string descricao, byte[]? imagemUrl, Guid categoriaId, Categoria? categoria,
            ICollection<CursoVideo>? cursosVideos /*ICollection<CursoTrilha>? cursosTrilhas*/)
        {
         
            Nome = nome;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            CategoriaId = categoriaId;
            Categoria = categoria;
            CursosVideos = cursosVideos;
            //CursosTrilhas = cursosTrilhas;
        }

        public Curso( string nome, string descricao, byte[]? imagemUrl, Guid categoriaId)
        {
           
            Nome = nome;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            CategoriaId = categoriaId;
        }

        public Curso()
        {
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public byte[] ImagemUrl { get; private set; }


        public Guid CategoriaId { get; private set; }


        public Categoria? Categoria { get; private set; }

        public ICollection<CursoVideo>? CursosVideos { get; private set; }

        //public ICollection<CursoTrilha>? CursosTrilhas { get; private set; }




    }
}
