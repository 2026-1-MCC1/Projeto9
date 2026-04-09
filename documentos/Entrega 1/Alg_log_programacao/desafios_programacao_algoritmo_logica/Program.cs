#region Variaveis
float p1, p2, p3, p4, p5;
int energia, pontos;
energia = 100;
pontos = 0;
String nome, curso, perdeu, parabens;
perdeu = "Tente novamente!";
parabens = "Parabéns Aventureiro, assim que se faz Agora você já pode sair da sala.";
#endregion

#region Texto inicial
Console.WriteLine("Olá, Seja bem vindo!");
Console.WriteLine("===========================================");
Console.WriteLine("Você é um aluno que está preso no laboratório");
Console.WriteLine("de informática da faculdade, pois caiu no sono ");
Console.WriteLine("e está tracado e agora você precisa destrancar.");
Console.WriteLine("Para isso, deverá passar por 5 fases. Cada fase");
Console.WriteLine("contém desafios. Se errar, o aluno perde energia.");
Console.WriteLine(" Ao acertar, ganha pontos. Acerte todas e consiga");
Console.WriteLine("sair do laboratório.");
Console.WriteLine("===========================================");
Console.WriteLine("Instruções");
Console.WriteLine("===========================================");
Console.WriteLine("São 5 desafios.");
Console.WriteLine("Você inicia o jogo com:");
Console.WriteLine("100 de energia");
Console.WriteLine("0 pontos");
Console.WriteLine("Todo acerto você ganha 1 ponto.");
Console.WriteLine("Toda erro ocasiona na perca de 10 de energia.");
Console.WriteLine("Caso você não consiga e queira desistir escreva na resposta: 000");
Console.WriteLine("Boa Sorte!");
Console.WriteLine("===========================================");
#endregion

#region Informações do jogador
Console.WriteLine("Diga seu nome aventureiro:");
nome = Console.ReadLine();
Console.WriteLine("Qual seu curso?");
curso = Console.ReadLine();
#endregion

Console.WriteLine(".............");

