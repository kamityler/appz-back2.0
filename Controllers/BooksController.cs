//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Http.Cors;

//namespace Lab5LKPZ.Controllers
//{
    
//    [ApiController]
//    [Route("api/[controller]")]
//    public class BooksController : Controller
//    {
//        private readonly Data.BooksApiDbContext dbContext;
//        public BooksController(Data.BooksApiDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetProducts()
//        {
//            return Ok(await this.dbContext.Books.ToListAsync());

//        }


//        [HttpPost]
//        public async Task<IActionResult> AddProduct(Model.AddBookRequest addBookRequest)
//        {
//            var book = new Model.BookModel()
//            {
//                // id = dbContext.Products.Count()+1,
//                Name = addBookRequest.Name,
//                Author = addBookRequest.Author,
//                Picture = addBookRequest.Picture,
//                Price = addBookRequest.Price
//            };
//            await dbContext.Books.AddAsync(book);
//            await dbContext.SaveChangesAsync();
//            return Ok(book);

//        }

//        [HttpPut]
//        [Route("{id:int}")]
//        public async Task<IActionResult> UpdateProduct([FromRoute] int id, Model.UpdateBookRequest updateContactRequest)
//        {
//            var book = await dbContext.Books.FindAsync(id);
//            if (book != null)
//            {
//                book.Name = updateContactRequest.Name;
//                book.Author = updateContactRequest.Author;
//                book.Author = updateContactRequest.Picture;
//                book.Price = updateContactRequest.Price;
//                await dbContext.SaveChangesAsync();
//                return Ok(book);
//            }
//            return NotFound();

//        }



//        [HttpDelete]
//        [Route("{id:int}")]
//        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
//        {
//            var b = await dbContext.Books.FindAsync(id);
//            if (b != null)
//            {
//                dbContext.Books.Remove(b);
//                await dbContext.SaveChangesAsync();
//                return Ok(b);

//            }
//            return NotFound();

//        }

//    }
//}
