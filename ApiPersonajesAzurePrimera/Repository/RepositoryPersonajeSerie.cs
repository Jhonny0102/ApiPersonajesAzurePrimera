using ApiPersonajesAzurePrimera.Data;
using ApiPersonajesAzurePrimera.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Numerics;

namespace ApiPersonajesAzurePrimera.Repository
{
    public class RepositoryPersonajeSerie
    {
        private PersonajeSerieContext context;
        public RepositoryPersonajeSerie(PersonajeSerieContext context)
        {
            this.context = context;
        }

        //Metodo devuelve todos los personajes
        public async Task<List<PersonajeSerie>> GetPersonajes()
        {
            return await this.context.PersonajeSeries.ToListAsync();
        }

        //Metodo para buscar por ID
        public async Task<PersonajeSerie> FindPersonaje(int idpersonaje)
        {
            return await this.context.PersonajeSeries.FirstOrDefaultAsync(z => z.IdPersonaje == idpersonaje);
        }

        //Metodo devuelve todas las series
        public async Task<List<string>> GetSeries()
        {
            var consulta = (from datos in this.context.PersonajeSeries

                            select datos.Serie).Distinct();

            return await consulta.ToListAsync();
        }

        //Metodo para devolver los personajes de una serie
        public async Task<List<PersonajeSerie>> GetPersonajesSeries(string serie)
        {
            return await this.context.PersonajeSeries.Where(z => z.Serie == serie).ToListAsync();
        }


        //Metodo crear
        public async Task InsertPersonajeAsync(int idpersonaje, string nombre, string imagen, string serie)
        {
            PersonajeSerie pj = new PersonajeSerie();
            pj.IdPersonaje = idpersonaje;
            pj.Nombre = nombre;
            pj.Imagen = imagen;
            pj.Serie = serie;
            this.context.Add(pj);
            await this.context.SaveChangesAsync();
        }

        //Metodo Actualizar
        public async Task UpdatePersonajeSerieAsync(int idpersonaje, string nombre, string imagen, string serie)
        {
            PersonajeSerie pj = await this.FindPersonaje(idpersonaje);
            pj.IdPersonaje = idpersonaje;
            pj.Nombre = nombre;
            pj.Imagen = imagen;
            pj.Serie = serie;
            await this.context.SaveChangesAsync();
        }

        //Metodo para eliminar
        public async Task DeletePersonajeAsync(int idpersonaje)
        {
            PersonajeSerie pj = await this.FindPersonaje(idpersonaje);
            this.context.Remove(pj);
            await this.context.SaveChangesAsync();
        }
    }
}
