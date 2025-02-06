using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversiteDomain.DataAdapters.DataAdaptersFactory;
using UniversiteDomain.Entities;
using UniversiteDomain.UseCases.EtudiantUseCases.Create;

namespace UniversiteRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public EtudiantController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        // GET: api/<EtudiantController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EtudiantController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EtudiantController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object value)
        {
            if (value is string)
            {
                // Logique pour la méthode synchrone
                // Si tu veux traiter le cas simple avec une chaîne de caractères (old behaviour)
                return Ok("Traitement pour chaîne de caractères");
            }
            else if (value is Etudiant etudiant)
            {
                // Logique pour la méthode asynchrone
                CreateEtudiantUseCase uc = new CreateEtudiantUseCase(_repositoryFactory);
                await uc.ExecuteAsync(etudiant);
                return Ok("Etudiant créé avec succès");
            }

            return BadRequest("Type de données non supporté");
        }

        // PUT api/<EtudiantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // Implémentation pour PUT (si nécessaire)
        }

        // DELETE api/<EtudiantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Implémentation pour DELETE (si nécessaire)
        }
    }
}
