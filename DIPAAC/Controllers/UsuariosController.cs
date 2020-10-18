using System;
using System.Linq;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using DIPAAC.Models;
using DIPAAC.Services;
using DIPAAC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace DIPAAC.Controllers
{
    /// <summary>
    ///     Expose methods to interact with users data
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        ///     Ctor.
        /// </summary>
        /// <param name="usuarioRepository">Repository to interact with users data</param>
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        ///     Create a new user
        /// </summary>
        /// <param name="usuario">User to create</param>
        /// <returns>Response according with process status</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(ReturnUserViewModel), Status200OK)]
        [ProducesResponseType(typeof(Response), Status400BadRequest)]
        [ProducesResponseType(Status401Unauthorized)]
        [HttpPost("Register")]
        public ActionResult<ReturnUserViewModel> CreateUser(CreateUsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (!usuario.Contraseña.Equals(usuario.ContraseñaConfirmada))
                    return BadRequest(new Response
                    {
                        Code = Models.Response.ResponseCode.Error.ToString(),
                        Message = "Error: Las contraseñas no coinciden",
                        Description = "Contraseña y ContraseñaConfirmada son diferentes"
                    });

                var encryptedPassword = EncryptionService.GetSHA256(usuario.Contraseña);

                var userToCreate = new Usuario
                {
                    NombreUsuario = usuario.NombreUsuario,
                    NombreCompleto = usuario.NombreCompleto,
                    Edad = usuario.Edad,
                    Contraseña = encryptedPassword
                };

                _usuarioRepository.AddUsuario(userToCreate);

                return Ok(new ReturnUserViewModel
                {
                    Id = userToCreate.Id,
                    Edad = userToCreate.Edad,
                    NombreCompleto = userToCreate.NombreCompleto,
                    NombreUsuario = userToCreate.NombreUsuario
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

        /// <summary>
        ///     Log in the user against the data base
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">User password</param>
        /// <returns>Response according with process status</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(UsuarioViewModel), Status200OK)]
        [ProducesResponseType(typeof(Response), Status400BadRequest)]
        [ProducesResponseType(Status401Unauthorized)]
        [HttpPost("Login")]
        public ActionResult<Response> Login([FromForm] string userName, [FromForm] string password)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                    return BadRequest(new Response
                    {
                        Code = Models.Response.ResponseCode.Error.ToString(),
                        Message = "Error: Credenciales inválidas",
                        Description = "UserName o Password es nulo"
                    });

                var user = _usuarioRepository.GetUsuarioByUserName(userName).FirstOrDefault();

                if (user == null)
                    return BadRequest(new Response
                    {
                        Code = Models.Response.ResponseCode.Error.ToString(),
                        Message = "Error: El usuario no existe o no se pudo encontrar",
                        Description = "User es nulo"
                    });

                var encryptedPassword = EncryptionService.GetSHA256(password);

                if (user.Contraseña.Equals(encryptedPassword))
                    return Ok(new ReturnUserViewModel
                    {
                        Id = user.Id,
                        Edad = user.Edad,
                        NombreCompleto = user.NombreCompleto,
                        NombreUsuario = user.NombreUsuario
                    });

                return BadRequest(new Response
                {
                    Code = Models.Response.ResponseCode.Error.ToString(),
                    Message = "Error: Contraseña incorrecta",
                    Description = "EncryptedPassword es diferente a password"
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

        /// <summary>
        ///     Retrieve a user's password
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">User password</param>
        /// <returns>Response according with process status</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Response), Status200OK)]
        [ProducesResponseType(typeof(Response), Status400BadRequest)]
        [ProducesResponseType(Status401Unauthorized)]
        [HttpPost("RecoverPassword")]
        public ActionResult<Response> RecoverPassword([FromForm] string userName, [FromForm] string password)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                    return BadRequest(new Response
                    {
                        Code = Models.Response.ResponseCode.Error.ToString(),
                        Message = "Error: Credenciales inválidas",
                        Description = "UserName o Password es nulo"
                    });

                var user = _usuarioRepository.GetUsuarioByUserName(userName).FirstOrDefault();

                if (user == null)
                    return BadRequest(new Response
                    {
                        Code = Models.Response.ResponseCode.Error.ToString(),
                        Message = "Error: El usuario no existe o no se pudo encontrar",
                        Description = "User es nulo"
                    });

                var encryptedPassword = EncryptionService.GetSHA256(password);

                user.Contraseña = encryptedPassword;

                _usuarioRepository.UpdateUsuario(user);

                return Ok(new ReturnUserViewModel
                {
                    Id = user.Id,
                    Edad = user.Edad,
                    NombreCompleto = user.NombreCompleto,
                    NombreUsuario = user.NombreUsuario
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

        /// <summary>
        ///     Update an user
        /// </summary>
        /// <param name="usuario">User to update</param>
        /// <returns>Response according with process status</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(ReturnUserViewModel), Status200OK)]
        [ProducesResponseType(typeof(Response), Status400BadRequest)]
        [ProducesResponseType(Status401Unauthorized)]
        [HttpPost("Update")]
        public ActionResult<ReturnUserViewModel> UpdateUser(UpdateUsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = _usuarioRepository.GetUsuarioById(usuario.Id).FirstOrDefault();

                if (user == null)
                    return BadRequest(new Response
                    {
                        Code = Models.Response.ResponseCode.Error.ToString(),
                        Message = "Error: El usuario no existe o no se pudo encontrar",
                        Description = "User es nulo"
                    });

                user.NombreCompleto = usuario.NombreCompleto;
                user.NombreUsuario = usuario.NombreUsuario;
                user.Edad = usuario.Edad;

                if (!string.IsNullOrEmpty(usuario.Contraseña) && !string.IsNullOrEmpty(usuario.ContraseñaConfirmada))
                {
                    if (!usuario.Contraseña.Equals(usuario.ContraseñaConfirmada))
                        return BadRequest(new Response
                        {
                            Code = Models.Response.ResponseCode.Error.ToString(),
                            Message = "Error: Las contraseñas no coinciden",
                            Description = "Contraseña y ContraseñaConfirmada son diferentes"
                        });

                    var encryptedPassword = EncryptionService.GetSHA256(usuario.Contraseña);

                    user.Contraseña = encryptedPassword;
                }

                _usuarioRepository.UpdateUsuario(user);

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