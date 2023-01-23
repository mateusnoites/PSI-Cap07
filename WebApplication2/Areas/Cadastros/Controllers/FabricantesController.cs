using Modelo.Cadastro;
using Serviço.Cadastros;
using Serviço.Tabelas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Areas.Cadastros.Controllers
{
    public class FabricantesController : Controller
    {
        private FabricanteServico fabricanteServico = new FabricanteServico();


        // GET: Fabricantes
        public ActionResult Index()
        {
            //return View(fabricantes.OrderBy(c => c.Nome));
            return View(fabricanteServico.ObterFabricantesClassificadosPorNome());
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            //fabricantes.Add(fabricante);
            //fabricante.FabricanteId = fabricantes.Select(m => m.FabricanteId).Max() + 1;
            //context.Fabricantes.Add(fabricante);
            //context.SaveChanges();
            fabricanteServico.GravarFabricante(fabricante);
            return RedirectToAction("Index");
        }

        // GET: Fabricantes/Edit/5
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = context.Fabricantes.Find(id);
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                //fabricantes.Remove(
                //fabricantes.Where(c => c.FabricanteId == fabricante.FabricanteId).First());
                //fabricantes.Add(fabricante);
                //context.Entry(fabricante).State = EntityState.Modified;
                fabricanteServico.GravarFabricante(fabricante);
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }
        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = context.Fabricantes.Find(id);
            //Fabricante fabricante = context.Fabricantes.Where(f => f.FabricanteId == id).Include("Produtos.Categoria").First();
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        // GET: Fabricantes/Delete/5
         public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = context.Fabricantes.Find(id);
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
        // POST: Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            //Fabricante fabricante = context.Fabricantes.Find(id);
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            //fabricantes.Remove(
            //fabricantes.Where(c => c.FabricanteId == fabricante.FabricanteId).First());
            //context.Fabricantes.Remove(fabricante);
            //context.SaveChanges();
            fabricanteServico.EliminarFabricantePorId((long)id);
            TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}