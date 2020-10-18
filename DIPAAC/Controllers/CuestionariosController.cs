using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using DIPAAC.Models;
using DIPAAC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace DIPAAC.Controllers
{
    /// <summary>
    ///     Expose methods to interact with questionnaires data
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CuestionariosController : ControllerBase
    {
        private readonly ICuestionarioRepository _cuestionarioRepository;

        /// <summary>
        ///     Ctor.
        /// </summary>
        /// <param name="cuestionarioRepository">Repository to interact with questionnaires data</param>
        public CuestionariosController(ICuestionarioRepository cuestionarioRepository)
        {
            _cuestionarioRepository = cuestionarioRepository;
        }

        /// <summary>
        ///     Get a questionnaire by id
        /// </summary>
        /// <param name="id">Questionnaire id</param>
        /// <returns>List of questionnaires</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CuestionarioViewModel), Status200OK)]
        [ProducesResponseType(typeof(Response), Status400BadRequest)]
        [ProducesResponseType(Status401Unauthorized)]
        [HttpGet("{id}")]
        public ActionResult<CuestionarioViewModel> GetById(int id)
        {
            return _cuestionarioRepository.GetCuestionarioById(id).Select(c =>
                new CuestionarioViewModel
                {
                    Id = c.Id,
                    Date = c.Date,
                    Tipo = (TipoCuestionario)c.Tipo,
                    Calificacion = c.Calificacion,
                    UsuarioId = c.UsuarioId,
                    Respuestas = c.Respuestas.Select(r => new RespuestaViewModel
                    {
                        Id = r.Id,
                        CuestionarioId = r.CuestionarioId,
                        Pregunta = r.Pregunta,
                        EsCorrecta = r.EsCorrecta,
                        RespuestaIngresada = r.RespuestaIngresada
                    }).ToList()
                }).FirstOrDefault();
        }

        /// <summary>
        ///     Get questionnaires by user id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>List of questionnaires</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(IList<CuestionarioViewModel>), Status200OK)]
        [ProducesResponseType(typeof(Response), Status400BadRequest)]
        [ProducesResponseType(Status401Unauthorized)]
        [HttpGet("User/{userId}")]
        public ActionResult<IList<CuestionarioViewModel>> Get(int userId)
        {
            return _cuestionarioRepository.GetAllCuestionarios().Where(c => c.UsuarioId == userId).Select(c =>
                new CuestionarioViewModel
                {
                    Id = c.Id,
                    Date = c.Date,
                    Tipo = (TipoCuestionario) c.Tipo,
                    UsuarioId = c.UsuarioId
                }).ToList();
        }

        /// <summary>
        ///     Create a new questionnaire
        /// </summary>
        /// <param name="cuestionario">Questionnaire to create</param>
        /// <returns>Response according with process status</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), Status200OK)]
        [ProducesResponseType(typeof(Response), Status400BadRequest)]
        [ProducesResponseType(Status401Unauthorized)]
        [HttpPost]
        public ActionResult<Response> Post(CreateCuestionarioViewModel cuestionario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var cuestionarioToCreate = new Cuestionario
                {
                    Date = DateTime.Now,
                    Tipo = (byte) cuestionario.Tipo,
                    Calificacion = (byte) (cuestionario.Respuestas.Count(r => r.EsCorrecta) / cuestionario.Respuestas.Count),
                    UsuarioId = cuestionario.UsuarioId,
                    Respuestas = cuestionario.Respuestas.Select(r => new Respuesta
                    {
                        EsCorrecta = r.EsCorrecta,
                        Pregunta = r.Pregunta,
                        RespuestaIngresada = r.RespuestaIngresada
                    }).ToList()
                };

                _cuestionarioRepository.AddCuestionario(cuestionarioToCreate);

                return Ok(new Response
                {
                    Code = Models.Response.ResponseCode.Ok.ToString(),
                    Message = "OK",
                    Description = "OK"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new Response
                {
                    Code = Models.Response.ResponseCode.Error.ToString(),
                    Message = "Error: Ah ocurrido un error",
                    Description = e.Message
                });
            }
        }
    }
}