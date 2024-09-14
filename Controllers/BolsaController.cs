using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bolsaApp.Models;


namespace bolsaApp.Controllers;

public class BolsaController : Controller
{
    private readonly ILogger<BolsaController> _logger;

    public BolsaController(ILogger<BolsaController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(OperacionBolsa model)
    {

        if (ModelState.IsValid)
        {
            // se procesa la operacion
            decimal totalInstrumentos = 0;
            decimal igv = 0;
            decimal comision = 0;

            // Verificar los instrumentos seleccionados
            if (model.SP500) totalInstrumentos += 500;
            if (model.DowJones) totalInstrumentos += 300;
            if (model.BonosUS) totalInstrumentos += 120;

            // Aplicar IGV del 18%
            igv = totalInstrumentos * 0.18m;

            // Calcular la comisión
            comision = model.MontoAbonar <= 300 ? 1 : 3;

            // Calcular el total
            model.IGV = igv;
            model.Comision = comision;
            model.Total = totalInstrumentos + igv + comision;

            return View("Resultado", model);
        }

        return View(model);
    }
}