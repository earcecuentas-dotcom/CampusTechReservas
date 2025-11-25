using System;
using System.ComponentModel.DataAnnotations;

public class Reserva
{
	[Required(ErrorMessage = "El nombre del profesor es obligatorio")]
	[MinLength(3, ErrorMessage = "Debe tener mínimo 3 caracteres")]
	public string NombreProfesor { get; set; }

	[Required(ErrorMessage = "El correo es obligatorio")]
	[EmailAddress(ErrorMessage = "Correo inválido")]
	[RegularExpression(@"^[a-zA-Z0-9._%+-]+@campus\.edu$", ErrorMessage = "Debe usar correo @campus.edu")]
	public string CorreoInstitucional { get; set; }

	[Required(ErrorMessage = "Debe seleccionar un laboratorio")]
	public string LaboratorioSeleccionado { get; set; }   // 👈 STRING

	[Required(ErrorMessage = "La fecha es obligatoria")]
	[DataType(DataType.Date)]
	public DateTime FechaReserva { get; set; }

	[Required(ErrorMessage = "La hora de inicio es obligatoria")]
	public TimeSpan HoraInicio { get; set; }

	[Required(ErrorMessage = "La hora de fin es obligatoria")]
	public TimeSpan HoraFin { get; set; }

	[Required(ErrorMessage = "El motivo es obligatorio")]
	[MinLength(5, ErrorMessage = "El motivo debe tener mínimo 5 caracteres")]
	[MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
	public string Motivo { get; set; }

	[Required(ErrorMessage = "El código es obligatorio")]
	[RegularExpression(@"^RES-\d{3}$", ErrorMessage = "Formato válido: RES-001")]
	public string CodigoReserva { get; set; }
}
