using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;
using TreinamentoApis.Data.Collections;
using TreinamentoApis.Models;

namespace TreinamentoApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuradosController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Curado> _curadosCollection;

        public CuradosController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _curadosCollection = _mongoDB.DB.GetCollection<Curado>(typeof(Curado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarCurado([FromBody] CuradosDto dto)
        {
            var curado = new Curado(dto.QtPessoas, dto.Cidade);

            _curadosCollection.InsertOne(curado);

            return StatusCode(201, "Curado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterCurados()
        {
            var curados = _curadosCollection.Find(Builders<Curado>.Filter.Empty).ToList();

            return Ok(curados);
        }
    }
}
