// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");
// NO REAL MONEY NOR PRIZES ARE AWARDED.

// 12/17/2024:  Started at around 7:07PM.  Ended at 8:03PM.
// 12/18/2024:  Started at around 6:30PM.  Ended at 7:58PM.  Fix the Cases to go please.
// 12/22/2024:  Started at around 10:27AM.  Finished at 11:30AM.  Might still be a few bugs though.

var rand = new Random();
int[] values = { 1, 2, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750 , 1000, 5000, 10000, 25000, 50000, 75000, 100000, 200000, 300000, 400000, 500000, 750000, 1000000};
int[] caseValues = new int[26];
int[] casesToGo = { 6, 5, 4, 3, 2, 1, 1, 1, 1 };
int[] casesActive = new int[26];
int[] valuesActive = new int[26];
double[] offerMultiplier = { .15, .3, .65, .8, .9, .95, 1, 1, 1 };
int[] roundOffers = new int[9];
int restartGame = 1;
int counterOffer = 1;
int round = 1;
int caseToEliminate = 0;
int deal = 0;
int caseRemaining = 0;

// Set the actives.
for (int a = 0; a <= 25; a++)
{
    casesActive[a] = 1;
    valuesActive[a] = -1;
}

// Choose case values.
for (int a = 0; a <= 25; a++)
{
    var valueChosen = 0;
    do
    {
        valueChosen = rand.Next(0, 26);
    }
    while (valuesActive[valueChosen] > -1);

    caseValues[a] = valueChosen;
    valuesActive[valueChosen] = 1;
}

if (restartGame == 1) { restartGame = 0; };

Console.Clear();


// Display Case Values.
for (int a = 0; a <= 12; a++)
{

    int digits = (int)Math.Floor(Math.Log10(values[a])) + 1;
    int digits2 = (int)Math.Floor(Math.Log10(values[a + 13])) + 1;

    Console.SetCursorPosition(8 - digits, 1 + a);
    if (valuesActive[a] == 1) { Console.Write("$" + values[a]); }
    Console.SetCursorPosition(40 - digits2, 1 + a);
    if (valuesActive[a+13] == 1) { Console.Write("$" + values[a + 13]); }

}

// Display Cases.
for (int a = 0; a <= 12; a++)
{

    Console.SetCursorPosition(a * 3 + 1, 15);
    if (casesActive[a] == 1 && a + 1 < 10) { Console.Write(" " + (a + 1)); }
    else if (casesActive[a] == 1 && a + 1 > 9) { Console.Write(a + 1); }
    Console.SetCursorPosition(a * 3 + 1, 16);
    if (casesActive[a+13] == 1) { Console.Write(a + 14); }

}

// Initial Case Pick.
int caseToPick = 0;
do
{
    Console.SetCursorPosition(2, 18);
    Console.Write("Choose a case: >                             ");
    Console.SetCursorPosition(19, 18);

    var i = Console.ReadLine();
    try
    {
        caseToPick = int.Parse(i);
    }
    catch // If user inputs a non-number.
    {
        
        continue;
    }
}
while (caseToPick < 1 || caseToPick > 26); // If user inputs anything except the numbers 1 - 26.
casesActive[caseToPick - 1] = 0;

// Resume at line 510 of Applesoft Basic Program.  Ended at 8:03PM.


