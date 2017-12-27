using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLaboratory.Model
{
    public class NetRepo
    {
        NetContext ctx;

        public NetRepo()
        {
            ctx = new NetContext();
        }

        public List<Article> GetAllArticles()
        {
            return ctx.Articles.OrderBy(i=>i.Title).ToList();
        }

        public List<Comment> GetAllComments()
        {
            return ctx.Comments.ToList();
        }

        public List<Comment> GetAllCommentsForArticle(Article article)
        {
            return ctx.Comments.Where(i=>i.Article.Id == article.Id).ToList();
        }

        public int AddArticle(Article article)
        {
            ctx.Set<Article>().Add(article);
            ctx.SaveChanges();
            int id = article.Id;
            return id;
        }

        public int AddArticle(string title, string content)
        {
            if (title.Equals("") || content.Equals(""))
                throw new ArgumentException("Tytuł i treść nie mogą być puste!");
            return AddArticle(new Article { Title = title, Content = content});
        }

        public int AddComment(Comment comment)
        {
            ctx.Set<Comment>().Add(comment);
            ctx.SaveChanges();
            int id = comment.Id;
            return id;
        }

        public int AddComment(string content)
        {
            if ( content.Equals(""))
                throw new ArgumentException("Treść nie moze być pusta!");
            return AddComment(new Comment { Content = content });
        }

        public void DeleteComment(Comment comment)
        {
            ctx.Set<Comment>().Remove(comment);
            ctx.SaveChanges();
        }

    }
}
