using System.Security.AccessControl;
using UniversiteDomain.DataAdapters;
using UniversiteDomain.Entities;
using UniversiteEFDataProvider.Data;

namespace UniversiteEFDataProvider.Repositories;

public class EtudiantRepository(UniversiteDbContext context) : Repository<Etudiant>(context), IEtudiantRepository
{
    public async Task<Etudiant> AffecterParcoursAsync(long idEtudiant, long idParcours)
    {
        ArgumentNullException.ThrowIfNull(Context.Etudiants);
        ArgumentNullException.ThrowIfNull(Context.Parcours);
        Etudiant e = (await Context.Etudiants.FindAsync(idEtudiant))!;
        Parcours p = (await Context.Parcours.FindAsync(idParcours))!;
        e.ParcoursSuivi = p;
        await Context.SaveChangesAsync();
        return e;
    }
    
    public async Task<Etudiant> AffecterParcoursAsync(Etudiant etudiant, Parcours parcours)
    {
        Etudiant e = (await Context.Etudiants.FindAsync(etudiant.Id))!;
        await AffecterParcoursAsync(etudiant.Id, parcours.Id); 
        return e;
    }
}