namespace PSP_Hilos;

public class Jugador
{
    
    private Random _rng = new Random();
    private String[] _opciones = ["Piedra","Papel","Tijeras"];
    private Thread hilo;
    public String opcion { get; set; }
    public String nombre { get; set; }
    
    public Jugador(String nombre)
    {
        this.nombre = nombre;
    }

    public void Start()
    {
        hilo = new Thread(() =>
        {
            opcion = ElegirOpcion();
            Console.WriteLine($"{nombre} saca {opcion}");
        });
        hilo.Start();
    }
    
    public void Esperar()
    {
        hilo.Join();
    }
    
    private String ElegirOpcion()
    {
        return _opciones[_rng.Next(_opciones.Length)];
    }
    
    
    
}