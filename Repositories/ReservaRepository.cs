using System.Collections.Generic;
using System.Linq;

public class ReservaRepository : IReservaRepository
{
	private static List<Reserva> reservas = new List<Reserva>();

	public List<Reserva> ObtenerTodas()
	{
		return reservas;
	}

	public void Agregar(Reserva reserva)
	{
		reservas.Add(reserva);
	}

	public bool ExisteCodigo(string codigo)
	{
		return reservas.Any(r => r.CodigoReserva == codigo);
	}
}
