using System;
using BrazilianDocuments.Validators;

namespace BrazilianDocumentsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            TestarValidacaoDeCpf();

            TestarValidacaoDeCnpj();

            TestarValidacaoPisPasep();

            TestarInscricaoEstadual();

            TestarValidacaoTituloDeEleitor();

            TestarValidacaoRenavam();

            TestarValidacaoPassaporte();

            TestarValidacaoCnh();

            TestarValidacaoPlacaVeicular();

            TestarValidacaoCep();

            ExibirLogo();
        }

        private static void TestarInscricaoEstadual()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                             \"Inscrição Estadual (IE)\" VALIDATION EXAMPLES                                ||");
            Console.WriteLine(" +============================================================================================================+");

            Console.WriteLine("Validating the UF \"AC\", which corresponds to the state \"" + InscricaoEstadualValidator.GetUFName(UnidadeDaFederacao.AC)+"\"");
            Console.WriteLine(InscricaoEstadualValidator.IsValid("01.304.630/361-05", UnidadeDaFederacao.AC));      //Válido.
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

        }

        private static void TestarValidacaoCep()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                                       \"CEP\" VALIDATION EXAMPLES                                          ||");
            Console.WriteLine(" +============================================================================================================+");

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

        }

        private static void TestarValidacaoPlacaVeicular()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                            EXAMPLES OF \"VEHICLE LICENSE PLATE\" VALIDATION                                ||");
            Console.WriteLine(" +============================================================================================================+");

            Console.WriteLine(PlacaVeicularValidator.IsValid("AB-1234"));                           // Valid. Yellow license plate.
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationCode());
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationMessage());

            Console.WriteLine(PlacaVeicularValidator.IsValid("ABC-1234"));                          // Valid. Gray license plate.
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationCode());
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationMessage());

            Console.WriteLine(PlacaVeicularValidator.IsValid("ABC1D23"));                           // Valid. MERCOSUL license plate.
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationCode());
            Console.WriteLine(PlacaVeicularValidator.GetLastValidationMessage());

            Console.WriteLine(PlacaVeicularValidator.ValidateReturningMessage("DDW-1234"));         // Valid. Gray license plate.
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

        }

        private static void TestarValidacaoCnh()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                               EXAMPLES OF \"DRIVER'S LICENSE\" VALIDATION                                  ||");
            Console.WriteLine(" +============================================================================================================+");

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

        }

        private static void TestarValidacaoPassaporte()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                                      \"PASSPORT\" VALIDATION EXAMPLES                                      ||");
            Console.WriteLine(" +============================================================================================================+");

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

        }

        private static void TestarValidacaoRenavam()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                                      \"RENAVAM\" VALIDATION EXAMPLES                                       ||");
            Console.WriteLine(" +============================================================================================================+");

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

        }

        private static void TestarValidacaoTituloDeEleitor()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                                  EXAMPLES OF \"VOTER CARD\" VALIDATION                                     ||");
            Console.WriteLine(" +============================================================================================================+");

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

        }

        private static void TestarValidacaoPisPasep()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                                     \"PIS-PASEP\" VALIDATION EXAMPLES                                      ||");
            Console.WriteLine(" +============================================================================================================+");

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

        }

        private static void TestarValidacaoDeCnpj()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                                        \"CNPJ\" VALIDATION EXAMPLES                                        ||");
            Console.WriteLine(" +============================================================================================================+");

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

        }

        private static void TestarValidacaoDeCpf()
        {
            Console.WriteLine(" +============================================================================================================+");
            Console.WriteLine(" ||                                         \"CPF\" VALIDATION EXAMPLES                                        ||");
            Console.WriteLine(" +============================================================================================================+");


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

        }

        private static void ExibirLogo()
        {
            Console.WriteLine("                                                                                                      ");
            Console.WriteLine("                                                                                                      ");
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
            Console.WriteLine("                                                                                                      ");
            Console.WriteLine("                                                                                                      ");
        }

    }
}
