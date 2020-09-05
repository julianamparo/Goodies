using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Goodies.Models;
using Goodies.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goodies.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        
        Autenticacao autenticacaoServico;
        public ClienteController(IHttpContextAccessor context)
        {
            autenticacaoServico = new Autenticacao(context);
        }
        [HttpGet]
        [Route("clientes")]
        public List<Cliente> ListarClientes()
        {
            return new Cliente().listarClientes();
        }

        [HttpGet]
        [Route("cliente/{id}")]
        public Cliente RetornarCliente(int id)
        {
            return new Cliente().RetornarCliente(id);

        }

        [HttpPost]
        [Route("registrarcliente")]
        public ReturnAllServices RegistrarCliente([FromBody] Cliente dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                dados.RegistrarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;

            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao registrar o cliente: " + ex.Message;
            }
            return retorno;
            
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar (int id, [FromBody]Cliente cliente)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                cliente.Id = id;
                cliente.AtualizarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;

            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao registrar o cliente: " + ex.Message;
            }
            return retorno;
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public ReturnAllServices Excluir (int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                retorno.Result = true;
                autenticacaoServico.Autenticar();
                new Cliente().Excluir(id);
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = ex.Message;
            }
            return retorno;
        }

    }
}
