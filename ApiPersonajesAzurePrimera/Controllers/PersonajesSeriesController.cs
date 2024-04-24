using ApiPersonajesAzurePrimera.Models;
using ApiPersonajesAzurePrimera.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesAzurePrimera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesSeriesController : ControllerBase
    {
        private RepositoryPersonajeSerie repo;
        public PersonajesSeriesController(RepositoryPersonajeSerie repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<PersonajeSerie>>> Personajes()
        {
            return await this.repo.GetPersonajes();
        }

        [HttpGet]
        [Route("[action]/{serie}")]
        public async Task<ActionResult<List<PersonajeSerie>>> PersonajesSeries(string serie)
        {
            return await this.repo.GetPersonajesSeries(serie);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Series()
        {
            return await this.repo.GetSeries();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertPersonaje(PersonajeSerie pj)
        {
            await this.repo.InsertPersonajeAsync(pj.IdPersonaje,pj.Nombre,pj.Imagen,pj.Serie);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdatePersonaje(PersonajeSerie pj)
        {
            await this.repo.UpdatePersonajeSerieAsync(pj.IdPersonaje, pj.Nombre, pj.Imagen, pj.Serie);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{idpersonaje}")]
        public async Task<ActionResult> DeletePersonaje(int idpersonaje)
        {
            await this.repo.DeletePersonajeAsync(idpersonaje);
            return Ok();
        }
    }
}
