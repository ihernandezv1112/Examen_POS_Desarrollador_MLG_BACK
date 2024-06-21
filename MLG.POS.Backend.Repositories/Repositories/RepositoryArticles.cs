using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;
using MLG.POS.Backend.Repositories.Interfaces;
using MLG.POS.Backend.Repositories.Repositories.Common;

namespace MLG.POS.Backend.Repositories.Repositories
{
    public class RepositoryArticles : RepositoryBase, IRepositoryArticles
    {
        public RepositoryArticles(IDbConnection connection) : base(connection)
        {
        }

        public Article InsertArticle(ArticleDto article)
        {
            int id = 0;
            Article objArticle= new Article();

            using (_connection)
            {
                var result = _connection.Query<Article>
                    (
                    sql: "Pos_Insert_Article_SP",
                    param: new
                    {
                        Cve_Code = article.Cve_Code,
                        Des_Description = article.Des_Description,
                        Val_Price = article.Val_Price,
                        Img_Image = article.Img_Image,
                        Val_Stock = article.Val_Stock
                    },
                    commandType: CommandType.StoredProcedure
                    ).First();

                if (result is not null)
                {
                    objArticle = result;

                }
            }

            return objArticle;
        }

        public IEnumerable<Article> GetArticles()
        {
            IEnumerable<Article>? result = null;

            try
            {
                result = _connection.Query<Article>("Pos_Get_Articles_SP", commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void UpdateArticle(ArticleDto article)
        {
            using (_connection)
            {
                _connection.Execute
                    (
                    sql: "Pos_Update_Article_SP",
                    param: new
                    {
                        Id_Article = article.Id_Article,
                        Cve_Code = article.Cve_Code,
                        Des_Description = article.Des_Description,
                        Val_Price = article.Val_Price,
                        Img_Image = article.Img_Image,
                        Val_Stock = article.Val_Stock
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteArticle(int id)
        {
            using (_connection)
            {
                _connection.Execute
                    (
                    sql: "Pos_Delete_Article_ById_SP",
                    param: new
                    {
                        Id_Article = id
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

    }
}
