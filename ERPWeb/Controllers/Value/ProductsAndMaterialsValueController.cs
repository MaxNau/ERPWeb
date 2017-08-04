using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ERPWeb.Models;

namespace ERPWeb.Controllers.Value
{
    public class ProductsAndMaterialsController : ApiController
    {
        private ProductsContext db = new ProductsContext();

        // GET: api/ProductsAndMaterialsValue
        public ICollection<SubjectOfLabor> GetSubjectsOfLabor()
        {
            List<SubjectOfLabor> sol = new List<SubjectOfLabor>(db.SubjectsOfLabor.OfType<Material>());
            sol.AddRange(db.SubjectsOfLabor.OfType<Product>());
            var result = db.SubjectsOfLabor.OfType<Product>().OfType<Material>();
            return db.SubjectsOfLabor.ToList();
        }

        public IQueryable<SubjectOfLabor> GetMaterials()
        {
            return db.SubjectsOfLabor.OfType<Material>();
        }

        public ICollection<SubjectOfLabor> GetProductsAndMaterialsCatalog()
        {
            List<SubjectOfLabor> sol = new List<SubjectOfLabor>(db.SubjectsOfLabor.OfType<MaterialCatalogEntry>());
            sol.AddRange(db.SubjectsOfLabor.OfType<Product>());
            return sol;
        }

        public IQueryable<MaterialCatalogEntry> GetMaterialsCatalog()
        {
            return db.SubjectsOfLabor.OfType<MaterialCatalogEntry>();
        }

        // GET: api/ProductsAndMaterials/5
        [ResponseType(typeof(SubjectOfLabor))]
        public IHttpActionResult GetSubjectOfLabor(int id)
        {
            SubjectOfLabor subjectOfLabor = db.SubjectsOfLabor.Find(id);
            if (subjectOfLabor == null)
            {
                return NotFound();
            }

            return Ok(subjectOfLabor);
        }

        // PUT: api/ProductsAndMaterials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubjectOfLabor(int id, SubjectOfLabor subjectOfLabor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectOfLabor.Id)
            {
                return BadRequest();
            }

            db.Entry(subjectOfLabor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectOfLaborExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductsAndMaterials
        [ResponseType(typeof(SubjectOfLabor))]
        public IHttpActionResult PostMaterial(Material material)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubjectsOfLabor.Add(material);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = material.Id }, material);
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.SubjectsOfLabor.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        [ResponseType(typeof(MaterialCatalogEntry))]
        public IHttpActionResult PostMaterialCatalogEntry(MaterialCatalogEntry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubjectsOfLabor.Add(entry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entry.Id }, entry);
        }

        [ResponseType(typeof(Operation))]
        public IHttpActionResult PostOperation(Operation operation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Operations.Add(operation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = operation.Id }, operation);
        }

        // DELETE: api/ProductsAndMaterials/5
        [ResponseType(typeof(SubjectOfLabor))]
        public IHttpActionResult DeleteSubjectOfLabor(int id)
        {
            SubjectOfLabor subjectOfLabor = db.SubjectsOfLabor.Find(id);
            if (subjectOfLabor == null)
            {
                return NotFound();
            }

            db.SubjectsOfLabor.Remove(subjectOfLabor);
            db.SaveChanges();

            return Ok(subjectOfLabor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectOfLaborExists(int id)
        {
            return db.SubjectsOfLabor.Count(e => e.Id == id) > 0;
        }
    }
}