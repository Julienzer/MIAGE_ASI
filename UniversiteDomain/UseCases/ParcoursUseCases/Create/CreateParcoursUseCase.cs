using UniversiteDomain.DataAdapters;
using UniversiteDomain.DataAdapters.DataAdaptersFactory;
using UniversiteDomain.Entities;
using UniversiteDomain.Exceptions.ParcoursExceptions;

namespace UniversiteDomain.UseCases.ParcoursUseCases.Create;

public class CreateParcoursUseCase(IRepositoryFactory repositoryFactory)
{
    public async Task<Parcours> ExecuteAsync(string NomParcours, int AnneeFormation)
    {
        var parcours = new Parcours{NomParcours = NomParcours, AnneeFormation = AnneeFormation};
        return await ExecuteAsync(parcours);
    }

    public async Task<Parcours> ExecuteAsync(Parcours parcours)
    {
        await CheckBusinessRules(parcours);
        Parcours p = await repositoryFactory.ParcoursRepository().CreateAsync(parcours);
        repositoryFactory.SaveChangesAsync().Wait();
        return p;
    }
    private async Task CheckBusinessRules(Parcours parcours)
    {
        ArgumentNullException.ThrowIfNull(parcours);
        ArgumentNullException.ThrowIfNull(parcours.Id);
        ArgumentNullException.ThrowIfNull(parcours.NomParcours);
        ArgumentNullException.ThrowIfNull(parcours.AnneeFormation);
        ArgumentNullException.ThrowIfNull(repositoryFactory.ParcoursRepository());
        
        // On recherche un parcours avec le même nom de parcours
        List<Parcours> existe = await repositoryFactory.ParcoursRepository().FindByConditionAsync(e=>e.NomParcours.Equals(parcours.NomParcours));
        // Si un parcours avec le même nom existe déjà, on lève une exception personnalisée
        if (existe .Any()) throw new DuplicateNomParcoursException(parcours.NomParcours+ " - ce Nom de parcours est déjà affecté à un parcours");
        // Vérification de l'année de formation
        if (parcours.AnneeFormation < 1 && parcours.AnneeFormation > 2) throw new InvalidAnneeFormationException(parcours.AnneeFormation + " - Année de formation incorrecte");
        // On vérifie si l'année de formation est déjà utilisée
        existe = await repositoryFactory.ParcoursRepository().FindByConditionAsync(p=>p.AnneeFormation.Equals(parcours.AnneeFormation));
        // Une autre façon de tester la vacuité de la liste
        if (existe is {Count:>0}) throw new DuplicateAnneeFormationException(parcours.AnneeFormation +" est déjà affecté à un parcours");
        
    }
}