using ApiPersonajesAzurePrimera.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAzurePrimera.Data
{
    public class PersonajeSerieContext : DbContext
    {
        public PersonajeSerieContext(DbContextOptions<PersonajeSerieContext> options)
            :base(options)
        {

        }

        public DbSet<PersonajeSerie> PersonajeSeries { get; set; }
    }
}
