using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Instan conection
       Context.Conex conex = new Context.Conex();

        // GET: api/<ProductController>
        [HttpGet]
        public List<Models.productModel> Get()
        {
            var ds = conex.ConsultarSP("sp_viewAll");
            var datos = ds.Tables[0].AsEnumerable().Select(dataRow => new Models.productModel
            {
                prd_id = dataRow["prd_id"].ToString()
                 ,
                prd_name = dataRow["prd_name"].ToString()
                ,
                prd_category = dataRow["prd_category"].ToString()
                ,
                prd_price = dataRow["prd_price"].ToString()

            }).ToList();



            return datos ;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Models.productModel GetID(string id)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("prd_id", id));
            var ds = conex.ConsultarSP("sp_viewId", param);
            var datos = ds.Tables[0].AsEnumerable().Select(dataRow => new Models.productModel
            {
                prd_id = dataRow["prd_id"].ToString()
                 ,
                prd_name = dataRow["prd_name"].ToString()
                ,
                prd_category = dataRow["prd_category"].ToString()
                ,
                prd_price = dataRow["prd_price"].ToString()

            }).ToList();

            return datos.Any() ? datos[0] : null;
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
