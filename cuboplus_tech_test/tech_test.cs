/*
Name: Jessica Marcela Zavaleta Padilla

Solution to a technical test to pass to the next stage of CUBO+ Devs Generation 2024.

Write a program that calculates the total supply of Bitcoin after each halving event, based on Bitcoin’s monetary policy.

The program will show:
● The total Bitcoin supply after each halving.
● The block reward at each stage. (Bitcoin rewards should be converted and printed in SATS (1 BTC = 100,000,000 SATS).
● The percentage of the total 21 million bitcoins mined after each halving.
● The total supply should be calculated by summing the rewards from all previous blocks until the last halving.
*/

public class Program
{
    static void Main()
    {
        const double InitialBlockReward = 50.0; // in Bitcoin
        const double MaximumBitcoinSupply = 21_000_000.0; // The maximum supply of Bitcoin is capped at 21 million bitcoins.
        const int BlocksPerHalving = 210_000;
        const long SatsPerBitcoin = 100_000_000; // Satoshis per Bitcoin.
        const int HalvingFactor = 2; // The factor by which the reward is divided during each halving.
        const int MaxHalvings = 32;

        double supplyPerHalving = 0.0;
        double totalSupply = 0.0;

        // Calculate supply up to the total cap
        for (int halvingNumber = 0; halvingNumber <= MaxHalvings; halvingNumber++)
        {
            // Calculate the block reward at each stage.
            double blockReward =  InitialBlockReward / Math.Pow(HalvingFactor, halvingNumber);
            // Calculate Bitcoin supply per halving.
            supplyPerHalving =  BlocksPerHalving * blockReward;

            // Update the total Bitcoin supply after each halving.
            totalSupply += supplyPerHalving;

            // Convert block reward to SATS (1 BTC = 100,000,000 SATS).
            long blockRewardSats = (long)(blockReward * SatsPerBitcoin);

            // Calculate the percentage of the total 21 million bitcoins mined after each halving
            double percentageMined = (totalSupply / MaximumBitcoinSupply) * 100;

        Console.WriteLine($"Halving event: {halvingNumber}\n" + $"Block reward (BTC): {blockReward:F8} BTC\n" + $"Block reward (SATS): {blockRewardSats:N0} SATS\n" + $"Bitcoin supply per halving: {supplyPerHalving:F8} BTC\n" + $"Percentage mined per halving: {percentageMined:F10}%\n" + $"Total bitcoin supply at this halving event: {totalSupply:F8}"
        );

        Console.WriteLine("-------------------------------------------------------------");

            if (totalSupply >= MaximumBitcoinSupply)
            {
                break;
            }
        }
    }
}
