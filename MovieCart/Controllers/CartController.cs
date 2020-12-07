using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCart.Models;
using MovieCart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CartController));
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<CartController>
        [HttpGet]
        public ActionResult<IEnumerable<Movies>> Get()
        {
            return BadRequest();
        }
        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Movies>> Get(int id)
        {
            try
            {
                _log4net.Info("Http get request initiated for all cart Items");
                var ItemsList = _repository.GetCartItems(id);
                if (ItemsList != null)
                {
                    _log4net.Info("All the MenuItems were displayed");
                    return Ok(ItemsList);
                }
                else
                {
                    _log4net.Error("No user Found ");
                    return NotFound("No User Found");
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Http get Request Failed Due to " + e.Message);
                return NotFound("No User Found");
            }

        }
        // POST api/<CartController>
        [HttpPost("{id}")]
        public ActionResult<Movies> Post(int id, [FromBody] Movies item)
        {
            try
            {
                _log4net.Info("Http post Request Initiated for the user Id " + id);
                if (ModelState.IsValid)
                {
                    _log4net.Info("Obtained Valid Model");
                    var items = _repository.AddToCart(id, item);
                    return Ok(items);
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Http post Request Failed Due to " + e.Message);
                return NotFound();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult<Movies> Delete(int id, int menuitemid)
        {
            try
            {
                _log4net.Info("Http Delete Request Initiated for the user Id " + id);
                var IsDeleted = _repository.Delete(id, menuitemid);
                if (IsDeleted)
                {
                    return Ok("Removed From the cart succesfully");
                }

            }
            catch (Exception e)
            {
                _log4net.Error("Http Delete Request Failed Due to " + e.Message);
                return NotFound();
            }
            return BadRequest();
        }
    }
}
