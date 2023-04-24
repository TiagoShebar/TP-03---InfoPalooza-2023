class Cliente{
    public string DNI {get;private set;}
    public string Apellido {get;private set;}
    public string Nombre {get;private set;}
    public DateTime FechaInscripcion {get; private set;}
    public int TipoEntrada {get; private set;}
    public double TotalAbonado {get; private set;}

    public Cliente(string dni, string apellido, string nombre, int tipoEntrada, double totalAbonado){
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaInscripcion = DateTime.Now;
        TipoEntrada = tipoEntrada;
        TotalAbonado = totalAbonado;
    }

    public bool CambiarEntrada(int nuevaEntrada, double nuevoTotal){
        bool seCambia;
        if(nuevoTotal > TotalAbonado){
            TipoEntrada = nuevaEntrada;
            TotalAbonado = nuevoTotal;
            FechaInscripcion = DateTime.Now;
            seCambia = true;
        }
        else{
            seCambia = false;
        }
        return seCambia;
    }
}