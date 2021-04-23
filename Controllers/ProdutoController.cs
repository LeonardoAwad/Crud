using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.CLASSES.NEGOCIOS;
using Crud.CLASSES.TRANSPORTE;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IConfiguration _configuration;
        public ProdutoController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ListaProduto")]
        public ActionResult ListaProduto([FromBody] JObject jObject)
        {
            try
            {


                List<Produto> listaProduto = new List<Produto>();

                listaProduto = Negocios.ListaProduto();
                return Ok(listaProduto);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("InsereProduto")]
        public ActionResult InsereProduto([FromBody] JObject jObject)
        {
            try
            {

                Produto produto;

                try
                {
                    produto = jObject["produto"].ToObject<Produto>();

                }
                catch (Exception)
                {
                    return BadRequest("Produto não enviado");

                }


                produto.Insere();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //AlteraProduto
        [HttpPost("AlteraProduto")]
        public ActionResult AlteraProduto([FromBody] JObject jObject)
        {
            try
            {

                Produto produto;

                try
                {
                    produto = jObject["produto"].ToObject<Produto>();

                }
                catch (Exception)
                {
                    return BadRequest("Produto não enviado");

                }


                produto.UpDate();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //ExcluirProduto
        [HttpPost("ExcluirProduto")]
        public ActionResult ExcluirProduto([FromBody] JObject jObject)
        {
            try
            {

                Produto produto;

                try
                {
                    produto = jObject["produto"].ToObject<Produto>();

                }
                catch (Exception)
                {
                    return BadRequest("Produto não enviado");

                }


                produto.Delete();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}