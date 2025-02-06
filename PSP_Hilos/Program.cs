namespace PSP_Hilos;

static class Program
{
    private static Jugador[] _jugadores = new Jugador[16];

    static void Main()
    {
        Console.WriteLine("Torneo de Piedra, Papel o Tijeras con 16 jugadores!\n");
        
        // poblar la lista
        for (int i = 0; i < 16; i++)
        {
            _jugadores[i] = new Jugador($"Jugador {i + 1}");
        }
        
        
        
        //Console.WriteLine(ElegirGanador(_jugadores[0],_jugadores[1]));
        Jugador ganador = JugarTorneo();
        
        Console.WriteLine($"El ganador del torneo ha sido {ganador.nombre}");
        
    }


    private static Jugador JugarTorneo()
    {
        int ronda = 1;
        
        while (_jugadores.Length > 1)
        {
            Console.WriteLine($"Ronda {ronda}, {_jugadores.Length} restantes \n\n");
            Jugador[] ganadores = new Jugador[_jugadores.Length / 2];

            int indexCont = 0;
            for (int i = 0; i < _jugadores.Length; i+= 2)
            {
                
                ganadores[indexCont] = ElegirGanador(_jugadores[i],_jugadores[i + 1]);
                indexCont++;
            }
            
            _jugadores = ganadores;
            ronda++;
        }

        return _jugadores[0];
    }

    private static Jugador ElegirGanador(Jugador jugador1, Jugador jugador2)
    {
        
        Console.WriteLine($"Partida: {jugador1.nombre} vs {jugador2.nombre}");
        
        jugador1.Start();
        jugador2.Start();
        
        jugador2.Esperar();

        if (jugador1.opcion == jugador2.opcion)
        {
            Console.WriteLine("Empate, se jugara otra");
            return ElegirGanador(jugador1, jugador2);
        }

        if ((jugador1.opcion == "Piedra" && jugador2.opcion == "Tijeras") ||
            (jugador1.opcion == "Papel" && jugador2.opcion == "Piedra") ||
            (jugador1.opcion == "Tijeras" && jugador2.opcion == "Papel"))
        {
            Console.WriteLine($"{jugador1.nombre} gana con {jugador1.opcion}\n");
            return jugador1;
        }
        else
        {
            Console.WriteLine($"{jugador2.nombre} gana con {jugador2.opcion}\n");
            return jugador2;
        }

    }

}

