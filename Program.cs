string path = "C:/Lab4/LaboratorioAvengers/inventos.txt";

void CrearArchivo()
{
    int seleccion;

    Console.Clear();
    Console.WriteLine("Esta por crear un nuevo archivo");
    Console.WriteLine("La ruta sugerida es: " + path);
    Console.WriteLine("1. Cambiar ruta");
    Console.WriteLine("2. Continuar");
    Console.WriteLine("3. Cancelar");
    seleccion = Convert.ToInt32(Console.ReadLine());

    switch (seleccion)
    {
        case 1:

            Console.WriteLine("Ingrese la nueva ruta: ");
            path = Console.ReadLine();

            if (File.Exists(path))
            {
                Console.WriteLine("El archivo ya existe");
            }
            else
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Archivo creado con éxito");
            }
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();

            break;

        case 2:
            if (File.Exists(path))
            {
                Console.WriteLine("El archivo ya existe");
            }
            else
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Archivo creado con éxito");
            }
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();

            break;

        case 3:

            break;
    }
}

void AgregarInvento()
{
    string path = "C:/Lab4/LaboratorioAvengers/inventos.txt";
    string invento;
   
    do
    {
    Console.WriteLine("Ingrese el invento que desea agregar: ");
    invento = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(invento))
        {
            Console.WriteLine("Debe ingresar un invento");
        }
    } while (string.IsNullOrWhiteSpace(invento));

    File.AppendAllText(path, invento + Environment.NewLine);
    Console.WriteLine("Invento agregado con éxito");
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
    
}

void LeerTodo()
{
    Console.Clear();
    string[] lineas = File.ReadAllLines(path);
    int c = 0;

    Console.WriteLine("LISTA DE INVENTOS");

    foreach (string linea in lineas)
    {
        c++;
        Console.WriteLine("Invento Numero: " + c + " " + linea);
    }
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
}

void LeerLineaEspecífica()
{
    Console.Clear();
    string[] lineas = File.ReadAllLines(path);
    int seleccion = 0;
    bool entradaValida = false;

    while (!entradaValida)
    {
        Console.WriteLine("Ingrese el número de invento que desea leer: ");
        string entrada = Console.ReadLine();

        try
        {
            seleccion = Convert.ToInt32(entrada);
            entradaValida = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
        }
    }

    if (seleccion > 0 && seleccion <= lineas.Length)
    {
        Console.WriteLine("Invento Numero: " + seleccion + " " + lineas[seleccion - 1]);
    }
    else
    {
        Console.WriteLine("Señor, aun no ha hecho su invento numero " + seleccion);
    }

    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
}

void CopiarArchivo()
{
    Console.Clear();
    string pathorigen = path;
    string pathdestino;
    Console.WriteLine("Ingrese la ruta de destino: ");
    Console.WriteLine("Ruta sugerida : C:/Lab4/LaboratorioAvengers/Backup/inventos_copia.txt");
    pathdestino = Console.ReadLine();

    // Obtener el directorio de destino
    string directorioDestino = Path.GetDirectoryName(pathdestino);

    // Verificar si el directorio de destino existe
    if (!Directory.Exists(directorioDestino))
    {
        Console.WriteLine("La dirección no existe, ¿desea crearla? ");
        Console.WriteLine("1. Sí");
        Console.WriteLine("2. No");
        int seleccion = Convert.ToInt32(Console.ReadLine());
        switch (seleccion)
        {
            case 1:
                CrearCarpeta();
                break;
            case 2:
                Console.WriteLine("Operación cancelada.");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                return;
        }
    }

    // Copiar el archivo al destino especificado
    File.Copy(pathorigen, pathdestino, true);
    Console.WriteLine("Archivo copiado con éxito a: " + pathdestino);
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
}


void MoverArchivo()
{
    Console.Clear();
    string pathorigen = path;
    string pathdestino;
    Console.WriteLine("Ingrese la ruta de destino: ");
    Console.WriteLine("Ruta sugerida : C:/Lab4/LaboratorioAvengers");
    pathdestino = Console.ReadLine();

    File.Move(pathorigen, pathdestino);
    Console.WriteLine("Archivo movido con éxito");
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
}

void CrearCarpeta()
{
    Console.Clear();
    Console.WriteLine("Ingrese el nombre de la carpeta: ");
    string nombre = Console.ReadLine();
    Console.WriteLine("Ingrese la ruta de destino: ");
    Console.WriteLine("Ruta sugerida : C:/Lab4/LaboratorioAvengers");
    string dirpath = Console.ReadLine();

    // Verificar si la ruta del directorio base existe
    if (!Directory.Exists(dirpath))
    {
        Console.WriteLine("La ruta especificada no existe. ¿Desea crearla?");
        Console.WriteLine("1. Sí");
        Console.WriteLine("2. No");
        int seleccion = Convert.ToInt32(Console.ReadLine());
        switch (seleccion)
        {
            case 1:
                Directory.CreateDirectory(dirpath);
                break;
            case 2:
                Console.WriteLine("Operación cancelada.");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                return;
        }
    }


    // Crear la nueva carpeta
    string newDirPath = Path.Combine(dirpath, nombre);
    Directory.CreateDirectory(newDirPath);
    Console.WriteLine("Carpeta creada con éxito en: " + newDirPath);
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
    }

 void ListarArchivos()
{
    Console.Clear();
    string newPath = "C:/Lab4/LaboratorioAvengers";
    string[] files = Directory.GetFiles(newPath);
    Console.WriteLine("LISTA DE ARCHIVOS");
    Console.WriteLine("Ruta: " + newPath);
    Console.WriteLine("Archivos : ");
    foreach (string file in files)
    {
        Console.WriteLine(file);
    }
    Console.WriteLine("Presione cualquier tecla para continuar");
    Console.ReadKey();
}

    while (true)
    {
        int seleccion = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.Clear();
            Console.WriteLine("BIENVENIDO AL SISTEMA DE ORGANIZACIÓN, SR. STARK");
            Console.WriteLine("¿QUÉ DESEA HACER?");
            Console.WriteLine("1. CREAR UN NUEVO ARCHIVO");
            Console.WriteLine("2. AGREGAR UN NUEVO INVENTO");
            Console.WriteLine("3. LEER TODOS LOS INVENTOS");
            Console.WriteLine("4. LEER UN INVENTO");
            Console.WriteLine("5. COPIAR ARCHIVO");
            Console.WriteLine("6. MOVER ARCHIVO");
            Console.WriteLine("7. CREAR CARPETA");
            Console.WriteLine("8. LISTA DE ARCHIVOS");
            Console.WriteLine("9. SALIR");
            string entrada = Console.ReadLine();

            try
            {
                seleccion = Convert.ToInt32(entrada);
                entradaValida = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }

        switch (seleccion)
        {
            case 1:
                CrearArchivo();
                break;
            case 2:
                AgregarInvento();
                break;
            case 3:
                LeerTodo();
                break;
            case 4:
                LeerLineaEspecífica();
                break;
            case 5:
                CopiarArchivo();
            break;
            case 6:
                 MoverArchivo();
                break;
            case 7:
                CrearCarpeta();
            break;
            case 8:
                ListarArchivos();
            break;
            case 9:
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Opción no válida");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                break;
        }
    }
