using Entidades.Clase__25;

public delegate void LimiteSueldoDelegado(double sueldo,Empleado emp);

public delegate void SueldoMejoradoDel(Empleado emp, EmpleadoEventArgs e);

public enum TipoManejador
{
    LimiteSueldo,
    LimiteSueldoMejorado,
    Todos
}