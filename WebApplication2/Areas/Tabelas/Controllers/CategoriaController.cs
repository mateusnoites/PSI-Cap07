using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Modelo.Tabelas;
using Serviço.Cadastros;
using Serviço.Tabelas;

namespace WebApplication2.Areas.Tabelas.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaServiço servicoCategoria = new CategoriaServiço();
        //private EFContext context = new EFContext();
        /* private static IList<Categoria> categorias = new List<Categoria>()
 {
 new Categoria() { CategoriaId = 1, Nome = "Notebooks"},
 new Categoria() { CategoriaId = 2, Nome = "Monitores"},
 new Categoria() { CategoriaId = 3, Nome = "Impressoras"},
 new Categoria() { CategoriaId = 4, Nome = "Mouses"},
 new Categoria() { CategoriaId = 5, Nome = "Desktops"}
 };*/
        // GET: Categoria
        public ActionResult Index()
        {
            //return View(categorias);
            return View(servicoCategoria.ObterCategoriasClassificadasPorNome());
        }
        // GET: Categorias
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            /*categorias.Add(categoria);
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;*/
            //context.Categorias.Add(categoria);
            //context.SaveChanges();
            servicoCategoria.GravarCategoria(categoria);
            return RedirectToAction("Index");
        }
    
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Categoria categoria = context.Categorias.Find(id);
            Categoria categoria = servicoCategoria.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
            /*categorias.Where(m => m.CategoriaId == id).First()*/
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                //context.Entry(categoria).State = EntityState.Modified;
                // context.SaveChanges();
                servicoCategoria.GravarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
            /*categorias.Remove(
            categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");*/
        }
         public ActionResult Details(long? id)
        {
            /*return View(categorias.Where(m => m.CategoriaId == id).First());*/
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Categoria categoria = context.Categorias.Find(id);
            //Categoria categoria= context.Categorias.Where(f => f.CategoriaId == id).Include("Produtos.Fabricante").First();
            Categoria categoria = servicoCategoria.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Categoria categoria = context.Categorias.Find(id);
            Categoria categoria = servicoCategoria.ObterCategoriaPorId((long)id);
            if(categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
            /*return View(categorias.Where(m => m.CategoriaId == id).First());*/
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            //Categoria categoria = context.Categorias.Find(id);
            Categoria categoria = servicoCategoria.ObterCategoriaPorId((long)id);
            //context.Categorias.Remove(categoria);
            //context.SaveChanges();
            servicoCategoria.EliminarCategoriaPorId(id);
            TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removida";
            return RedirectToAction("Index");
            /*categorias.Remove(
            categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");*/
        }
    }
}