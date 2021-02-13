using ClubManagement.Entities;

namespace ClubManagement.Services
{
    public interface IFormationService
    {
        //List<Formation> GetListFormations();
        //Formation GetFormationById(string idFormation);
        Formation AddFormation(Formation formation);
        //Task<Formation> UpdateFormation(Formation formation);
        //Formation DeleteFormation(string idFormation);
    }
}
