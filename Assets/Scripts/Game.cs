using System.Collections;
using System.Collections.Generic;


public class Game
{

    public static Game current;

    public NivelModel nivel;

    public Game()
    {
        nivel = new NivelModel();
    }
}


public class NivelModel
{
    public string nivel;

    public NivelModel()
    {
        nivel = "";
    }
}
