using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MLG.POS.Backend.Services.Interfaces;
using MLG.POS.Backend.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Data.SqlClient;
using MLG.POS.Backend.Repositories.Repositories;
using MLG.POS.Backend.Core.Entities;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Exceptions;
using System.Globalization;
using Azure;

namespace MLG.POS.Backend.Services.Services
{
    public class ServiceArticles : ServiceBase, IServiceArticles
    {
        string connectionName = "SqlConnectionLocal";
        IDbConnection _connection;
        IRepositoryArticles _repositoryArticles;

        public ServiceArticles(IConfiguration configuration, IMapper mapper) : base(configuration, mapper)
        {
            _connection = new SqlConnection(_configuration.GetConnectionString(connectionName));
            _repositoryArticles = new RepositoryArticles(_connection);
        }

        public Article InsertArticle(ArticleDto article)
        {
            Article response = new Article();

            try
            {
                response = _repositoryArticles.InsertArticle(article);

                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't insert records", ex);
            }
        }

        public IEnumerable<Article> GetArticles()
        {
            IEnumerable<Article> response = null;

            try
            {
                response = _repositoryArticles.GetArticles();

                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't get records", ex);
            }
        }

        public void UpdateArticle(ArticleDto article)
        {
            try
            {
                _repositoryArticles.UpdateArticle(article);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't insert records", ex);
            }
        }

        public void DeleteArticle(int id)
        {
            try
            {
                _repositoryArticles.DeleteArticle(id);

            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't insert records", ex);
            }
        }

    }
}
