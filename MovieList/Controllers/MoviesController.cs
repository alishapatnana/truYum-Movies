using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using MovieList.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MoviesController));
        private IMoviesRepository<Movies> _service;
        public MoviesController(IMoviesRepository<Movies> service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Movies>> Get()
        {
            try
            {
                _log4net.Info("Http Get request Initiated");

                var menuitems = _service.GetAll();
                if (menuitems != null)
                {
                    _log4net.Info("successfully got details");
                    return Ok(menuitems);
                }

            }
            catch (Exception e)
            {
                _log4net.Error("No result " + e.Message);
                return new NoContentResult();
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public ActionResult<Movies> Get(int id)
        {
            try
            {
                _log4net.Info("Http get request initiated with " + id);
                var menuItem = _service.GetById(id);

                if (menuItem == null)
                {
                    _log4net.Info("Menu item with that Requested Id not Found");

                    return NotFound(id);
                }
                _log4net.Info("Found Matching menu item");
                return Ok(menuItem);
            }
            catch (Exception e)
            {
                _log4net.Error("No content Obtained " + e.Message);
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<Movies> Post([FromBody] Movies item)
        {
            try
            {
                _log4net.Info("HttpPost Request Initiated for Id " + item.MovieId);
                if (ModelState.IsValid)
                {
                    _log4net.Info("Model state is  valid for Id " + item.MovieId);
                    _service.Add(item);
                    return CreatedAtAction("Get", new { id = item.MovieId }, item);
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Model state is not valid for id " + item.MovieId + e.Message);
                return NotFound();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public ActionResult<Movies> Put(int id, [FromBody] Movies item)
        {
            try
            {
                _log4net.Info("HttpPost Request Initiated for Id " + item.MovieId);
                if (ModelState.IsValid)
                {
                    _log4net.Info("Model state is  valid for Id " + item.MovieId);
                    var updateMenuitem = _service.Update(item);
                    if (updateMenuitem != null)
                    {
                        return Ok(updateMenuitem);
                    }
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Model state is not valid for id " + item.MovieId + e.Message);
                return NotFound();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult<Movies> Delete(int id)
        {
            try
            {
                _log4net.Info("HttpPost Request Initiated for Id " + id);
                if (ModelState.IsValid)
                {
                    _log4net.Info("Model state is  valid for Id " + id);
                    var DeleteMenuitem = _service.Delete(id);
                    if (DeleteMenuitem == true)
                    {
                        return Ok("Deleted Succesfully");
                    }
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Model state is not valid for id " + id + e.Message);
                return NotFound();
            }
            return BadRequest();
        }
    }
}
