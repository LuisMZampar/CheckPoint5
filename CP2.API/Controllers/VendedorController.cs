using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas aos vendedores.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        /// <summary>
        /// Construtor do VendedorController.
        /// </summary>
        /// <param name="applicationService">Serviço de aplicação de vendedor.</param>
        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Obtém todos os vendedores cadastrados.
        /// </summary>
        /// <returns>Lista de vendedores.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VendedorEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosVendedores();

            if (objModel != null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados.");
        }

        /// <summary>
        /// Obtém um vendedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do vendedor a ser consultado.</param>
        /// <returns>Vendedor correspondente ao ID informado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterVendedorPorId(id);

            if (objModel != null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados.");
        }

        /// <summary>
        /// Adiciona um novo vendedor.
        /// </summary>
        /// <param name="entity">Dados do vendedor a ser adicionado.</param>
        /// <returns>Vendedor criado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] VendedorDto entity)
        {
            try
            {
                var vendedorEntity = new VendedorEntity
                {
                    Nome = entity.Nome,
                    Email = entity.Email,
                    Telefone = entity.Telefone,
                    DataNascimento = entity.DataNascimento,
                    Endereco = entity.Endereco,
                    DataContratacao = entity.DataContratacao,
                    ComissaoPercentual = entity.ComissaoPercentual,
                    MetaMensal = entity.MetaMensal,
                    CriadoEm = DateTime.UtcNow
                };

                var objModel = _applicationService.SalvarDadosVendedor(vendedorEntity);

                if (objModel != null)
                    return Ok(objModel);

                return BadRequest("Não foi possível salvar os dados.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Atualiza os dados de um vendedor existente.
        /// </summary>
        /// <param name="id">ID do vendedor a ser atualizado.</param>
        /// <param name="entity">Dados atualizados do vendedor.</param>
        /// <returns>Vendedor atualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Put(int id, [FromBody] VendedorDto entity)
        {
            try
            {
                var vendedorEntity = new VendedorEntity
                {
                    Id = id,
                    Nome = entity.Nome,
                    Email = entity.Email,
                    Telefone = entity.Telefone,
                    DataNascimento = entity.DataNascimento,
                    Endereco = entity.Endereco,
                    DataContratacao = entity.DataContratacao,
                    ComissaoPercentual = entity.ComissaoPercentual,
                    MetaMensal = entity.MetaMensal,
                    CriadoEm = entity.CriadoEm
                };

                var objModel = _applicationService.EditarDadosVendedor(id, vendedorEntity);

                if (objModel != null)
                    return Ok(objModel);

                return BadRequest("Não foi possível atualizar os dados.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Exclui um vendedor pelo ID.
        /// </summary>
        /// <param name="id">ID do vendedor a ser excluído.</param>
        /// <returns>Confirmação de exclusão do vendedor.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosVendedor(id);

            if (objModel != null)
                return Ok(objModel);

            return BadRequest("Não foi possível deletar os dados.");
        }
    }
}