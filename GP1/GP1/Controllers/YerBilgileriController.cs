using Graduation.Project.Api.DataAccess;
using Graduation.Project.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YerBilgileriController : ControllerBase
    {
        private readonly ILogger<YerBilgileriController> _logger;
        private readonly IDBContext _db;
        public YerBilgileriController(ILogger<YerBilgileriController> logger, IDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        /// <summary>
        /// Yerler Listesini Döndürür
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllPlacesİnfo")]
        public IActionResult Get()
        {
            try
            {
                var _data = (from a in _db.YerBilgileri
                             select new YerBilgileriDto()
                             {
                                 
                                 yer_id = a.yer_id,
                                 yer_bilgisi = a.yer_bilgisi
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
        [Route("GetPlaceİnfobyId")]
        public IActionResult Get(long id)
        {
            try
            {
                if (_db.YerBilgileri.Any(a => a.yer_id == id))
                {
                    var _data = (from a in _db.YerBilgileri
                                 where a.yer_id == id
                                 select new YerBilgileriDto()
                                 {
                                     
                                     yer_id = a.yer_id,
                                     yer_bilgisi = a.yer_bilgisi,

                                 }).FirstOrDefault();

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
