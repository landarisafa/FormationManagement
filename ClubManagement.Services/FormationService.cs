using ClubManagement.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

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

        public Formation GetFormationById(string idFormation)
        {
            var filter = Builders<Formation>.Filter.Eq(x => x.Id, idFormation);
            var result = _context._formations.Find(filter).FirstOrDefault();
            return result;
        }

        public List<Formation> GetListFormations()
        {
            var result = _context._formations.Find(Builders<Formation>.Filter.Empty).ToList();
            return result;
        }
    }
}
