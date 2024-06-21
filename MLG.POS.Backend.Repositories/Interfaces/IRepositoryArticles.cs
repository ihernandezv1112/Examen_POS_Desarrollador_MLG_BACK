using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.POS.Backend.Repositories.Interfaces
{
    public interface IRepositoryArticles
    {
        Article InsertArticle(ArticleDto article);
        IEnumerable<Article> GetArticles();
        void UpdateArticle(ArticleDto article);
        void DeleteArticle(int id);
    }
}
