using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using AutoMapper;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;
using MLG.POS.Backend.Services.Interfaces;
using MLG.POS.Backend.Services.Services;

namespace MLG.POS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        IConfiguration _config;
        IMapper _mapper;
        IServiceArticles _serviceServiceArticles;


        public ArticlesController(IConfiguration configuration, IMapper mapper)
        {
            _config = configuration;
            _mapper = mapper;
            _serviceServiceArticles = new ServiceArticles(_config, _mapper);
        }


        [HttpPost("AddArticle", Name = "AddArticle")]
        public IActionResult AddClient([FromBody] ArticleDto article)
        {
            ActionResult result = null;
            try
            {
                Article objArticle = _serviceServiceArticles.InsertArticle(article);

                result = Ok(objArticle);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        [HttpGet("GetArticles", Name = "GetArticles")]
        public IActionResult GetArticles()
        {
            ActionResult result = null;
            try
            {
                IEnumerable<Article> objArticle = _serviceServiceArticles.GetArticles();

                result = Ok(objArticle);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        [HttpPatch("UpdateArticle", Name = "UpdateArticle")]
        public IActionResult UpdateArticle([FromBody] ArticleDto article)
        {
            ActionResult result = null;
            try
            {
                _serviceServiceArticles.UpdateArticle(article);

                result = Ok();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        [HttpDelete("DeleteArticle", Name = "DeleteArticle")]
        public IActionResult DeleteArticle(int id)
        {
            ActionResult result = null;
            try
            {
                _serviceServiceArticles.DeleteArticle(id);

                result = Ok();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

    }
}
