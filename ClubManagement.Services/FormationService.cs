using ClubManagement.Entities;
using Microsoft.Extensions.Options;

namespace ClubManagement.Services
{
    public class FormationService : IFormationService
    {
        private readonly DbContext _context = null;

        public FormationService(IOptions<DbSettings> settings)
        {
            _context = new DbContext(settings.Value);
        }

        public Formation AddFormation(Formation formation)
        {
            _context._formations.InsertOne(formation);
            return formation;
        }
    }
}