// Game Loop Before Reveal of Case.
do
{
    // *** START OF ROUND LOOP *** 
    do
    {
        Console.Clear();

        // Display Case Values.
        for (int a = 0; a <= 12; a++)
        {

            int digits = (int)Math.Floor(Math.Log10(values[a])) + 1;
            int digits2 = (int)Math.Floor(Math.Log10(values[a + 13])) + 1;


            if (valuesActive[a] == 1) { Console.SetCursorPosition(8 - digits, 1 + a); Console.Write("$" + values[a]); }
            else { Console.SetCursorPosition(1, 1 + a); Console.Write("        "); }

            if (valuesActive[a + 13] == 1) { Console.SetCursorPosition(40 - digits2, 1 + a); Console.Write("$" + values[a + 13]); }
            else { Console.SetCursorPosition(32, 1 + a); Console.Write("        "); }

        }

        // Display Cases.
        for (int a = 0; a <= 12; a++)
        {
            Console.SetCursorPosition(a * 3 + 1, 15);
            if (casesActive[a] == 1 && a + 1 < 10) { Console.Write(" " + (a + 1)); }
            else if (casesActive[a] == 1 && a + 1 > 9) { Console.Write(a + 1); }
            else { Console.Write(".."); }

            Console.SetCursorPosition(a * 3 + 1, 16);
            if (casesActive[a + 13] == 1) { Console.Write(a + 14); }
            else { Console.Write(".."); }

        }

        Console.SetCursorPosition(2, 18); Console.Write("Round " + round + ": " + casesToGo[round - 1] + " cases to go");


        do
        {
            Console.SetCursorPosition(2, 19); Console.Write("                                            ");
            Console.SetCursorPosition(2, 19); Console.Write("Pick a case to eliminate: ");
            Console.SetCursorPosition(28, 19); var i = Console.ReadLine();


            try
            {
                caseToEliminate = int.Parse(i);
            }
            catch // If user inputs a non-number.
            {

                continue;
            }
        } while (caseToEliminate < 1 || caseToEliminate > 26 || casesActive[caseToEliminate - 1] == 0);

        // Reveal Dollar Amount.
        Console.SetCursorPosition(11, 3);
        Console.Write("........");
        Console.SetCursorPosition(11, 3);
        Console.Write("$" + values[caseValues[caseToEliminate - 1]]);
        await Task.Delay(2000);

        casesActive[caseToEliminate - 1] = 0;
        valuesActive[caseValues[caseToEliminate - 1]] = 0;
        casesToGo[round - 1] -= 1;


        //29



    } while (casesToGo[round - 1] > 0);
    // *** END OF ROUND LOOP *** 


    // *** BANK OFFER ***

    Console.Clear();

    // Display Case Values.
    for (int a = 0; a <= 12; a++)
    {

        int digits = (int)Math.Floor(Math.Log10(values[a])) + 1;
        int digits2 = (int)Math.Floor(Math.Log10(values[a + 13])) + 1;


        if (valuesActive[a] == 1) { Console.SetCursorPosition(8 - digits, 1 + a); Console.Write("$" + values[a]); }
        else { Console.SetCursorPosition(1, 1 + a); Console.Write("        "); }

        if (valuesActive[a + 13] == 1) { Console.SetCursorPosition(40 - digits2, 1 + a); Console.Write("$" + values[a + 13]); }
        else { Console.SetCursorPosition(32, 1 + a); Console.Write("        "); }

    }

    // Display Cases.
    for (int a = 0; a <= 12; a++)
    {
        Console.SetCursorPosition(a * 3 + 1, 15);
        if (casesActive[a] == 1 && a + 1 < 10) { Console.Write(" " + (a + 1)); }
        else if (casesActive[a] == 1 && a + 1 > 9) { Console.Write(a + 1); }
        else { Console.Write(".."); }

        Console.SetCursorPosition(a * 3 + 1, 16);
        if (casesActive[a + 13] == 1) { Console.Write(a + 14); }
        else { Console.Write(".."); }

    }

    for (int a = 18; a <= 19; a++)
    {
        Console.SetCursorPosition(1, a);
        for (int b = 1; b <= 40; b++)
        {
            Console.Write(" ");
        }
    }

    Console.SetCursorPosition(2, 18);
    if (deal > 0)
    { Console.Write("The bank would have offered you"); }
    else
    { Console.Write("The bank wishes to buy your case for"); }

    await Task.Delay(1000);

    var tentativeOffer = 0;
    var totalCasesLeft = 0;
    var offer = 0;
    var offerAdjustment = 0;
    // Calculating Offer.
    for (int a = 0; a <= 25; a++)
    {
        if (valuesActive[a] == 1) { tentativeOffer += values[a]; totalCasesLeft++; }
    }
    tentativeOffer /= totalCasesLeft;
    offer = (int)Math.Floor(tentativeOffer * offerMultiplier[round - 1]);
    offerAdjustment = 1 + (rand.Next(-20, 20) / 100);
    offer *= offerAdjustment;
    if (offer > 9999) { offer = (int)(offer / 1000) * 1000; }
    else if (offer > 999 && offer < 10000) { offer = (int)(offer / 100) * 100; }

    roundOffers[round - 1] = offer;

    Console.SetCursorPosition(2, 19);
    Console.Write("$" + offer);

    if (deal == 0)
    {
        Console.SetCursorPosition(2, 20);
        if (counterOffer == 1) { Console.Write("1. Deal  2. No Deal  3. Counter-Offer"); }
        else { Console.Write("1. Deal  2. No Deal"); }
    }

    for (int a = 0; a <= (round - 1); a++)
    {
        if (deal == (a + 1)) { Console.SetCursorPosition(23, 2 + a); Console.Write("* $" + roundOffers[a]); }
        else { Console.SetCursorPosition(25, 2 + a); Console.Write("$" + roundOffers[a]); }
    }

    if (deal > 0)
    {
        await Task.Delay(2000);
    }
    else
    {
        // Deal Decision.
        int dealDecision = 0;
        do
        {
            Console.SetCursorPosition(2, 21);
            Console.Write(">                                           ");
            Console.SetCursorPosition(4, 21);
            var i = Console.ReadLine();

            try
            {
                dealDecision = int.Parse(i);
            }
            catch // If user inputs a non-number.
            {

                continue;
            }

        } while (dealDecision < 1 || dealDecision > 3 || (dealDecision == 3 && counterOffer == 0));

        if (dealDecision == 1 && deal == 0)
        {
            deal = round;
        }

        if (dealDecision == 3 && counterOffer == 1)
        {
            // *** COUNTER-OFFER *** 
            // Time's almost up anyway.  Let's stop it for now, because tonight's a school night.
            // Start at line 4000 for the counter-offer code.
            
            counterOffer = 0;
            int counterOfferOffer = 0;

            // Calculate Maximum Multiplier. 

            double maximumMultiplier = 1 + (rand.Next(15, 31) / 100.0);


            do
            {
                Console.SetCursorPosition(2, 20);
                Console.Write("How much? >                                           ");
                Console.SetCursorPosition(14, 20);
                var i = Console.ReadLine();


                try
                {
                    counterOfferOffer = int.Parse(i);
                }
                catch
                {
                    continue;
                }

            } while (counterOfferOffer < 1 || counterOfferOffer > 1000000);

            Console.SetCursorPosition(2, 21);
            Console.Write("The Banker says...");

            await Task.Delay(2000);

            if (counterOfferOffer <= (offer * maximumMultiplier))
            {
                Console.SetCursorPosition(21, 21);
                Console.Write("Deal.");
                await Task.Delay(3000);

                roundOffers[round - 1] = counterOfferOffer;
                deal = round;
                
            }
            else
            {
                Console.SetCursorPosition(21, 21);
                Console.Write("No Deal.");
                await Task.Delay(3000);


            }



        }

       




    }
    // *** END OF BANK OFFER *** 
    round++;

} while (round < 10);

