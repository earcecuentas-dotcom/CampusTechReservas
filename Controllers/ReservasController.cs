using Microsoft.AspNetCore.Mvc;

public class ReservasController : Controller
{
	private readonly IReservaRepository _repo;

	public ReservasController(IReservaRepository repo)
	{
		_repo = repo;
	}

	public IActionResult Index()
	{
		return View(_repo.ObtenerTodas());
	}

	// ✅ GET: Create
	public IActionResult Create()
	{
		CargarLaboratorios();
		return View(new Reserva());
	}

	// ✅ POST: Create
	[HttpPost]
	public IActionResult Create(Reserva reserva)
	{
		CargarLaboratorios();

		// Validación manual de horas
		if (reserva.HoraFin <= reserva.HoraInicio)
		{
			ModelState.AddModelError("HoraFin", "La hora de fin debe ser mayor que la hora de inicio.");
		}

		// Validación código repetido
		if (_repo.ExisteCodigo(reserva.CodigoReserva))
		{
			ModelState.AddModelError("CodigoReserva", "Este código de reserva ya existe.");
		}

		if (!ModelState.IsValid)
		{
			return View(reserva);
		}

		_repo.Agregar(reserva);
		return RedirectToAction("Index");
	}

	// ✅ Método reutilizable para enviar los labs
	private void CargarLaboratorios()
	{
		ViewBag.Laboratorios = new string[]
		{
			"Lab-01",
			"Lab-02",
			"Lab-03",
			"Lab-Redes",
			"Lab-IA"
		};
	}
}