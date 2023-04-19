internal class Program
{
    static Dictionary<int,Cliente> clientesIngresados = new Dictionary<int, Cliente>();
    const double OPCION1 = 15000;
    const double OPCION2 = 30000;
    const double OPCION3 = 10000;
    const double OPCION4 = 40000;
    private static void Main(string[] args)
    {
        
        Console.WriteLine("Ingrese la opción:\ni.Nueva Inscripción\nii.Obtener Estadísticas del Evento\niii.Buscar Cliente\niv.Cambiar entrada de un Cliente\nv.Salir");
    }

        static void NuevaInscripción()
        {
            string dni = ingresarDNI("Ingrese el DNI: ");
            string apellido = ingresarString("Ingrese el apellido: ");
            string nombre = ingresarString("Ingrese el nombre: ");

            double totalAbondado;
            int tipoEntrada = ingresarEntrada("Ingrese el tipo de entrada: \n1. Día 1 , valor a abonar $15000\n2. Día 2, valor a abonar $30000\n3. Día 3, valor a abonar $10000\n4. Full Pass, valor a abonar $40000", out totalAbonado);
            clientesIngresados.Add(Tiquetera.DevolverUltimoID(), new Cliente(dni, apellido, nombre, DateTime.Today, tipoEntrada, totalAbondado));

        }

        static void ObtenerEstadisticasEvento(){
            if(clientesIngresados.Count == 0){
                Console.WriteLine("Cantidad de Clientes inscriptos: " + clientesIngresados.Count + "\nPorcentaje de entradas diferenciadas por tipo respecto al total: " + "\nRecaudación de cada día: " + "Recaudación total: ");
            }
            else{
                Console.WriteLine("Aún no se anotó nadie");
            }
        }

        static void BuscarCliente(){
            int id = ingresarInt("Ingrese al ID del cliente: ");
            if(clientesIngresados.ContainsKey(id)){
                Console.WriteLine("DNI: " + clientesIngresados[id].DNI + "\nApellido: " + clientesIngresados[id].Apellido + "\nNombre: " + clientesIngresados[id].Nombre + "\nFecha de inscripcion: " + clientesIngresados[id].FechaInscripcion + "\nTipo de entrada: " + clientesIngresados[id].TipoEntrada + "\nTotal abondado: " + clientesIngresados[id].TotalAbonado);
            }else{
                Console.WriteLine("Ese ID no existe");
            }
        }

        static void CambiarEntradaCliente(){
            int nuevaEntrada;
            int id = ingresarInt("Ingrese al ID del cliente: ");
            if(clientesIngresados.ContainsKey(id)){
                if(clientesIngresados[id].TotalAbonado == OPCION4){
                    Console.WriteLine("No se puede cambiar la entrada porque es la que mayor precio tiene: " + OPCION4);
                }
                else{
                    nuevaEntrada = ingresarEntrada("Ingrese el tipo de entrada: \n1. Día 1 , valor a abonar $15000\n2. Día 2, valor a abonar $30000\n3. Día 3, valor a abonar $10000\n4. Full Pass, valor a abonar $40000");
                    if(clientesIngresados[id].CambiarEntrada(nuevaEntrada)){
                        clientesIngresados[id].TipoEntrada = nuevaEntrada;
                    }
                    else{
                        Console.WriteLine("No se puede cambiar la entrada porque tiene mayor precio que la entrada a la quiere cambiar");
                    }
                }
            }else{
                Console.WriteLine("Ese ID no existe");
            }
            
        }

        static string ingresarString(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }

        static string ingresarDNI(string mensaje)
        {
            string dni = ingresarString(mensaje);
            while (Convert.ToInt32(dni) < 0)
            {
                Console.WriteLine("ERROR. El ingreso debe ser mayor o igual a cero");
                dni = ingresarString(mensaje);
            }
            return dni;
        }

        static int ingresarInt(string mensaje)
        {
            Console.WriteLine(mensaje);
            return int.Parse(Console.ReadLine());
        }

        static int ingresarEntrada(string mensaje, out double totalAbonado)
        {
            int entrada = ingresarInt(mensaje);
            while (entrada < 1 || entrada > 4)
            {
                Console.WriteLine("ERROR. El ingreso debe estar entre los rangos ofrecidos");
                entrada = ingresarInt(mensaje);
            }
            switch (entrada)
            {
                case 1:
                    totalAbonado = OPCION1;
                    break;

                case 2:
                    totalAbonado = OPCION2;
                    break;

                case 3:
                    totalAbonado = OPCION3;
                    break;

                case 4:
                    totalAbonado = OPCION4;
                    break;
            }
            return entrada;
        }
}