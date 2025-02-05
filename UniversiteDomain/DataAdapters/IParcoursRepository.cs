using System.Linq.Expressions;
using UniversiteDomain.Entities;
 
namespace UniversiteDomain.DataAdapters;
 
public interface IParcoursRepository
{
    Task<Parcours> CreateAsync(Parcours entity);
    Task UpdateAsync(Parcours entity);
    Task DeleteAsync(long id);
    Task DeleteAsync(Parcours entity);
    Task<Parcours?> FindAsync(long id);
    Task<Parcours?> FindAsync(params object[] keyValues);
    
    Task<Parcours> AddEtudiantAsync(Parcours parcours, Etudiant etudiant); //done
    Task<Parcours> AddEtudiantAsync(long idParcours, long idEtudiant); //done
    Task<Parcours> AddEtudiantAsync(Parcours ? parcours, List<Etudiant> etudiants); //done
    Task<Parcours> AddEtudiantAsync(long idParcours, long[] idEtudiants); //done
    
    Task<Parcours> AddUeAsync(Parcours parcours, Ue ue); //done
    Task<Parcours> AddUeAsync(long idParcours, long ue); //done
    Task<Parcours> AddUeAsync(Parcours ? idParcours, List<Ue> ue); //done
    Task<Parcours> AddUeAsync(long idParcours, long[] idUes); //done
    
    
    Task<List<Parcours>> FindByConditionAsync(Expression<Func<Parcours, bool>> condition);
    Task<List<Parcours>> FindAllAsync();
    Task SaveChangesAsync();
}
