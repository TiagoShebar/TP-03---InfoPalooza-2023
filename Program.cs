internal class Program
{
    static Dictionary<int,Cliente> clientesIngresados = new Dictionary<int, Cliente>();
    static string[] dias = {"Dia 1", "Dia 2", "Dia 3", "Dia 4"};
    static double[] precios = {15000, 30000, 10000, 40000};
    private static void Main(string[] args)
    {
        int menu;
        do{
            menu = ingresarInt("Ingrese la opción:\ni.Nueva Inscripción\nii.Obtener Estadísticas del Evento\niii.Buscar Cliente\niv.Cambiar entrada de un Cliente\nv.Salir");
            switch(menu){
                case 1:
                    NuevaInscripción();
                break;
                
                case 2:
                    ObtenerEstadisticasEvento();
                break;

                case 3: 
                    BuscarCliente();
                break;

                case 4:
                    CambiarEntradaCliente();
                break;
            }
            Console.ReadKey();
            Console.Clear();
        }while(menu != 5);
    }

        static void NuevaInscripción()
        {
            string dni = ingresarDNI("Ingrese el DNI: ");
            string apellido = ingresarString("Ingrese el apellido: ");
            string nombre = ingresarString("Ingrese el nombre: ");
            Console.WriteLine("Ingrese el tipo de entrada: ");
            int tipoEntrada = ingresarEntrada();
            double totalAbonado = ingresarAbonado("Ingrese el total abonado: ", tipoEntrada);
            int ID = Tiquetera.DevolverUltimoID();
            Console.WriteLine("\nSu ID es: " + ID);
            clientesIngresados.Add(ID, new Cliente(dni, apellido, nombre, tipoEntrada, totalAbonado));

        }

        static void ObtenerEstadisticasEvento(){
            if(clientesIngresados.Count > 0){
                double precioTotal = 0;
                int[] entradas = new int[4];
                foreach(int id in clientesIngresados.Keys){
                    entradas[clientesIngresados[id].TipoEntrada-1]++;
                }
                Console.WriteLine("Cantidad de Clientes inscriptos: " + clientesIngresados.Count);
                for(int i = 0; i < entradas.Length; i++){
                    Console.WriteLine();
                    Console.WriteLine(dias[i] + ": \nRepresenta " + (entradas[i]*100)/clientesIngresados.Count + "% del total de entradas\nRecaudó $" + entradas[i]*precios[i]);
                    precioTotal += entradas[i]*precios[i];
                }
                Console.WriteLine("Recaudacion total: " + precioTotal);
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
            int id = ingresarInt("Ingrese el ID del cliente: ");
            if(clientesIngresados.ContainsKey(id)){
                if(clientesIngresados[id].TotalAbonado == precios[3]){
                    Console.WriteLine("No se puede cambiar la entrada porque es la que mayor precio tiene: " + precios[3]);
                }
                else{
                    nuevaEntrada = ingresarEntrada();
                    if(!clientesIngresados[id].CambiarEntrada(nuevaEntrada, calcularTotal(nuevaEntrada))){
                        Console.WriteLine("No se puede cambiar la entrada porque tiene mayor precio que la entrada a la quiere cambiar");
                    }
                    else{
                        Console.WriteLine("Se cambió la entrada");
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

        static int ingresarInt(string mensaje = "")
        {
            Console.WriteLine(mensaje);
            return int.Parse(Console.ReadLine());
        }

        static int ingresarEntrada()
        {
            mostrarOpcionesDias();
            int entrada = ingresarInt();
            while (entrada < 1 || entrada > 4)
            {
                Console.WriteLine("ERROR. El ingreso debe estar entre los rangos ofrecidos");
                mostrarOpcionesDias();
                entrada = ingresarInt();
            }
        
            return entrada;
        }

        static void mostrarOpcionesDias(){
            for(int i = 0; i < dias.Length; i++){Console.WriteLine(dias[i] + ", valor a abonar $" + precios[i]);}
        }

        static double ingresarAbonado(string mensaje, int entrada){
            double total = calcularTotal(entrada);
            Console.WriteLine(mensaje);
            double abonado = double.Parse(Console.ReadLine());
            while(abonado < total){
                Console.WriteLine("ERROR. El pago debe ser igual o mayor al precio de la entrada");
                Console.WriteLine(mensaje);
                abonado = double.Parse(Console.ReadLine());
            }
            if(abonado > total){
                Console.WriteLine("Recibe " + (abonado - total) + " de vuelto");
            }
            return total;
        }

        static double calcularTotal(int entrada){
            double total = 0;
            switch (entrada)
                {
                    case 1:
                        total = precios[0];
                    break;

                    case 2:
                        total = precios[1];
                    break;

                    case 3:
                        total = precios[2];
                    break;

                    case 4:
                        total = precios[3];
                    break;
                }
            return total;
        }
}