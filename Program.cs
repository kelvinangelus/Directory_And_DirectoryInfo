/*
//CriarDiretoriosGlobo();
//CriarArquivo();

var origem = Path.Combine(Environment.CurrentDirectory,"brasil.txt");
var destino = Path.Combine(Environment.CurrentDirectory,
                    "globo",
                    "América do Sul",
                    "Argentina",
                    "argentina.txt");

//MoverArquivo(origem,destino);
CopiarArquivo(origem, destino); 
*/
var path = @"C:\Dev\Directory_And_DirectoryInfo\globo";
//var path = Path.Combine(Environment.CurrentDirectory,"globo");
//LerDiretorios(path);
LerArquivos(path);
Console.WriteLine("Pressione Enter para finalizar....");
Console.ReadLine();

static void LerArquivos(string path)
{
    var arquivos = Directory.GetFiles(path,"*",SearchOption.AllDirectories);
    foreach(var arquivo in arquivos)
    {
        var fileInfo = new FileInfo(arquivo); //Nova instância da classe FileInfo
        Console.WriteLine($"[Nome]:{fileInfo.Name}");
        Console.WriteLine($"[Tamanho]:{fileInfo.Length}");
        Console.WriteLine($"[Último acesso]:{fileInfo.LastAccessTime}"); 
        Console.WriteLine($"[Pasta]:{fileInfo.DirectoryName}");
        Console.WriteLine("--------------------------");
    }
}

static void LerDiretorios(string path)
{
    if (Directory.Exists(path))
    {
        var diretorios = Directory.GetDirectories(path,"*",SearchOption.AllDirectories);
        foreach(var diretorio in diretorios)
        {
            var dirInfo = new DirectoryInfo(diretorio);
            Console.WriteLine($"[Nome]:{dirInfo.Name}");
            Console.WriteLine($"[Raiz]:{dirInfo.Root}");
            if(dirInfo.Parent != null)
                Console.WriteLine($"[Pai]:{dirInfo.Parent.Name}");
            Console.WriteLine("-----------------------");
        }
    }
}

static void CopiarArquivo(string pathOrigem,string pathDestino)
{
    if(!File.Exists(pathOrigem))
        Console.WriteLine("Arquivo de origem não existe");

    if(File.Exists(pathDestino))
    {
        Console.WriteLine("Arquivo já existe na pasta de destino");
        return;
    }
    File.Copy(pathOrigem,pathDestino);
}

static void MoverArquivo(string pathOrigem, string pathDestino)
{
    if(!File.Exists(pathOrigem))
        Console.WriteLine("Arquivo de origem não existe");

    if(!File.Exists(pathDestino))
    {
        Console.WriteLine("Arquivo já existe na pasta de destino");
        return;
    }

    File.Move(pathOrigem,pathDestino);
}
static void CriarArquivo()
{
    var path = Path.Combine(Environment.CurrentDirectory,"brasil.txt");
    if(!File.Exists(path)) //Verificar se o diretório não existe
    {
        using var sw = File.CreateText(path); //using torna possível a escrita no arquivo sem necessidade do método flush
        sw.WriteLine("População 213MH");
        sw.WriteLine("IDH: 0,901");
        sw.WriteLine("Dados atualizados em: 20/04/2018");

    }
    }
static void CriarDiretoriosGlobo()
{
    var path = Path.Combine(Environment.CurrentDirectory,"globo");
    if(!Directory.Exists(path))
    {
        var dirglobo = Directory.CreateDirectory(path);

        var dirAMNorte = dirglobo.CreateSubdirectory("América do Norte");
        var dirAmCentral = dirglobo.CreateSubdirectory("América Central");
        var dirAmSul = dirglobo.CreateSubdirectory("América do Sul");

        dirAMNorte.CreateSubdirectory("USA");
        dirAMNorte.CreateSubdirectory("Mexico");
        dirAMNorte.CreateSubdirectory("Canada");

        dirAmCentral.CreateSubdirectory("Costa Rica");
        dirAmCentral.CreateSubdirectory("Panama");

        dirAmSul.CreateSubdirectory("Brasil");
        dirAmSul.CreateSubdirectory("Argentina");
        dirAmSul.CreateSubdirectory("Paraguai");

    }
    }
