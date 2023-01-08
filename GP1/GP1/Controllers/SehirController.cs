using Graduation.Project.Api.DataAccess;
using Graduation.Project.Api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController : ControllerBase
    {
        private readonly ILogger<SehirController> _logger;
        private readonly IDBContext _db;
        public SehirController(ILogger<SehirController> logger, IDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        /// <summary>
        /// Şehir Listesini Döndürür
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllCity")]
        public IActionResult Get()
        {
            try
            {
                var _data = (from a in _db.Sehirler
                             select new SehirlerDto()
                             {
                                 ID = a.ID,
                                 Şehirler = a.Şehirler

                             }).ToList();

                return Ok(_data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        /// <summary>
        /// ID'ye göre şehir arama
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCitybyId")]
        public IActionResult Get(long id)
        {
            try
            {
                if (_db.Sehirler.Any(a => a.ID == id))
                {
                    var _data = (from a in _db.Sehirler
                                 where a.ID == id
                                 select new SehirlerDto()
                                 {

                                     ID = a.ID,
                                     Şehirler = a.Şehirler,
                                     
                                 }).FirstOrDefault();

                    return Ok(_data);
                }
                else
                {
                    return NotFound("City not found");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
