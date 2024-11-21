using UniversiteDomain.DataAdapters.DataAdaptersFactory;
using UniversiteDomain.Entities;
using UniversiteDomain.Exceptions.UeExceptions;

namespace UniversiteDomain.UseCases.UeUseCases.Create;

public class CreateUeUseCase(IRepositoryFactory repositoryFactory)
{
    public async Task<Ue> ExecuteAsync(string numeroUe, string intitule)
    {
        var UniteEnseignement = new Ue{NumeroUe = numeroUe, Intitule = intitule};
        return await ExecuteAsync(UniteEnseignement);
    }
    public async Task<Ue> ExecuteAsync(Ue ue)
    {
        await CheckBusinessRules(ue);
        Ue u = await repositoryFactory.UeRepository().CreateAsync(ue);
        repositoryFactory.UeRepository().SaveChangesAsync().Wait();
        return u;
    }
    private async Task CheckBusinessRules(Ue ue)
    {
        ArgumentNullException.ThrowIfNull(ue);
        ArgumentNullException.ThrowIfNull(ue.NumeroUe);
        ArgumentNullException.ThrowIfNull(ue.Intitule);
        ArgumentNullException.ThrowIfNull(repositoryFactory.UeRepository());
        
        // On recherche une UE avec le même numéro UE
        List<Ue> existe = await repositoryFactory.UeRepository().FindByConditionAsync(e=>e.NumeroUe.Equals(ue.NumeroUe));
       
        // Si une UE avec le même numéro UE existe déjà, on lève une exception personnalisée
        if (existe != null) throw new DuplicateNumeroUeException(ue.NumeroUe+ " - ce numéro d'UE est déjà affecté à une UE");
        
        // On doit vérifier qu'une UE a un intitulé > à 3 caractères
        if (ue.Intitule.Length < 3) throw new IntituleUeException(ue.Intitule+ " - l'intitulé de l'UE doit contenir au moins 3 caractères");

    }
}