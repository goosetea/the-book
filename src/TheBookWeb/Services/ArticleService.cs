﻿using Core.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBookWeb.Interfaces;

namespace TheBookWeb.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;

        public ArticleService(IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public Article CreateArticle(string title, string body)
        {
            DateTime now = DateTime.Now;

            Article article = new Article
            {
                Title = title,
                Body = body,
                Author = "AUTHOR",
                DateCreation = now,
                DateModification = now,
                IsDeleted = false
            };

            _articleRepository.Add(article);
            _articleRepository.Save();

            return article;
        }

        public Article GetArticle(int id)
        {
            return _articleRepository.Get(id);
        }

        public Article UpdateArticle(int id, string title, string body)
        {
            Article article = _articleRepository.Get(id);
            article.Title = title;
            article.Body = body;
            article.Author = "UPD_AUTHOR";
            article.DateModification = DateTime.Now;
            _articleRepository.Save();
            return article;
        }
    }
}