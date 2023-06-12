using System;
using BrazilianDocuments.Validators;

namespace BrazilianDocumentsTester
{
    class Program
    {
        static ConsoleColor corDeFundo = ConsoleColor.Black;
        static ConsoleColor corDeTitulo = ConsoleColor.DarkRed;
        static ConsoleColor corDeTituloDestacado = ConsoleColor.Yellow;
        static ConsoleColor corDeNumero = ConsoleColor.Yellow;
        static ConsoleColor corDeTextoDefault = ConsoleColor.White;
        static ConsoleColor corDeSaida = ConsoleColor.Red;
        static ConsoleColor corDoLogo = ConsoleColor.Cyan;

        static void Main(string[] args)
        {
            CarregarMenuPrincial();
        }

        private static void CarregarMenuPrincial()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.ForegroundColor = corDeTituloDestacado;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                    SELECIONE A ROTINA DE VALIDAÇÃO  /  SELECT THE VALIDATION ROUTINE                     ||");
            Console.WriteLine("+============================================================================================================+");
            Console.ForegroundColor = corDeTextoDefault;
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.WriteLine($"{PintaOpcaoEmDestaque(" 1)")} Testar validação de CPF                            /   Test \"CPF\" validation ");
            Console.WriteLine($"{PintaOpcaoEmDestaque(" 2)")} Testar validação de Título de Eleitor              /   Test \"Voter card\" Validation ");

            Console.WriteLine($"{PintaOpcaoEmDestaque(" 3)")} Testar validação de CNPJ                           /   Test \"CNPJ\" validation ");
            Console.WriteLine($"{PintaOpcaoEmDestaque(" 4)")} Testar validação de PIS/PASEP                      /   Test \"PIS/PASEP\" validation ");
            Console.WriteLine($"{PintaOpcaoEmDestaque(" 5)")} Testar validação de Inscrição Estadual             /   Test \"State Registration\" Validation ");

            Console.WriteLine($"{PintaOpcaoEmDestaque(" 6)")} Testar validação de CNH                            /   Test \"driver's License\" validation ");
            Console.WriteLine($"{PintaOpcaoEmDestaque(" 7)")} Testar validação de RENAVAM                        /   Test \"RENAVAM\" validation ");
            Console.WriteLine($"{PintaOpcaoEmDestaque(" 8)")} Testar validação de placa veicular                 /   Test \"license plate\" validation ");
            
            Console.WriteLine($"{PintaOpcaoEmDestaque(" 9)")} Testar validação de passaporte                     /   Test \"passport\" validation ");
            Console.WriteLine($"{PintaOpcaoEmDestaque(" 0)")} Testar validação de CEP                            /   Test \"zip code\" validation ");
            
            Console.WriteLine("");
            Console.ForegroundColor = corDeSaida;
            Console.WriteLine(" Qualquer outra tecla para sair                        /   Any other key to exit ");
            Console.ForegroundColor = corDeTextoDefault;
            ConsoleKeyInfo tecla = Console.ReadKey();

            switch (tecla.KeyChar)
            {
                case '1':
                    Console.Clear();
                    TestarValidacaoDeCpf();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                case '2':
                    Console.Clear();
                    TestarValidacaoTituloDeEleitor();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                case '3':
                    Console.Clear();
                    TestarValidacaoDeCnpj();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                case '4':
                    Console.Clear();
                    TestarValidacaoPisPasep();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                case '5':
                    Console.Clear();
                    TestarInscricaoEstadual();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                case '6':
                    Console.Clear();
                    TestarValidacaoCnh();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                case '7':
                    Console.Clear();
                    TestarValidacaoRenavam();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                case '8':
                    Console.Clear();
                    TestarValidacaoPlacaVeicular();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                case '9':
                    Console.Clear();
                    TestarValidacaoPassaporte();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                case '0':
                    Console.Clear();
                    TestarValidacaoCep();
                    Console.ReadKey();
                    CarregarMenuPrincial();
                    break;
                default:
                    Console.Clear();
                    ExibirLogo();
                    Console.WriteLine("");
                    Console.ForegroundColor = corDeSaida;
                    Console.WriteLine("                                       Obrigado  / Thank you");
                    Console.ForegroundColor = corDeTextoDefault;
                    Console.WriteLine("");
                    break;
            }            
        }

        private static string PintaOpcaoEmDestaque(string texto)
        {
            Console.ForegroundColor = corDeNumero;
            Console.Write(texto);
            Console.ForegroundColor = corDeTextoDefault;
            return "";
        }

        private static void TestarInscricaoEstadual()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||               Teste do validador de Inscrição Estadual / \"State Registration\" validator test             ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");


            Console.Write("Digite um Inscrição Estadual / Enter a State Registration number: ");
            Console.BackgroundColor = ConsoleColor.Blue;
            string inscricaoEstadual = Console.ReadLine();
            Console.WriteLine("");

            Console.BackgroundColor = corDeFundo;
            Console.Write("Digite a UF da inscrição estadual / Enter the state abbreviation of the state registration: ");
            Console.BackgroundColor = ConsoleColor.Blue;
            string ufString = Console.ReadLine();
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            UnidadeDaFederacao uf = ConverteUfStringParaUf(ufString);

            Console.Write("ClearCode: ");
            inscricaoEstadual = InscricaoEstadualValidator.ClearCode(inscricaoEstadual);
            Console.Write(PintaOpcaoEmDestaque(inscricaoEstadual));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(InscricaoEstadualValidator.IsValid(inscricaoEstadual, uf).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(InscricaoEstadualValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(InscricaoEstadualValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(InscricaoEstadualValidator.ValidateReturningMessage(inscricaoEstadual, uf)));
            Console.WriteLine("");

            Console.Write("Format: ");
            Console.Write(PintaOpcaoEmDestaque(InscricaoEstadualValidator.Format(inscricaoEstadual, uf)));
            Console.WriteLine("");

            Console.Write("GetUFName (método exclusivo): ");
            Console.Write(PintaOpcaoEmDestaque(InscricaoEstadualValidator.GetUFName(uf)));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(InscricaoEstadualValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(InscricaoEstadualValidator.Author()));

            /*
            Console.WriteLine("Validating the UF \"AC\", which corresponds to the state \"" + InscricaoEstadualValidator.GetUFName(UnidadeDaFederacao.AC)+"\"");
            Console.WriteLine(InscricaoEstadualValidator.IsValid("5", UnidadeDaFederacao.AC));      //Válido.
            Console.WriteLine(InscricaoEstadualValidator.GetLastValidationCode());
            Console.WriteLine(InscricaoEstadualValidator.GetLastValidationMessage());
            Console.WriteLine("\n");
            Console.WriteLine(InscricaoEstadualValidator.ValidateReturningMessage("11.304.630/361-05", UnidadeDaFederacao.AC)); //Erro ao validar o DV
            Console.WriteLine(InscricaoEstadualValidator.ValidateReturningMessage(" 1.304.630/361-05", UnidadeDaFederacao.AC)); //Espaço
            Console.WriteLine(InscricaoEstadualValidator.ValidateReturningMessage("A1.304.630/361-05", UnidadeDaFederacao.AC)); //Letra
            Console.WriteLine(InscricaoEstadualValidator.ValidateReturningMessage("1.304.630/361-05", UnidadeDaFederacao.AC)); //Número menor
            Console.WriteLine(InscricaoEstadualValidator.ValidateReturningMessage("001.304.630/361-05", UnidadeDaFederacao.AC)); //Número maior
            Console.WriteLine(InscricaoEstadualValidator.ValidateReturningMessage("11.111.111/111-11", UnidadeDaFederacao.AC)); //Números repetidos
            Console.WriteLine("UF name: " + InscricaoEstadualValidator.GetUFName(UnidadeDaFederacao.AC)); //Números repetidos

            Console.WriteLine("");
            Console.WriteLine("Autor: " + InscricaoEstadualValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + InscricaoEstadualValidator.Help());
            Console.WriteLine("");
            */
        }

        private static UnidadeDaFederacao ConverteUfStringParaUf(string ufString)
        {
            switch (ufString.ToUpper())
            {
                case "AC":
                    return UnidadeDaFederacao.AC;
                case "AL":
                    return UnidadeDaFederacao.AL;
                case "AM":
                    return UnidadeDaFederacao.AM;
                case "AP":
                    return UnidadeDaFederacao.AP;
                case "BA":
                    return UnidadeDaFederacao.BA;
                case "CE":
                    return UnidadeDaFederacao.CE;
                case "DF":
                    return UnidadeDaFederacao.DF;
                case "ES":
                    return UnidadeDaFederacao.ES;
                case "GO":
                    return UnidadeDaFederacao.GO;
                case "MA":
                    return UnidadeDaFederacao.MA;
                case "MT":
                    return UnidadeDaFederacao.MT;
                case "MS":
                    return UnidadeDaFederacao.MS;
                case "MG":
                    return UnidadeDaFederacao.MG;
                case "PA":
                    return UnidadeDaFederacao.PA;
                case "PB":
                    return UnidadeDaFederacao.PB;
                case "PE":
                    return UnidadeDaFederacao.PE;
                case "PI":
                    return UnidadeDaFederacao.PI;
                case "PR":
                    return UnidadeDaFederacao.PR;
                case "RJ":
                    return UnidadeDaFederacao.RJ;
                case "RN":
                    return UnidadeDaFederacao.RN;
                case "RO":
                    return UnidadeDaFederacao.RO;
                case "RR":
                    return UnidadeDaFederacao.RR;
                case "RS":
                    return UnidadeDaFederacao.RS;
                case "SC":
                    return UnidadeDaFederacao.SC;
                case "SE":
                    return UnidadeDaFederacao.SE;
                case "SP":
                    return UnidadeDaFederacao.SP;
                case "TO":
                    return UnidadeDaFederacao.TO;
                default:
                    return UnidadeDaFederacao.TO;
            }
            return UnidadeDaFederacao.TO;
        }

        private static void TestarValidacaoCep()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                          Teste do validador de CEP / \"Zip code\" validator test                           ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("Digite um CEP / Enter a Zip code number: ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string cep = Console.ReadLine();

            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("ClearCode: ");
            cep = CepValidator.ClearCode(cep);
            Console.Write(PintaOpcaoEmDestaque(cep));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(CepValidator.IsValid(cep).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(CepValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(CepValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(CepValidator.ValidateReturningMessage(cep)));
            Console.WriteLine("");

            Console.Write("Format: ");
            Console.Write(PintaOpcaoEmDestaque(CepValidator.Format(cep)));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("CepExists (método exclusivo): ");
            Console.Write(PintaOpcaoEmDestaque(CepValidator.CepExists(cep).ToString()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("GetCepAddressInJson (método exclusivo): ");
            Console.Write(PintaOpcaoEmDestaque(CepValidator.GetCepAddressInJson(cep)));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(CepValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(CepValidator.Author()));

            /*
            Console.WriteLine(CepValidator.IsValid("24465-430", false));                    // Valid. (without verifying the existence of the zip code)
            Console.WriteLine(CepValidator.GetLastValidationCode());
            Console.WriteLine(CepValidator.GetLastValidationMessage());

            Console.WriteLine(CepValidator.IsValid("24465-430", true));                     // Valid. (checking existence of zip code - requires internet available)
            Console.WriteLine(CepValidator.GetLastValidationCode());
            Console.WriteLine(CepValidator.GetLastValidationMessage());

            Console.WriteLine(CepValidator.GetLastValidationMessage());
            Console.WriteLine(CepValidator.ValidateReturningMessage("24465-430"));          // Valid.
            Console.WriteLine(CepValidator.ValidateReturningMessage("24465-43"));           // Minor code.
            Console.WriteLine(CepValidator.ValidateReturningMessage("24465-4300"));         // Larger code.
            Console.WriteLine(CepValidator.ValidateReturningMessage("24465 430"));          // Code with space.
            Console.WriteLine(CepValidator.ValidateReturningMessage(" 24465-430 "));        // Code with space.
            Console.WriteLine(CepValidator.ValidateReturningMessage("S4465-430"));          // Code with letter.
            Console.WriteLine(CepValidator.ValidateReturningMessage("22222-222"));          // Repeated numbers.
            Console.WriteLine($"CEP clear - before (24465-430) / after ({CepValidator.ClearCode("24465-430")})");

            Console.WriteLine($"CEP 24.461-561 exist? {CepValidator.CepExists("70.150-903")}");
            Console.WriteLine($"CEP 77.888-999 exist? {CepValidator.CepExists("77.888-999")}");

            Console.WriteLine($"Recovering CEP 24.461-561 on ViaCep: {CepValidator.GetCepAddressInJson("70150909")}");

            Console.WriteLine($"Recovering CEP 24.461-561 on ViaCep: {CepValidator.GetCepAddressInJson("70150900")}");
            
            Console.WriteLine("");
            Console.WriteLine("Autor: " + CepValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + CepValidator.Help());
            Console.WriteLine("");
            */
        }

        private static void TestarValidacaoPlacaVeicular()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                    Teste do validador de placa veicular / \"Licence plate\" validator test                 ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");


            Console.Write("Digite um placa veicular / Enter a licence plate number: ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string placaVeicular = Console.ReadLine();

            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("ClearCode: ");
            placaVeicular = PlacaVeicularValidator.ClearCode(placaVeicular);
            Console.Write(PintaOpcaoEmDestaque(placaVeicular));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(PlacaVeicularValidator.IsValid(placaVeicular).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(PlacaVeicularValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(PlacaVeicularValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(PlacaVeicularValidator.ValidateReturningMessage(placaVeicular)));
            Console.WriteLine("");

            Console.Write("Format: ");
            Console.Write(PintaOpcaoEmDestaque(PlacaVeicularValidator.Format(placaVeicular)));
            Console.WriteLine("");

            Console.Write("IdentifiesFederativeUnitoftheGrayPlate (método exclusivo): ");
            Console.Write(PintaOpcaoEmDestaque(PlacaVeicularValidator.IdentifiesFederativeUnitoftheGrayPlate(placaVeicular)));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(PlacaVeicularValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(PlacaVeicularValidator.Author()));

            /*
            Console.WriteLine(PlacaVeicularValidator.IsValid("AB-1234"));                           // Valid. Yellow license plate.
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationCode());
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationMessage());

            Console.WriteLine(PlacaVeicularValidator.IsValid("ABC-1234"));                          // Valid. Gray license plate.
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationCode());
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationMessage());

            Console.WriteLine(PlacaVeicularValidator.IsValid("ABC1D23"));                           // Valid. MERCOSUL license plate.
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationCode());
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationMessage());

            Console.WriteLine(PlacaVeicularValidator.ValidateReturningMessage("
            "));         // Valid. Gray license plate.
            Console.WriteLine(PlacaVeicularValidator.ValidateReturningMessage("HZ-1234"));          // Valid. Yellow license plate.
            Console.WriteLine(PlacaVeicularValidator.ValidateReturningMessage("HZA1B23"));          // Valid. MERCOSUL license plate.

            Console.WriteLine("Formatted license plate: " + PlacaVeicularValidator.Format("AB1234"));
            Console.WriteLine("Formatted license plate: " + PlacaVeicularValidator.Format("ABC1234"));
            Console.WriteLine("Formatted license plate: " + PlacaVeicularValidator.Format("ABC1Z23"));


            Console.WriteLine(PlacaVeicularValidator.ValidateReturningMessage("A-1234"));           // Minor code.
            Console.WriteLine(PlacaVeicularValidator.ValidateReturningMessage("AAAA-1234"));        // Larger code.
            Console.WriteLine(PlacaVeicularValidator.ValidateReturningMessage("HZ 1234"));          // Code with space.
            Console.WriteLine(PlacaVeicularValidator.ValidateReturningMessage(" HZ-1234 "));        // Code with space.
            Console.WriteLine($"Formatted license plate clear - before (DDW-12.34) / after ({PlacaVeicularValidator.ClearCode("DDW-12.34")})");

            Console.WriteLine(PlacaVeicularValidator.ValidateReturningMessage("HZA1K23"));          // Invalid MERCOSUL license plate.

            Console.WriteLine("");
            Console.WriteLine("Autor: " + PlacaVeicularValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + PlacaVeicularValidator.Help());
            Console.WriteLine("");
            */
        }

        private static void TestarValidacaoCnh()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                     Teste do validador de CNH / \"Driver's License\" validator test                        ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("Digite um CNH / Enter a Driver's License number: ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string cnh = Console.ReadLine();

            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("ClearCode: ");
            cnh = CnhValidator.ClearCode(cnh);
            Console.Write(PintaOpcaoEmDestaque(cnh));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(CnhValidator.IsValid(cnh).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(CnhValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(CnhValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(CnhValidator.ValidateReturningMessage(cnh)));
            Console.WriteLine("");

            Console.Write("Format: ");
            Console.Write(PintaOpcaoEmDestaque(CnhValidator.Format(cnh)));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(CnhValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(CnhValidator.Author()));

            /*
            Console.WriteLine(CnhValidator.IsValid("76818606292"));                          // Valid.
            Console.WriteLine(CnhValidator.GetLastValidationCode());
            Console.WriteLine(CnhValidator.GetLastValidationMessage());

            Console.WriteLine(CnhValidator.ValidateReturningMessage("76867115464"));         // Valid.
            Console.WriteLine(CnhValidator.ValidateReturningMessage("768671154-64"));        // Valid.
            Console.WriteLine("Formatted CNH: " + CnhValidator.Format("887024213/27"));
            Console.WriteLine(CnhValidator.ValidateReturningMessage("54733585267"));         // Valid.
            Console.WriteLine("Formatted CNH: " + CnhValidator.Format("270.388.092-88"));

            Console.WriteLine(CnhValidator.ValidateReturningMessage("6048926648"));          // Minor code.
            Console.WriteLine(CnhValidator.ValidateReturningMessage("604892664822"));        // Larger code.
            Console.WriteLine(CnhValidator.ValidateReturningMessage("683995210 20"));        // Code with space.
            Console.WriteLine(CnhValidator.ValidateReturningMessage(" 68399521020 "));       // Code with space.
            Console.WriteLine($"CNH clear - before (39.248.946.405) / after ({CnhValidator.ClearCode("39.248.946.405")})");

            Console.WriteLine(CnhValidator.ValidateReturningMessage("7686711546z"));         //Code with letter.

            Console.WriteLine("");
            Console.WriteLine("Autor: " + CnhValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + CnhValidator.Help());
            Console.WriteLine("");
            */
        }

        private static void TestarValidacaoPassaporte()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                     Teste do validador de Passaporte / \"Passport\" validator test                         ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");


            Console.Write("Digite um Passaporte / Enter a Passport number: ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string passaporte = Console.ReadLine();

            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("ClearCode: ");
            passaporte = PassaporteValidator.ClearCode(passaporte);
            Console.Write(PintaOpcaoEmDestaque(passaporte));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(PassaporteValidator.IsValid(passaporte).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(PassaporteValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(PassaporteValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(PassaporteValidator.ValidateReturningMessage(passaporte)));
            Console.WriteLine("");

            Console.Write("Format: ");
            Console.Write(PintaOpcaoEmDestaque(PassaporteValidator.Format(passaporte)));
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(PassaporteValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(PassaporteValidator.Author()));

            /*
            Console.WriteLine(PassaporteValidator.IsValid("YN011222"));                          // Valid.
            Console.WriteLine(PassaporteValidator.GetLastValidationCode());
            Console.WriteLine(PassaporteValidator.GetLastValidationMessage());

            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("YN011222"));         // Valid.
            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("YN-011222"));        // Valid.
            Console.WriteLine("Formatted Passaporte: " + PassaporteValidator.Format("RR--011232"));
            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("RR011232"));         // Valid.
            Console.WriteLine("Formatted Passaporte: " + PassaporteValidator.Format("IO022335"));

            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("LQ10132"));          // Minor code.
            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("Q101325"));          // Minor code.
            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("LQ1203334"));        // Larger code.
            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("LLQ120334"));        // Larger code.
            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("QG 010301"));        // Code with space.
            Console.WriteLine(PassaporteValidator.ValidateReturningMessage(" QG010301 "));       // Code with space.
            Console.WriteLine($"Passaporte clear - before (976.682.735-02) / after ({PassaporteValidator.ClearCode("976.682.735-02")})");

            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("YYYYYYYY"));         // Valid.

            Console.WriteLine(PassaporteValidator.ValidateReturningMessage("88011222"));         // Missing letter in code..

            Console.WriteLine("");
            Console.WriteLine("Autor: " + PassaporteValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + PassaporteValidator.Help());
            Console.WriteLine("");
            */
        }

        private static void TestarValidacaoRenavam()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                        Teste do validador de RENAVAM / \"RENAVAM\" validator test                          ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("Digite um RENAVAM / Enter a RENAVAM number: ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string renavam = Console.ReadLine();

            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("ClearCode: ");
            renavam = RenavamValidator.ClearCode(renavam);
            Console.Write(PintaOpcaoEmDestaque(renavam));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(RenavamValidator.IsValid(renavam).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(RenavamValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(RenavamValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(RenavamValidator.ValidateReturningMessage(renavam)));
            Console.WriteLine("");

            Console.Write("Format: ");
            Console.Write(PintaOpcaoEmDestaque(RenavamValidator.Format(renavam)));
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(RenavamValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(RenavamValidator.Author()));

            /*
            Console.WriteLine(RenavamValidator.IsValid("97668273502"));                          // Valid.
            Console.WriteLine(RenavamValidator.GetLastValidationCode());
            Console.WriteLine(RenavamValidator.GetLastValidationMessage());

            Console.WriteLine(RenavamValidator.ValidateReturningMessage("78403691180"));         // Valid.
            Console.WriteLine(RenavamValidator.ValidateReturningMessage("136408249-02"));        // Valid.
            Console.WriteLine("RENAVAM formatado: " + RenavamValidator.Format("870073367-60"));
            Console.WriteLine(RenavamValidator.ValidateReturningMessage("97668273502"));         // Valid.
            Console.WriteLine("RENAVAM formatado: " + RenavamValidator.Format("01275136637"));

            Console.WriteLine(RenavamValidator.ValidateReturningMessage("97668273501"));         // Wrong check digit.
            Console.WriteLine(RenavamValidator.ValidateReturningMessage("97668x73502"));         // Code with letter.
            Console.WriteLine(RenavamValidator.ValidateReturningMessage("9766827350"));          // Minor code.
            Console.WriteLine(RenavamValidator.ValidateReturningMessage("976682735022"));        // Larger code.
            Console.WriteLine(RenavamValidator.ValidateReturningMessage("976682 73502"));        // Code with space.
            Console.WriteLine(RenavamValidator.ValidateReturningMessage(" 97668273502 "));       // Code with space.
            Console.WriteLine($"RENAVAM clear - before (976.682.735-02) / after ({RenavamValidator.ClearCode("976.682.735-02")})");

            Console.WriteLine("");
            Console.WriteLine("Autor: " + RenavamValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + RenavamValidator.Help());
            Console.WriteLine("");
            */
        }

        private static void TestarValidacaoTituloDeEleitor()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                  Teste do validador de título de eleitor  / \"Voter card\" validator test                  ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");


            Console.Write("Digite um título de eleitor / Enter a voter card number: ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string titulo = Console.ReadLine();

            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("ClearCode: ");
            titulo = TituloEleitoralValidator.ClearCode(titulo);
            Console.Write(PintaOpcaoEmDestaque(titulo));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(TituloEleitoralValidator.IsValid(titulo).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(TituloEleitoralValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(TituloEleitoralValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(TituloEleitoralValidator.ValidateReturningMessage(titulo)));
            Console.WriteLine("");

            Console.Write("Format (default): ");
            Console.Write(PintaOpcaoEmDestaque(TituloEleitoralValidator.Format(titulo)));
            Console.WriteLine("");

            Console.Write("Format (enviando separadores / método exclusivo): ");
            Console.Write(PintaOpcaoEmDestaque(TituloEleitoralValidator.Format(titulo, '-', '-')));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(TituloEleitoralValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(TituloEleitoralValidator.Author()));
			
			/*
            Console.WriteLine("--------------------------------------[Aleatórios]");
            Console.WriteLine(TituloEleitoralValidator.IsValid("106644440302"));    // Valid.
            Console.WriteLine(TituloEleitoralValidator.GetLastValidationCode());
            Console.WriteLine(TituloEleitoralValidator.GetLastValidationMessage());

            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("20107411 07 79"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("106644440302"));    // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("10664444030"));     // Minor code.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("1066444403022"));   // Larger code..
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("116644440302"));    // Wrong check digit.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("1x6644440302"));    // Code with letter..

            Console.WriteLine("Formatted Título: " + TituloEleitoralValidator.Format("106644440302"));
            Console.WriteLine($"Título clear - before (20107411 07 79) / after ({TituloEleitoralValidator.ClearCode("20107411 07 79")})");

            Console.WriteLine("Formatted Título: " + TituloEleitoralValidator.Format("106644440302", '.', '-'));

            //-Minas gerais.
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------[Minas Gerais]");
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("247478020248"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("433402060272"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("764723240230"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("623052850272"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("071452800205"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("308324570299"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("160386830272"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("732813800280"));
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("271175600256"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("481605230213"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("560687060205"));
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("456224410264"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("484158250221"));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("484158250221"));  // Valid.

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------[São Paulo]");
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("338381070140", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("103001280108", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("002763180140", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("484831230124", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("651044140167", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("072765380108", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("076532720108", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("138002800108", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("515555250183", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("224440140140", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("201232730116", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("856842430159", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("282637670124", false));  // Valid.
            Console.WriteLine(TituloEleitoralValidator.ValidateReturningMessage("052025510191", false));  // Valid.

            Console.WriteLine("");
            Console.WriteLine("Autor: " + TituloEleitoralValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + TituloEleitoralValidator.Help());
            Console.WriteLine("");
			*/
        }

        private static void TestarValidacaoPisPasep()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                      Teste do validador de PIS-PASEP  / \"PIS-PASEP\" validator test                       ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");


            Console.Write("Digite um PIS-PASEP / Enter a PIS-PASEP number: ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string pisPasep = Console.ReadLine();

            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("ClearCode: ");
            pisPasep = PisPasepValidator.ClearCode(pisPasep);
            Console.Write(PintaOpcaoEmDestaque(pisPasep));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(PisPasepValidator.IsValid(pisPasep).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(PisPasepValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(PisPasepValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(PisPasepValidator.ValidateReturningMessage(pisPasep)));
            Console.WriteLine("");

            Console.Write("Format: ");
            Console.Write(PintaOpcaoEmDestaque(PisPasepValidator.Format(pisPasep)));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(PisPasepValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(PisPasepValidator.Author()));


            /*
            PisPasepValidator.IsValid("135.84160.29 - 3");                                      // Valid.
            Console.WriteLine(PisPasepValidator.GetLastValidationCode());
            Console.WriteLine(PisPasepValidator.GetLastValidationMessage());
            
            PisPasepValidator.IsValid("13584160293");                                           // Valid.
            Console.WriteLine(PisPasepValidator.GetLastValidationCode());
            Console.WriteLine(PisPasepValidator.GetLastValidationMessage());

            Console.WriteLine(PisPasepValidator.GetLastValidationMessage());
            Console.WriteLine(PisPasepValidator.ValidateReturningMessage("1358416029"));        // Minor code.
            Console.WriteLine(PisPasepValidator.ValidateReturningMessage("135841602933"));      // Larger code.
            Console.WriteLine(PisPasepValidator.ValidateReturningMessage("1x584160293"));       // Code with letter.
            Console.WriteLine(PisPasepValidator.ValidateReturningMessage("23584160293"));       // Wrong check digit.

            Console.WriteLine("");
            Console.WriteLine("Autor: " + PisPasepValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + PisPasepValidator.Help());
            Console.WriteLine("");
            */
        }

        private static void TestarValidacaoDeCnpj()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                          Teste do validador de CNPJ  / \"CNPJ\" validator test                             ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");


            Console.Write("Digite um CNPJ / Enter a CNPJ number: ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string cnpj = Console.ReadLine();

            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("ClearCode: ");
            cnpj = CnpjValidator.ClearCode(cnpj);
            Console.Write(PintaOpcaoEmDestaque(cnpj));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(CnpjValidator.IsValid(cnpj).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(CnpjValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(CnpjValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(CnpjValidator.ValidateReturningMessage(cnpj)));
            Console.WriteLine("");

            Console.Write("Format: ");
            Console.Write(PintaOpcaoEmDestaque(CnpjValidator.Format(cnpj)));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(CnpjValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(CnpjValidator.Author()));
			
			/*
            Console.WriteLine(CnpjValidator.IsValid("75247370000127"));                          // Valid.
            Console.WriteLine(CnpjValidator.GetLastValidationCode());
            Console.WriteLine(CnpjValidator.GetLastValidationMessage());

            Console.WriteLine(CnpjValidator.ValidateReturningMessage("75247370000127"));         // Valid.
            Console.WriteLine(CnpjValidator.ValidateReturningMessage("75.247.370/0001-27"));     // Valid.
            Console.WriteLine("Formatted CNPJ: " + CnpjValidator.Format("75247370000127"));
            Console.WriteLine(CnpjValidator.ValidateReturningMessage("07.987.010/0001-01"));     // Valid.
            Console.WriteLine("Formatted CNPJ: " + CnpjValidator.Format("07987010000101"));

            Console.WriteLine(CnpjValidator.ValidateReturningMessage("07.987.010/0001-00"));     // Wrong check digit.
            Console.WriteLine(CnpjValidator.ValidateReturningMessage("07.98c.010/0001-01"));     // Code with letter.
            Console.WriteLine(CnpjValidator.ValidateReturningMessage("07.987.010/000-01"));      // Minor code.
            Console.WriteLine(CnpjValidator.ValidateReturningMessage("07.987.010/00011-01"));    // Larger code.
            Console.WriteLine(CnpjValidator.ValidateReturningMessage("07.987 010/0001-01"));     // Code with space.
            Console.WriteLine(CnpjValidator.ValidateReturningMessage(" 07987010000101 "));       // Code with space.

            Console.WriteLine($"CNPJ clear - before (07.987.010 /* 0001 - 01) / after ({CnpjValidator.ClearCode("07.987.010 /* 0001 - 01")})");

            Console.WriteLine(CnpjValidator.ValidateReturningMessage("11.111.111/1111-11"));     // Repeated numbers.

            Console.WriteLine("");
            Console.WriteLine("Autor: " + CnpjValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + CnpjValidator.Help());
            Console.WriteLine("");
			*/
        }

        private static void TestarValidacaoDeCpf()
        {
            Console.BackgroundColor = corDeFundo;
            Console.Clear();
            Console.WriteLine("");
            Console.BackgroundColor = corDeTitulo;
            Console.WriteLine("+============================================================================================================+");
            Console.WriteLine("||                           Teste do validador de CPF  / \"CPF\" validator test                              ||");
            Console.WriteLine("+============================================================================================================+");
            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("Digite um CPF / Enter a CPF number: ");
            Console.BackgroundColor = ConsoleColor.Blue;

            string cpf = Console.ReadLine();            

            Console.BackgroundColor = corDeFundo;
            Console.WriteLine("");

            Console.Write("ClearCode: ");
            cpf = CpfValidator.ClearCode(cpf);
            Console.Write(PintaOpcaoEmDestaque(cpf));
            Console.WriteLine("");

            Console.Write("IsValid: ");
            Console.Write(PintaOpcaoEmDestaque(CpfValidator.IsValid(cpf).ToString()));
            Console.WriteLine("");

            Console.Write("GetLastValidationCode: ");
            Console.Write(PintaOpcaoEmDestaque(CpfValidator.GetLastValidationCode()));
            Console.WriteLine("");

            Console.Write("GetLastValidationMessage: ");
            Console.Write(PintaOpcaoEmDestaque(CpfValidator.GetLastValidationMessage()));
            Console.WriteLine("");

            Console.Write("ValidateReturningMessage: ");
            Console.Write(PintaOpcaoEmDestaque(CpfValidator.ValidateReturningMessage(cpf)));
            Console.WriteLine("");

            Console.Write("Format: ");
            Console.Write(PintaOpcaoEmDestaque(CpfValidator.Format(cpf)));
            Console.WriteLine("");

            Console.Write("ObtainCpfTaxRegion (método exclusivo): ");
            Console.Write(PintaOpcaoEmDestaque(CpfValidator.ObtainCpfTaxRegion(cpf)));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Help: ");
            Console.Write(PintaOpcaoEmDestaque(CpfValidator.Help()));
            Console.WriteLine("");
            Console.WriteLine("");

            Console.Write("Author: ");
            Console.Write(PintaOpcaoEmDestaque(CpfValidator.Author()));
			
			/*
            Console.WriteLine(CpfValidator.IsValid("27107407023"));      // Valid.
            Console.WriteLine(CpfValidator.GetLastValidationCode());
            Console.WriteLine(CpfValidator.GetLastValidationMessage());

            Console.WriteLine(CpfValidator.ValidateReturningMessage("271.074.070-2z"));   // Code with letter.
            Console.WriteLine(CpfValidator.ValidateReturningMessage("27107407023"));      // Valid.
            Console.WriteLine(CpfValidator.ValidateReturningMessage("333.333.333-33"));   // Repeated numbers.
            Console.WriteLine(CpfValidator.ValidateReturningMessage("27107407022"));      // Wrong check digit.
            Console.WriteLine(CpfValidator.ValidateReturningMessage("2710740702"));       // Minor code.
            Console.WriteLine(CpfValidator.ValidateReturningMessage("271074070222"));     // Larger code.
            Console.WriteLine(CpfValidator.ValidateReturningMessage("271 07407023"));     // Code with space.
            Console.WriteLine(CpfValidator.ValidateReturningMessage(" 27107407023"));     // Code with space.
            Console.WriteLine(CpfValidator.ValidateReturningMessage("27107407023 "));     // Code with space.

            CpfValidator.IsValid("271.074.070-23");                                       // Valid.
            Console.WriteLine(CpfValidator.GetLastValidationMessage());

            CpfValidator.IsValid("271.074.070-22");                                       // Wrong check digit.
            Console.WriteLine(CpfValidator.GetLastValidationMessage());

            Console.WriteLine("Formatted CPF: " + CpfValidator.Format("27107407023 "));

            Console.WriteLine($"CPF clear - before (271.074.070-23) / after ({CpfValidator.ClearCode("271.074.070-23")})");

            Console.WriteLine("");
            Console.WriteLine("Autor: " + CpfValidator.Author());
            Console.WriteLine("");
            Console.WriteLine("Help: " + CpfValidator.Help());
            Console.WriteLine("");
			*/
        }

        private static void ExibirLogo()
        {
            Console.ForegroundColor = corDoLogo;
            Console.WriteLine("                                                                                                      ");
            Console.WriteLine("            -                                                                          .:             ");
            Console.WriteLine("            #*.                                                                       =@.             ");
            Console.WriteLine("            +@%-                                                                    .#@%              ");
            Console.WriteLine("            -@@@*.                                                                 =@@@#              ");
            Console.WriteLine("            :@@@@%-                                                              .#@@@@+              ");
            Console.WriteLine("             @@@@@@*.                                                           -%@@@@@-              ");
            Console.WriteLine("             #@@+%@@%-                                                        .*@@%*%@@.              ");
            Console.WriteLine("             +@@*+*@@@+                                                      -%@@#++@@%               ");
            Console.WriteLine("             -@@#+++%@@%:                                                  .*@@%*+++@@*               ");
            Console.WriteLine("             .@@%++++*@@@+                                                -%@@#++++*@@+               ");
            Console.WriteLine("              %@@++++++%@@%:                                            .*@@@*+++++#@@-               ");
            Console.WriteLine("              #@@+++++++*@@@+                                          -%@@#+++++++%@@.               ");
            Console.WriteLine("              +@@*++++++++%@@%:                                      .*@@@*++++++++@@%                ");
            Console.WriteLine("              -@@#+++%*++++#@@@+                                    -%@@%+++++#*+++@@*                ");
            Console.WriteLine("              .@@%+++%@#+++++%@@#:                                 +@@@*++++*@@*++*@@=                ");
            Console.WriteLine("               %@@+++%@@%*++++#@@@+                              :%@@%+++++%@@@+++#@@:                ");
            Console.WriteLine("               *@@+++#@@@@#+++++%@@#:                           +@@@*++++*@@@@%+++%@@.                ");
            Console.WriteLine("               =@@*++*@@@@@%*++++#@@@=                        :%@@%+++++%@@@@@%+++@@%                 ");
            Console.WriteLine("               -@@#+++@@@@@@@#+++++%@@#:.....................+@@@*++++*@@@@@@@#++*@@*                 ");
            Console.WriteLine("               .@@%+++@@@@@@@@@*++++#@@@@@@@@@@@@@@@@@@@@@@@@@@%+++++%@@@@@@@@*++*@@=                 ");
            Console.WriteLine("                %@@+++%@@@@@@@@@#+++++%%%%%%%%%%%%%%%%%%%%%%%%*++++*@@@@@@@@@@+++#@@:                 ");
            Console.WriteLine("                *@@+++#@@@@@@@@%++++++++++++++++++++++++++++++++++++#@@@@@@@@@+++%@@                  ");
            Console.WriteLine("                =@@*++*@@@@@@@#++++++++++++++++++++++++++++++++++++++*@@@@@@@%+++@@#                  ");
            Console.WriteLine("                :@@#++*@@@@@@*+++++++++++++++++++++++++++++++++++++++++%@@@@@#++*@@*                  ");
            Console.WriteLine("                .@@%+++@@@@%++++++++++++++++++++++++++++++++++++++++++++#@@@@#++#@@=                  ");
            Console.WriteLine("                 %@@+++%@@#++++++++++++++++++++++++++++++++++++++++++++++*@@@*++#@@:                  ");
            Console.WriteLine("                 *@@*++%@*+++++++++++++++++++++++++++++++++++++++++++++++++%@+++%@@                   ");
            Console.WriteLine("                 =@@#++*++++++++++++++++++++++++++++++++++++++++++++++++++++#+++@@#                   ");
            Console.WriteLine("                 :@@#++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*@@+                   ");
            Console.WriteLine("                  @@%++++++++++++++++++++++++++++++++++++++++++++++++++++++++++#@@=                   ");
            Console.WriteLine("                  %@@++++++++++++++++++++++++++++++++++++++++++++++++++++++++++%@@-                   ");
            Console.WriteLine("                 *@@#++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*@@%.                  ");
            Console.WriteLine("                =@@%++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*@@#                  ");
            Console.WriteLine("               -@@%++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++#@@*                 ");
            Console.WriteLine("              :@@@++++++++++*%##*+++++++++++++++++++++++++++++++++++*#%#++++++++++%@@=                ");
            Console.WriteLine("             .%@@*++++++++++++%@@@%#*++++++++++++++++++++++++++*#%@@@@*++++++++++++%@@-               ");
            Console.WriteLine("             #@@*++++++++++++++#@@@@@@@%#*+++++++++++++++++*#%@@@@@@%+++++++++++++++@@@:              ");
            Console.WriteLine("            *@@#++++++++++++++++*@@@@@@@@%#++++++++++++++*%@@@@@@@@#++++++++++++++++*@@%.             ");
            Console.WriteLine("           =@@%+++++++++++++++++++%@@@%*++++++++++++++++++++*#%@@@*++++++++++++++++++*@@#             ");
            Console.WriteLine("          -@@%+++++++++++++++++++++**+++++++++++++++++++++++++++*+++++++++++++++++++++#@@*            ");
            Console.WriteLine("         :@@@++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++%@@+           ");
            Console.WriteLine("        .%@@*+++++++++++++==++++++++++++++++++++++++++++++++++++++++++++==++++++++++++++%@@-          ");
            Console.WriteLine("        #@@*++++++++==-:.   .-++++++++++++++++++++++++++++++++++++++++=:   .:--=+++++++++@@@:         ");
            Console.WriteLine("       *@@#++++=-:..          .=++++++++++++++++++++++++++++++++++++=:           .:-==+++*@@%.        ");
            Console.WriteLine("      =@@%-::.                  .=++++++++++++++++++++++++++++++++=:                  ..:-*@@#        ");
            Console.WriteLine("     .%@@@%*-.                    :=+++++++++++++++++++++++++++++-                     :+#@@@@=       ");
            Console.WriteLine("       :=#@@@@#=.                   :=+++++++++++++++++++++++++-.                   -*%@@@%+-         ");
            Console.WriteLine("          .=*@@@@#+:                  :=++++++++*##*+++++++++-.                 .=*@@@@#+:            ");
            Console.WriteLine("              -+%@@@%+-                 -+++*#%@@@@@@%#*+++-.                :=#@@@@*=.               ");
            Console.WriteLine("                 :+#@@@@*=.              .=@@@@@@@@@@@@@@*.               -+%@@@%*-                   ");
            Console.WriteLine("                    .=#@@@@#=:             .*@@@@@@@@@@#-             .-*@@@@%+:                      ");
            Console.WriteLine("                       .-*%@@@%+:            :*@@@@@@%-            .=#@@@@#=.                         ");
            Console.WriteLine("                           :+%@@@%*-.          :#@@%=           :+%@@@%*-.                            ");
            Console.WriteLine("                              .=#@@@@#=.         -=         .-*%@@@%+:                                ");
            Console.WriteLine("                                 .-*@@@@%+:              .=#@@@@#=:                                   ");
            Console.WriteLine("                                     -+%@@@%*-        :+#@@@@*-.                                      ");
            Console.WriteLine("                                        :=#@@@@#=. -*%@@@%+-                                          ");
            Console.WriteLine("                                           .=*@@@@@@@@#+:                                             ");
            Console.WriteLine("                                               -*%@#=.                                                ");
            Console.WriteLine("                                                                                                      ");
        }

    }
}
