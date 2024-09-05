using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.CoreLayer.Dtos.CommentDtos;
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.CommentServices.Commands
{
    public interface ICreateCommentService
    {
        MyResultWithoutData CreateComment(CreateCommentDto commentDto);
    }

    public class CreateCommentService(HyrDbContext dbContext) : ICreateCommentService
    {
        public MyResultWithoutData CreateComment(CreateCommentDto commentDto)
        {

            if (commentDto.ProductId <= 0)
                return MyResultWithoutData.Failed();

            Comment comment = new Comment()
            {
                ProductId = commentDto.ProductId,
                CreationDate = DateTime.Now,
                Description = commentDto.Description,
                Score = commentDto.Score,
                Title = commentDto.Title,
                UserId = commentDto.UserId
            };




            //config Product Score

            Product product = dbContext.Products.Include(p => p.Comments).First(p => p.ProductId == commentDto.ProductId);

            var commentcount = product.Comments.Count() == 0 ? 1 : product.Comments.Count + 1 ;
            var SumCommentsScore = product.Comments.Select(c => c.Score).Sum() + commentDto.Score;
            var AvrageProductScore = SumCommentsScore / commentcount;
            product.Score = AvrageProductScore;

            //----------------------

            dbContext.Comments.Add(comment);
            dbContext.Products.Update(product);

            dbContext.SaveChanges();

            return MyResultWithoutData.Success();
        }
    }


}
