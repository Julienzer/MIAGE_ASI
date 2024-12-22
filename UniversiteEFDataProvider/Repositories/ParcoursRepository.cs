using Microsoft.EntityFrameworkCore;
using UniversiteDomain.DataAdapters;
using UniversiteDomain.Entities;
using UniversiteEFDataProvider.Data;

namespace UniversiteEFDataProvider.Repositories;

public class ParcoursRepository(UniversiteDbContext context) : Repository<Parcours>(context), IParcoursRepository
{
    public async Task AjouterUeAsync(long idParcours, long idUe)
    {
        ArgumentNullException.ThrowIfNull(Context.Parcours);
        ArgumentNullException.ThrowIfNull(Context.Ues);
        Parcours p = (await Context.Parcours.FindAsync(idParcours))!;
        Ue ue = (await Context.Ues.FindAsync(idUe))!;
        p.Ues.Add(ue);
        await Context.SaveChangesAsync();
    }
    
    public async Task AjouterUeAsync(Parcours parcours, Ue ue)
    {
        await AjouterUeAsync(parcours.Id, ue.Id);
    }
    
    public async Task SupprimerUeAsync(long idParcours, long idUe)
    {
        ArgumentNullException.ThrowIfNull(Context.Parcours);
        ArgumentNullException.ThrowIfNull(Context.Ues);
        Parcours p = (await Context.Parcours.FindAsync(idParcours))!;
        Ue ue = (await Context.Ues.FindAsync(idUe))!;
        p.Ues.Remove(ue);
        await Context.SaveChangesAsync();
    }
    
    public async Task SupprimerUeAsync(Parcours parcours, Ue ue)
    {
        await SupprimerUeAsync(parcours.Id, ue.Id);
    }
    
    public async Task AffecterResponsableAsync(long idParcours, long idEnseignant)
    {
        ArgumentNullException.ThrowIfNull(Context.Parcours);
        ArgumentNullException.ThrowIfNull(Context.Enseignants);
        Parcours p = (await Context.Parcours.FindAsync(idParcours))!;
        Enseignant e = (await Context.Enseignants.FindAsync(idEnseignant))!;
        p.Responsable = e;
        await Context.SaveChangesAsync();
    }
}