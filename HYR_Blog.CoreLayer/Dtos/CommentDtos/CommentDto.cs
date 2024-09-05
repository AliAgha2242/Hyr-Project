using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.CommentDtos
{
    public class CommentDto
    {
    public string Description { get; set; }
    public string Title { get; set; }
    public bool IsDelete { get; set; } = false;
    public int ProductId { get; set; }
    public string UserName { get; set; }
    public DateTime CreationDate { get; set; }
    public float Score { get; set; }
    }
}
