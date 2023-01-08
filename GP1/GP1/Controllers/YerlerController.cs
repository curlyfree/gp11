using Graduation.Project.Api.DataAccess;
using Graduation.Project.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YerlerController : ControllerBase
    {
        private readonly ILogger<YerlerController> _logger;
        private readonly IDBContext _db;
        public YerlerController(ILogger<YerlerController> logger, IDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        /// <summary>
        /// Yerler Listesini Döndürür
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllPlaces")]
        public IActionResult Get()
        {
            try
            {
                var _data = (from a in _db.Yerler
                             select new GezilecekYerlerDto()
                             {
                                 ID = a.ID,
                                 Şehir_Id = a.Şehir_Id,
                                 Gezilecek_Yerler = a.Gezilecek_Yerler
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
        /// Proje Detay Bilgisi Döndürür
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCitybyId")]
        public IActionResult Get(long id)
        {
            try
            {
                if (_db.Yerler.Any(a => a.Şehir_Id == id))
                {
                    var _data = (from a in _db.Yerler
                                 where a.Şehir_Id == id
                                 select new GezilecekYerlerDto()
                                 {
                                     ID = a.ID,
                                     Şehir_Id = a.Şehir_Id,
                                     Gezilecek_Yerler = a.Gezilecek_Yerler,

                                 });

                    return Ok(_data);
                }
                else
                {
                    return NotFound("Place not found");
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
