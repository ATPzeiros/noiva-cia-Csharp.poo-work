class GerenciadorEspaco{
    private List<Espaco> Lista_espacos {get; set;}

    public GerenciadorEspaco(){
        Lista_espacos = new List<Espaco>(){
            new Espaco("g", 50),
            new Espaco("a", 100),
            new Espaco("b", 100),
            new Espaco("c", 100),
            new Espaco("d", 100),
            new Espaco("e", 200),
            new Espaco("f", 200),
            new Espaco("h", 200),
        };
    }
}