// *** FINAL DECISION AND REVEAL OF CASE ***

for (int a = 0; a <= 25; a++)
{
    if (casesActive[a] == 1)
    {
        caseRemaining = a + 1;
    }
}



if (deal == 0)
{
    for (int a = 18; a <= 21; a++)
    {
        Console.SetCursorPosition(2, a);
        Console.Write("                                                                  ");

    }
    Console.SetCursorPosition(2, 18);
    Console.Write("One final decision: You can either keep case " + caseToPick);
    Console.SetCursorPosition(2, 19);
    Console.Write("Or you may swap it with case " + caseRemaining + ".");
    await Task.Delay(3000);
    Console.SetCursorPosition(2, 20);
    Console.Write("Press ENTER to continue.");
    Console.ReadLine();

    for (int a = 18; a <= 21; a++)
    {
        Console.SetCursorPosition(2, a);
        Console.Write("                                                                  ");

    }
    Console.SetCursorPosition(2, 18);
    Console.Write("1. Swap");
    Console.SetCursorPosition(2, 19);
    Console.Write("2. No Swap");

    int swapDecision = 0;
    do
    {
        Console.SetCursorPosition(2, 20);
        Console.Write(">                            ");
        Console.SetCursorPosition(4, 20);
        var i = Console.ReadLine();

        try
        {
            swapDecision = int.Parse(i);
        }
        catch
        {
            continue;
        }

    } while (swapDecision < 1 || swapDecision > 2);

    if (swapDecision == 1)
    {
        caseToPick = caseRemaining;
    }


}



// *** FINAL REVEAL ***
Console.Clear();

Console.SetCursorPosition(2, 2);
if (deal == 0)
{
    Console.Write("You hold case #" + caseToPick + ".");
}
else
{
    Console.Write("You made a deal for $" + roundOffers[deal - 1] + ".");
}

await Task.Delay(2000);

Console.SetCursorPosition(2, 8);
Console.Write("Your case contains...");

Console.SetCursorPosition(2, 10);
Console.Write("/--------\\");
Console.SetCursorPosition(2, 11);
Console.Write("[########]");
Console.SetCursorPosition(2, 12);
Console.Write("\\--------/");

await Task.Delay(3000);

Console.SetCursorPosition(2, 11);
Console.Write("[        ]");
Console.SetCursorPosition(3, 11);
Console.Write("$"+values[caseValues[caseToPick-1]]);

Console.SetCursorPosition(2, 18);
Console.Write("Press ENTER to end.");

Console.ReadLine();

























