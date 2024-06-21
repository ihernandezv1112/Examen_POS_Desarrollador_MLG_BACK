using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;

namespace MLG.POS.Backend.Services.Interfaces
{
    public interface IServiceArticles
    {
        public Article InsertArticle(ArticleDto article);
        public IEnumerable<Article> GetArticles();
        public void UpdateArticle(ArticleDto article);
        public void DeleteArticle(int id);
    }
}
