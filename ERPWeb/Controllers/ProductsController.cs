using ERPWeb.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ERPWeb.Controllers.Value
{
    public class ProductsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [ResponseType(typeof(SubjectOfLabor))]
        public IHttpActionResult PostProduct(SubjectOfLabor product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (ProductsContext context = new ProductsContext())
            {
                context.SubjectsOfLabor.Add(product);
                context.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}