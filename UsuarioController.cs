using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private static List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarUsuario")]
        public string CadastrarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Add(usuario);

            return "Usuário cadastrado com sucesso!";
        }


        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public string alterarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Where(n => n.Codigo == usuario.Codigo).Select(s =>
            {
                s.Codigo = usuario.Codigo;
                s.Nome = usuario.Nome;
                s.Login = usuario.Login;

                return s;

            }).ToList();

            return "Usuário alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public string ExcluirUsuario(int codigo)
        {
            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo).Select(n => n).First();

            listaUsuarios.Remove(usuario);

            return "Registro excluído com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorCodigo/{codigo}")]
        public UsuarioModel ConsultarUsuario(int codigo)
        {

            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo).Select(n => n).FirstOrDefault();

            return usuario;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarios")]

        public List<UsuarioModel> ConsultarUsuarios()
        {
            return listaUsuarios;
        }
    }
}
