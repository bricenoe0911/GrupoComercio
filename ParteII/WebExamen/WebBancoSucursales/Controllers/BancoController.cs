using BEntities;
using BLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBancoSucursales.ViewModels;

namespace WebBancoSucursales.Controllers
{
    public class BancoController : Controller
    {
        //
        // GET: /Banco/

        public ActionResult Index()
        {
            var viewModel = new List<BancoVM>();
            var lista = new BLBanco().ListarBancos();

            if (lista != null && lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    viewModel.Add(new BancoVM()
                    {
                        IdBanco = item.IdBanco,
                        Nombre = item.Nombre,
                        Direccion = item.Direccion,
                        FechaRegistro = item.FechaRegistro
                    });
                }
            }

            return View(viewModel);
        }

        public ActionResult Administrar(int? idBanco)
        {
            var viewModel = new BancoVM();
            if (idBanco.HasValue)
            {
                var banco = new BLBanco().BuscarxId(idBanco.Value);

                if (banco != null)
                {
                    viewModel.IdBanco = banco.IdBanco;
                    viewModel.Nombre = banco.Nombre;
                    viewModel.Direccion = banco.Direccion;
                    viewModel.FechaRegistro = banco.FechaRegistro;

                    var sucursales = new BLSucursal().ListarSucursal(banco.IdBanco);
                    if (sucursales != null && sucursales.Count > 0)
                    {
                        foreach (var item in sucursales)
                        {
                            viewModel.Sucursales.Add(new SucursalVM()
                            {
                                IdSucursal = item.IdSucursal,
                                IdBanco = item.IdBanco,
                                Nombre = item.Nombre,
                                Direccion = item.Direccion,
                                FechaRegistro = item.FechaRegistro
                            });
                        }
                    }
                }
            }

            return View("Administrar", viewModel);
        }

        [HttpPost]
        public ActionResult Administrar(BancoVM banco)
        {
            var bancoBE = new BEBanco();
            bancoBE.IdBanco = banco.IdBanco.HasValue ? banco.IdBanco.Value : 0;
            bancoBE.Nombre = banco.Nombre;
            bancoBE.Direccion = banco.Direccion;

            var id = new BLBanco().AdministrarBanco(bancoBE);

            if (id > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Administrar", banco);
            }
        }

        public ActionResult Eliminar(int id)
        {
            var viewModel = new BancoVM();
            var banco = new BLBanco().BuscarxId(id);

            if (banco != null)
            {
                viewModel.IdBanco = banco.IdBanco;
                viewModel.Nombre = banco.Nombre;
                viewModel.Direccion = banco.Direccion;
                viewModel.FechaRegistro = banco.FechaRegistro;
            }
            return View("Eliminar", viewModel);
        }

        [HttpPost]
        public ActionResult EliminarBanco(BancoVM banco)
        {
            var respuesta = new BLBanco().EliminarBanco(banco.IdBanco.Value);

            return RedirectToAction("Index");
        }

        public ActionResult ListarSucursalBanco(int idBanco)
        {
            var banco = new BancoVM();
            banco.IdBanco = idBanco;

            var viewModel = new List<SucursalVM>();

            var sucursales = new BLSucursal().ListarSucursal(idBanco);
            if (sucursales != null && sucursales.Count > 0)
            {
                foreach (var item in sucursales)
                {
                    viewModel.Add(new SucursalVM()
                    {
                        IdSucursal = item.IdSucursal,
                        IdBanco = item.IdBanco,
                        Nombre = item.Nombre,
                        Direccion = item.Direccion,
                        FechaRegistro = item.FechaRegistro
                    });
                }
            }

            banco.Sucursales = viewModel;

            return View("ListaSucursal", banco);
        }
        public ActionResult ListarSucursal(SucursalVM sucursal)
        {
            var banco = new BancoVM();
            banco.IdBanco = sucursal.IdBanco;

            var viewModel = new List<SucursalVM>();

            var sucursales = new BLSucursal().ListarSucursal(sucursal.IdBanco);
            if (sucursales != null && sucursales.Count > 0)
            {
                foreach (var item in sucursales)
                {
                    viewModel.Add(new SucursalVM()
                    {
                        IdSucursal = item.IdSucursal,
                        IdBanco = item.IdBanco,
                        Nombre = item.Nombre,
                        Direccion = item.Direccion,
                        FechaRegistro = item.FechaRegistro
                    });
                }
            }

            banco.Sucursales = viewModel;

            return View("ListaSucursal", banco);
        }
        public ActionResult AdministrarSucursal(int? idSucursal, int? idBanco)
        {
            var viewModel = new SucursalVM();
            viewModel.IdBanco = idBanco.HasValue ? idBanco.Value : 0;

            if (idSucursal.HasValue)
            {
                var sucursal = new BLSucursal().BuscarxId(idSucursal.Value);
                if (sucursal != null)
                {
                    viewModel.IdSucursal = sucursal.IdSucursal;
                    viewModel.IdBanco = sucursal.IdBanco;
                    viewModel.Nombre = sucursal.Nombre;
                    viewModel.Direccion = sucursal.Direccion;
                    viewModel.FechaRegistro = sucursal.FechaRegistro;
                }
            }
            return View("AdministrarSucursal", viewModel);
        }

        [HttpPost]
        public ActionResult AdministrarSucursal(SucursalVM sucursal)
        {
            var sucursalBE = new BESucursal();
            sucursalBE.IdSucursal = sucursal.IdSucursal.HasValue ? sucursal.IdSucursal.Value : 0;
            sucursalBE.IdBanco = sucursal.IdBanco;
            sucursalBE.Nombre = sucursal.Nombre;
            sucursalBE.Direccion = sucursal.Direccion;

            //var banco = new BancoVM();
            //banco.IdBanco = sucursal.IdBanco;

            var id = new BLSucursal().Administrar(sucursalBE);

            if (id > 0)
            {
                return RedirectToAction("ListarSucursal", new { idBanco = sucursal.IdBanco });
            }
            else
            {
                return View("AdministrarSucursal");
            }
        }
    }
}
