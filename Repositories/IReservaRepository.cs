using System.Collections.Generic;

public interface IReservaRepository
{
	List<Reserva> ObtenerTodas();
	void Agregar(Reserva reserva);
	bool ExisteCodigo(string codigo);
}
