using attorneyApi.Models;
using attorneyApi.Repository.Interface;
using attorneyAPINew.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using static attorneyAPINew.Models.attorneyPetrovicContext;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Linq.Expressions;


namespace attorneyAPINew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly attorneyPetrovicContext _context;
        private readonly ICourtCodeRepository _courtCodeRepository;
        private readonly ICourtCaseRepository _courtCaseRepository;

        public HomeController(ILogger<HomeController> logger, ICourtCodeRepository courtCodeRepository,ICourtCaseRepository courtCaseRepository, attorneyPetrovicContext context)
        {
            _logger = logger;
            _context = context;
            _courtCaseRepository = courtCaseRepository;
            _courtCodeRepository = courtCodeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }




        //upisivanje podataka u bazu kad json stigne na api
        [HttpPost]
        [Route("api/myurl")]
        public IActionResult AddSubject([FromBody] JObject _newData)
        {


            /////////////////////////////

            if (_newData == null)
            {
                return BadRequest("nevazeci json podatak");
            }

            try
            {
                //derserijalizacija json podatka u objekat
                var newData = _newData.ToObject<CourtCase>();
                //dodajemo objekat u dbcontext
                _context.CourtCases.Add(newData);
                _context.CourtCodes.Add(newData.CourtCode);

                _logger.LogInformation("Ova poruka je zapisana app.log fajl ");
                _logger.LogInformation("---------------------------------------------------------------------------------------");
                //cuvamo promene u bazu
                _context.SaveChanges();


                return Ok(newData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest("neuspela deserijalizacija");
            }


        }





        [HttpGet]
        [Route("api/myurl")]
        public IActionResult GetCases()
        {
            var allCases = ReadCasesFromDB();
            return new JsonResult(allCases);
        }

        private List<CourtCase> ReadCasesFromDB() 
        {
            var ss = _context.CourtCases.ToList();



            return ss;
        }




    }
}


