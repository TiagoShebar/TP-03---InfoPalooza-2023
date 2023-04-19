class Cliente{
    public string DNI {get;private set;}
    public string Apellido {get;private set;}
    public string Nombre {get;private set;}
    public DateTime FechaInscripcion {get;private set;}
    public int TipoEntrada {get; set;}
    public double TotalAbonado {get;private set;}

    public Cliente(string dni, string apellido, string nombre, DateTime fechaInscripcion, int tipoEntrada, double totalAbonado){
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaInscripcion = fechaInscripcion;
        TipoEntrada = tipoEntrada;
        TotalAbonado = totalAbonado;
    }

    public bool CambiarEntrada(double nuevaEntrada){
        return nuevaEntrada > TotalAbonado ? true : false;
    }
}