#region Desenvolvimento das fases 
#region Desenvolvimento da fase 1
while (energia > 0 &&  pontos <5) //Desafio 1
{
    Console.WriteLine("Nivel fácil: "); 
    Console.WriteLine("1ºDESAFIO: LÓGICO:");
    Console.WriteLine("Complete: 1, 3, 6, 10, 15, ?");
    Console.WriteLine("A resposta é: ");
    p1 = int.Parse(Console.ReadLine());

    if ( p1 == 21)
    {
        pontos++;
        Console.WriteLine("                     ");
        Console.WriteLine(nome+ " contêm:"+ pontos +" ponto "+" e " + energia +" energias.");
        Console.WriteLine("                     ");

        #region Desenvolvimento das fase (2)
        while (energia > 0 && pontos < 5) //desafio 2
        {
            Console.WriteLine("Nivel Médio: ");
            Console.WriteLine("2ºDESAFIO: EQUAÇÃO DE 1º:");
            Console.WriteLine(" 2x + 40 *8 + 12 = 62  + 2 + x + 422 ");
            Console.WriteLine("A resposta é: ");
            p2 = int.Parse(Console.ReadLine());

            if (p2 == 154)
            {
                pontos++;
                Console.WriteLine("                     ");
                Console.WriteLine(nome + " contêm:" + pontos + " pontos " + " e " + energia + " energias.");
                Console.WriteLine("                     ");

                #region Desenvolvimento da fase (3)
                while (energia > 0 && pontos < 5) //desafio 3
                {
                    Console.WriteLine("Nivel Médio: ");
                    Console.WriteLine("3ºDESAFIO: PROGRESSÃO ARITMÉTICAº:");
                    Console.WriteLine(" 10, 35, X, 85, 110. ");
                    Console.WriteLine("Qual o valor de X: ");
                    p3 = int.Parse(Console.ReadLine());

                    if (p3 == 60)
                    {
                        pontos++;
                        Console.WriteLine("                     ");
                        Console.WriteLine(nome + " contêm:" + pontos + " pontos " + " e " + energia + " energias.");
                        Console.WriteLine("                     ");

                        #region Desenvolvimento da fase (4)
                        while (energia > 0 && pontos < 5) //desafio 4
                        {
                            Console.WriteLine("Nivel Médio: ");
                            Console.WriteLine("4ºDESAFIO: CALCULE A HIPOTENUSA:");
                            Console.WriteLine(" Cateto A:3 cateto B:4 ");
                            Console.WriteLine("Qual o valor da Hipotenusa: ");
                            p4 = int.Parse(Console.ReadLine());

                            if (p4 == 5)
                            {
                                pontos++;
                                Console.WriteLine("                     ");
                                Console.WriteLine(nome + " contêm:" + pontos + " pontos " + " e " + energia + " energias.");
                                Console.WriteLine("                     ");

                                #region Desenvolvimento da fase (5)
                                while (energia > 0 && pontos < 5) //desafio 5
                                {
                                    Console.WriteLine("Nivel Médio: ");
                                    Console.WriteLine("5ºDESAFIO: EQUAÇÃO DE 2º:");
                                    Console.WriteLine(" F(X) = X²-4X+4 ");
                                    Console.WriteLine("O valor de X é: ");
                                    p5 = int.Parse(Console.ReadLine());

                                    if (p5 == 2)
                                    {
                                        pontos++;
                                        Console.WriteLine("                     ");
                                        Console.WriteLine(parabens);
                                        Console.WriteLine("                     ");

                                    }
                                    if (energia > 0 && p5 != 2)
                                    {
                                        energia -= 10;
                                        Console.WriteLine(perdeu + " Restam: " + energia + " energias.");
                                        Console.WriteLine("                     ");
                                    }
                                    if (energia == 0)
                                    {
                                        Console.WriteLine("Infelizmente você ficou sem energias, renicie o jogo e tente novamente.");
                                    }
                                    if (p5 == 000)
                                    {
                                        energia -= 100;
                                        Console.WriteLine("Que pena que vocÊ desistiu, caso queira tente novamente.");
                                    }
                                }
                                #endregion
                                
                            }
                            if (energia > 0 && p4 != 5)
                            {
                                energia -= 10;
                                Console.WriteLine(perdeu + " Restam: " + energia + " energias.");
                                Console.WriteLine("                     ");
                            }
                            if (energia == 0)
                            {
                                Console.WriteLine("Infelizmente você ficou sem energias, renicie o jogo e tente novamente.");
                            }
                            if (p4 == 000)
                            {
                                energia -= 100;
                                Console.WriteLine("Que pena que vocÊ desistiu, caso queira tente novamente.");
                            }
                        }
                        #endregion


                    }
                    if (energia > 0 && p3 != 60)
                    {
                        energia -= 10;
                        Console.WriteLine(perdeu + " Restam: " + energia + " energias.");
                        Console.WriteLine("                     ");
                    }
                    if (energia == 0)
                    {
                        Console.WriteLine("Infelizmente você ficou sem energias, renicie o jogo e tente novamente.");
                    }
                    if (p3 == 000)
                    {
                        energia-= 100;
                        Console.WriteLine("Que pena que vocÊ desistiu, caso queira tente novamente.");
                    }
                }
                #endregion

            }
            if (energia > 0 && p2 != 154)
            {
                energia -= 10;
                Console.WriteLine(perdeu + " Restam: " + energia + " energias.");
                Console.WriteLine("                     ");
            }
            if (energia == 0)
            {
                Console.WriteLine("Infelizmente você ficou sem energias, renicie o jogo e tente novamente.");
            }
            if( p2 == 000)
            {
                energia -= 100;
                Console.WriteLine("Que pena que vocÊ desistiu, caso queira tente novamente.");
            }
        }
        #endregion
#endregion
    }
    if (energia> 0 && p1!= 21){
        energia -= 10;
        Console.WriteLine(perdeu +" Restam: "+ energia + " energias.");
        Console.WriteLine("                     ");
    }
    if(energia ==0 )
    {
        Console.WriteLine("Infelizmente você ficou sem energias, renicie o jogo e tente novamente.");
    }

    if (p1 == 000)
    {
        energia -= 100;
        Console.WriteLine("Que pena que você desistiu, caso queira tente novamente.");
    }
}
#endregion

#region Fim!
Console.WriteLine("Status:");
Console.WriteLine("Nome jogador: " + nome + " Curso de: "+curso);
Console.WriteLine( "Energia restante: " + energia);
Console.WriteLine( " você conseguiu: " + pontos + " pontos.");
#endregion