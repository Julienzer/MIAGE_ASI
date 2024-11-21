using Moq;
using UniversiteDomain.DataAdapters;
using UniversiteDomain.DataAdapters.DataAdaptersFactory;
using UniversiteDomain.Entities;
using UniversiteDomain.UseCases.UeUseCases.Create;

namespace UniversiteDomainUnitTests;

public class UeUnitTests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public async Task CreateUeUseCase()
    {
        long idUe = 1;
        String numeroUe = "Ue 1";
        String intitule = "Intitule 1";
        
        // On crée l'Ue qui doit être ajouté en base
        Ue ueAvant = new Ue{NumeroUe = numeroUe, Intitule = intitule};
        
        // On initialise une fausse datasource qui va simuler un UeRepository
        var mockUe = new Mock<IUeRepository>();
        
        // Il faut ensuite aller dans le use case pour simuler les appels des fonctions vers la datasource
        // Nous devons simuler FindByCondition et Create
        // On dit à ce mock que l'Ue n'existe pas déjà
        mockUe
            .Setup(repo=>repo.FindByConditionAsync(p=>p.Id.Equals(idUe)))
            .ReturnsAsync((List<Ue>)null);
        // On lui dit que l'ajout d'un Ue renvoie un Ue avec l'Id 1
        Ue ueFinal =new Ue{Id=idUe,NumeroUe= numeroUe, Intitule = intitule};
        mockUe.Setup(repo=>repo.CreateAsync(ueAvant)).ReturnsAsync(ueFinal);
        
        var mockFactory = new Mock<IRepositoryFactory>();
        mockFactory.Setup(facto=>facto.UeRepository()).Returns(mockUe.Object);
        
        // Création du use case en utilisant le mock comme datasource
        CreateUeUseCase useCase=new CreateUeUseCase(mockFactory.Object);
        
        // Appel du use case
        var ueTeste=await useCase.ExecuteAsync(ueAvant);
        
        // Vérification du résultat
        Assert.That(ueTeste.Id, Is.EqualTo(ueFinal.Id));
        Assert.That(ueTeste.NumeroUe, Is.EqualTo(ueFinal.NumeroUe));
        Assert.That(ueTeste.Intitule, Is.EqualTo(ueFinal.Intitule));

    }
}