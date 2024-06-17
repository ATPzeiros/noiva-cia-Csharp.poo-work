class Menu{
    public static void MostrarMenu(string[] opcoes, int posicao, string cabecalho){
        Console.Clear();
        ShowMenuLogo();
        Console.WriteLine(cabecalho + "\n");
        for(int i=0; i< opcoes.Length; i++){
            if(opcoes[i] != "" ){
                if(posicao == i){
                    Console.Write(">");
                    Console.WriteLine(opcoes[i]);
                } else {
                    Console.WriteLine(" " + opcoes[i]);
                }
            }
        }
    }

    public static void ShowMenuLogo() {
        string menuArt = File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/src/logo.txt");
        Console.WriteLine(menuArt);
    }
}