using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimesheetRestApi.Models;

namespace TimesheetRestApi.Controllerit
{
    [Route("api/[controller]")]
    [ApiController]
    public class TankkauksetController : ControllerBase
    {
        private tuntidbContext context = new tuntidbContext();

        // Hae kaikki tankkaustapahtumat
        [HttpGet]
        [Route("")]
        public List<Tankkaukset> GetAll()
        {
            
                List<Tankkaukset> tankkaukset = context.Tankkaukset.ToList();
                return tankkaukset;
            
        }


        [HttpPost]
        public bool PostStatus(TankkausData Tankkaus)
        {
            try
            {
               int[] aiemmatKilometrit = (from t in context.Tankkaukset                                  
                                   select t.Mittarilukema).ToArray();

                int suurinMittarilukema =  aiemmatKilometrit.Max();

                int ajomaara = Tankkaus.Mittarilukema - suurinMittarilukema;

                decimal kulutusPerKm = (decimal)(Tankkaus.Litraa / ajomaara);

                decimal keskikulutus = kulutusPerKm * 100;

                Tankkaukset uusiTankkaus = new Tankkaukset()
                {
                    Pvm = DateTime.Now,
                    Litraa = Tankkaus.Litraa,
                    Euroa = Tankkaus.Euroa,
                    Reknro = Tankkaus.Reknro,
                    Mittarilukema = Tankkaus.Mittarilukema,
                    Ajomaara = ajomaara,
                    Keskikulutus = keskikulutus
                };

                context.Tankkaukset.Add(uusiTankkaus);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}