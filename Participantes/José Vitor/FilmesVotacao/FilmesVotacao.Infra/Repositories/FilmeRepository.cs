﻿using Dapper;
using FilmesVotacao.Domain.Entidades;
using FilmesVotacao.Domain.Interfaces.Repositories;
using FilmesVotacao.Domain.Queries.Filme;
using FilmesVotacao.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FilmesVotacao.Infra.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DynamicParameters _parametros = new DynamicParameters();
        private readonly DataContext _dataContext;
        public FilmeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<FilmeQueryResult> Listar()
        {
            try
            {
                string sql = @"SELECT * FROM Filme ORDER BY Titulo;";

                return _dataContext.SQLServerConexao.Query<FilmeQueryResult>(sql).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FilmeQueryResult ObterPorId(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);
                string sql = @"SELECT * FROM Filme WHERE Id=@Id;";

                return _dataContext.SQLServerConexao.Query<FilmeQueryResult>(sql,_parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckId(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);
                string sql = @"SELECT * FROM Filme WHERE Id=@Id;";

                return _dataContext.SQLServerConexao.Query<bool>(sql, _parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Inserir(Filme filme)
        {
            try
            {
                _parametros.Add("Titulo", filme.Titulo, DbType.String);
                _parametros.Add("Diretorr", filme.Diretor, DbType.String);

                string sql = @"INSERT INTO Filme (Titulo, Diretor) Values (@Titulo, @Diretor); SELECT SCOPE_IDENTITY();";

                return _dataContext.SQLServerConexao.ExecuteScalar<long>(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Alterar(Filme filme)
        {
            try
            {
                _parametros.Add("Id", filme.Id, DbType.Int64);
                _parametros.Add("Titulo", filme.Titulo, DbType.String);
                _parametros.Add("Diretor", filme.Diretor, DbType.String);

                string sql = @"UPDATE Filme SET Titulo=@Titulo, Diretor=@Diretor WHERE Id=@Id;";

                _dataContext.SQLServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Deletar(long id)
        {
            try
            {
                _parametros.Add("Id", id, DbType.Int64);

                string sql = @"DELETE FROM Filme WHERE Id=@Id;";

                _dataContext.SQLServerConexao.Execute(sql, _parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
