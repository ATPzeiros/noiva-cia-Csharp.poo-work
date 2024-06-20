class InputReader
{
    public static int LerIntZeroOuMaiorTeclado(string text)
    {
        do
        {
            try
            {
                Console.Write(text);
                int input = int.Parse(Console.ReadLine() ?? "0");
                if (input <= 0)
                {
                    throw new ZeroValueException();
                }
                return input;
            }
            catch (ZeroValueException)
            {
                Console.WriteLine("Valor precisa ser maior do que ZERO.\nPressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("Valor não reconhecido.\nPressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
            }
        } while (true);
    }

    public static int LetIntPositivoTeclado(string text){
        do
        {
            try
            {
                Console.Write(text);
                int input = int.Parse(Console.ReadLine() ?? "0");
                if (input < 0)
                {
                    throw new ZeroValueException();
                }
                return input;
            }
            catch (ZeroValueException)
            {
                Console.WriteLine("Valor precisa ser maior do que ZERO.\nPressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("Valor não reconhecido.\nPressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Console.Clear();
            }
        } while (true);
    }

    public static T SelecionarDaLista<T>(string text, List<T> items)
    {
        int cursorPosition = 0;
        ConsoleKeyInfo keyInfo;

        do
        {
            int index = 0;
            
            Console.Clear();
            Console.WriteLine(text);

            items.ForEach(item =>
            {
                if (cursorPosition == index)
                {
                    Console.WriteLine($"> {item?.ToString()}");
                } else {
                    Console.WriteLine($"  {item?.ToString()}");
                }
                index++;
            });

            
            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow && cursorPosition - 1 >= 0)
            {
                cursorPosition--;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow && cursorPosition + 1 < items.Count)
            {
                cursorPosition++;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                return items[cursorPosition];
            }
        } while (true);
    }
}